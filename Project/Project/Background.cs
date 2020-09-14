using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    public class Background : GameObject 
    {
        public Background()
        {
            name = "backgroundwgrid";
            scale = new Vector2(5f, 5f); 
        }

        public override void Initialize(Random rand)
        {
            texture = Game1.Assets[name];
            alive = true; 
            size = new Vector2(texture.Width * scale.X, texture.Height * scale.Y);
            World.worldSize = size;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture, position, origin: origin, scale: scale);
        }
    }
}
