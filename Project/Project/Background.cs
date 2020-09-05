using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    public class Background : GameObject 
    {
        Texture2D backTex;

        public Background()
        {
            texname = "backgroundwgrid";
            scale = new Vector2(5f, 5f); 
        }

        public override void Initialize(Random rand)
        {
            backTex = Game1.Assets[texname];
            alive = true; 
            position = new Vector2(backTex.Width / 2.0f, backTex.Height / 2.0f);
            origin = new Vector2(backTex.Width / 2.0f, backTex.Height / 2.0f);
            size = new Vector2(backTex.Width * scale.X, backTex.Height * scale.Y);
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(backTex, position, origin: origin, scale: scale);
        }
    }
}
