using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;

namespace Project
{
    class Input
    {
        static MouseState mouse;
        Vector2 velocity;
        float distance;

        public void Update(GameWindow Screen, GameTime gameTime)
        {
            mouse = Mouse.GetState();
            //World.objects["player"].heading = Vector2.Zero;
            velocity = Vector2.Zero;
            distance = 0;

            if (InControlArea(Screen))
                CalculateMovement();

            CheckBorder();
            /*
            if (World.objects["bg"].Boundary().Left > 1 && velocity.X > 0)
            {
                World.objects["player"].heading.X = velocity.X * -1;
                velocity.X = 0;
            }
            if (World.objects["bg"].Boundary().Right < Game1.Screen.ClientBounds.Width && velocity.X < 0)
            {
                World.objects["player"].heading.X = velocity.X * -1;
                velocity.X = 0;
            }
            if (World.objects["bg"].Boundary().Top > 1 && velocity.Y > 0)
            {
                World.objects["player"].heading.Y = velocity.Y * -1;
                velocity.Y = 0;
            }
            if (World.objects["bg"].Boundary().Bottom < Game1.Screen.ClientBounds.Height && velocity.Y < 0)
            {
                World.objects["player"].heading.Y = velocity.Y * -1;
                velocity.Y = 0;
            }
            
            if (World.objects["player"].position.X != Game1.Screen.ClientBounds.Width / 2)
            {
                World.objects["player"].heading.X = velocity.X * 1;
                velocity.X = 0;
            }
            if (World.objects["player"].position.Y != Game1.Screen.ClientBounds.Height / 2)
            {
                World.objects["player"].heading.Y = velocity.Y * 1;
                velocity.Y = 0;
            }*/
            World.Move(gameTime, velocity, distance);            
        }

        bool InControlArea(GameWindow Screen)
        {
            if (mouse.Position.X < Screen.ClientBounds.Width / 3
             || mouse.Position.X > Screen.ClientBounds.Width * 2 / 3
             || mouse.Position.Y < Screen.ClientBounds.Height / 3
             || mouse.Position.Y > Screen.ClientBounds.Height * 2 / 3)
                return true;
            else
                return false;
        }

        void CheckBorder()
        {
            if (World.objects["bg"].Boundary().Left > 1 && velocity.X > 0) velocity.X = 0;
            if (World.objects["bg"].Boundary().Right < Game1.Screen.ClientBounds.Width && velocity.X < 0) velocity.X = 0;
            if (World.objects["bg"].Boundary().Top > 1 && velocity.Y > 0) velocity.Y = 0;
            if (World.objects["bg"].Boundary().Bottom < Game1.Screen.ClientBounds.Height && velocity.Y < 0) velocity.Y = 0;
        }
        

        void CalculateMovement()
        {
            velocity = World.objects["player"].position - mouse.Position.ToVector2();
            velocity.Normalize();
            distance = (float)Math.Sqrt((World.objects["player"].position.X - mouse.Position.ToVector2().X)
                                      * (World.objects["player"].position.X - mouse.Position.ToVector2().X)
                                      + (World.objects["player"].position.Y - mouse.Position.ToVector2().Y)
                                      * (World.objects["player"].position.Y - mouse.Position.ToVector2().Y));
        }

        public static float MousePosition()
        {
            return mouse.Position.X;
        }
    }
}