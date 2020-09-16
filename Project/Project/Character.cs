using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;

namespace Project
{
    public class Character : GameObject
    {
        public Character()
        {
            name = "player";
        }

        public override void Initialize(Random rand)
        {
            texture = Game1.Assets[name];
            position = new Vector2(Game1.Screen.ClientBounds.Width / 2, Game1.Screen.ClientBounds.Height / 2);
            heading = Vector2.Zero;
            alive = true;
            scale = new Vector2(0.5f, 0.5f);
            size = new Vector2(texture.Width * scale.X, texture.Height * scale.Y);
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
            gameSize = 1;
        }

        public override void Update(GameTime gameTime)
        {
            position += heading * 150f * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (Input.MousePosition() < Game1.Screen.ClientBounds.Width/2)
                spriteBatch.Draw(texture, position, origin: origin, scale: scale);
            else
                spriteBatch.Draw(texture, position, origin: origin, scale: scale, effects: SpriteEffects.FlipHorizontally);
        }
    }
}
