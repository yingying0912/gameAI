using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
            //position = new Vector2(1000, 800); 
            position = new Vector2(Game1.Screen.ClientBounds.Width / 2, Game1.Screen.ClientBounds.Height / 2);
            origin = new Vector2(charTex.Width / 2.0f, charTex.Height / 2.0f);
            alive = true;
            size = new Vector2(charTex.Width, charTex.Height);
            scale = new Vector2(0.5f, 0.5f); 
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(charTex, position, origin:origin, scale: scale);
        }
    }
}
