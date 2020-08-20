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
            position = new Vector2(0f, 0f);
            origin = new Vector2(charTex.Width / 2.0f, charTex.Height / 2.0f);
            alive = true;
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();

            heading = mouse.Position.ToVector2() - position;
            position += heading * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(charTex, position, origin:origin, scale: new Vector2(0.5f,0.5f));
        }
    }
}
