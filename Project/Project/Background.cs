using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    public class Background : GameObject 
    {
        public Background()
        {
            name = "background"; 
            scale = new Vector2(5f, 5f); 
        }

        public override void Initialize(Random rand)
        {
            texture = Game1.Assets[name]; 
            alive = true;
            tag = "background"; 
            size = new Vector2(texture.Width * scale.X, texture.Height * scale.Y);
            World.worldSize = size;
            for (int i = 0; i <= 5; i++)
            {
                World.locationBoundary.Add((size.Y - Game1.Screen.ClientBounds.Height) * i / 5 + Game1.Screen.ClientBounds.Height / 2);
                World.testLocationBoundary.Add((size.Y - Game1.Screen.ClientBounds.Height) * i / 5 + Game1.Screen.ClientBounds.Height / 2);
            }
        }

        public override void Update(GameTime gameTime)
        {
            World.worldPosition = position;
            for (int i = 0; i <= 5; i++)
            {
                World.testLocationBoundary[i] = World.locationBoundary[i] + position.Y;
            }

        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture, position, origin: origin, scale: scale);
        }
    }
}
