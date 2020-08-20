using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;

namespace Project
{
    public class Character : GameObject
    {
        Texture2D charTex;

        public Character()
        {
            texname = "player";
        }

        public override void Initialize(Random rand)
        {
            charTex = Game1.Assets[texname];
            position = new Vector2((World.worldSize.X + Game1.Screen.ClientBounds.Width / 2) * rand.Next(1, 5) / 5f,
            ((0.2f *(World.worldSize.Y) + Game1.Screen.ClientBounds.Height / 2) * (float)rand.NextDouble()));
            origin = new Vector2(charTex.Width / 2.0f, charTex.Height / 2.0f);
            alive = true;
        }

        public override void Update(GameTime gameTime)
        {
            /*
            MouseState mouse = Mouse.GetState();
            heading = mouse.Position.ToVector2() - position;
            position += heading * (float)gameTime.ElapsedGameTime.TotalSeconds;
            */
            
            KeyboardState keystate = Keyboard.GetState();
            if (keystate.IsKeyDown(Keys.W) && position.Y > charTex.Height / 4)
                position.Y -= 1000.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (keystate.IsKeyDown(Keys.A) && position.X > charTex.Width / 4)
                position.X -= 1000.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (keystate.IsKeyDown(Keys.S) && position.Y < World.worldSize.Y - charTex.Height / 4)
                position.Y += 1000.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (keystate.IsKeyDown(Keys.D) && position.X < World.worldSize.X - charTex.Width / 4)
                position.X += 1000.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(charTex, position, origin:origin, scale: new Vector2(0.5f,0.5f));
        }
    }
}
