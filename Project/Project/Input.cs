using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;

namespace Project
{
    class Input
    {
        MouseState mouse;
        Vector2 velocity;
        float distance;

        public void Update(GameWindow Screen, GameTime gameTime)
        {
            mouse = Mouse.GetState();
            velocity = Vector2.Zero;
            distance = 0;

            if (InControlArea(Screen))
                CalculateMovement(); 

            CheckBorder();
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
            if (World.objects["player"].Boundary().Left < World.objects["bg"].Boundary().Left && velocity.X > 0) velocity.X = 0;
            if (World.objects["player"].Boundary().Right > World.objects["bg"].Boundary().Right && velocity.X < 0) velocity.X = 0;
            if (World.objects["player"].Boundary().Top < World.objects["bg"].Boundary().Top && velocity.Y > 0) velocity.Y = 0;
            if (World.objects["player"].Boundary().Bottom > World.objects["bg"].Boundary().Bottom && velocity.Y < 0) velocity.Y = 0;
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
    }
}