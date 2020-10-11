using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;

namespace Project
{
    public class Mermaid : GameObject
    {
        Texture2D texture2;
        public Mermaid()
        {
            name = "mermaid";
            alive = true;
            heading = new Vector2(0f, 1f);
            heading.Normalize(); 
        }

        public override void Initialize(Random rand)
        {
            texture = Game1.Assets[name];
            texture2 = Game1.Assets["mermaid2"];
            origin = new Vector2(texture.Width / 2, texture.Height / 2);

            position = new Vector2(4800, 5000); 
        }

        public override void Update(GameTime gameTime)
        {
            //if (position.Y < 4500 || position.Y > 5200)
                //heading.Y *= -1;

            //Console.WriteLine("mermaid Y " + position.Y);
            //position += heading * 150 * (float)gameTime.ElapsedGameTime.TotalSeconds;

        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (!Game1.endState)
                spriteBatch.Draw(texture, position, origin: origin, scale: scale);
            else
                spriteBatch.Draw(texture2, position, origin: origin, scale: scale);
        }
    }
}
