using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    class Obstacle : GameObject
    {
        public Obstacle(string name, float posX, float posY)
        {
            this.name = name;
            position.X = posX;
            position.Y = posY;
        }

        public override void Initialize(Random rand)
        {
            tag = "obstacle"; 
            alive = true;
            texture = Game1.Assets[name];
            size = new Vector2(texture.Width * scale.X, texture.Height * scale.Y);
            origin = new Vector2(texture.Width / 2, texture.Height / 2);

            location = getLocation();
            gameSize = 10;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture, position, origin: origin, scale: scale);
        }

        int getLocation()
        {
            if (position.Y < 1080) return 1; 
            else if (position.Y < 2160) return 2; 
            else if (position.Y < 3240) return 3; 
            else if (position.Y < 4320) return 4; 
            else return 5; 
        }
    }
}
