using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System; 

namespace Project
{
    public abstract class Enemy: GameObject
    {
        public Texture2D enemyTex;
        public int size, speed, location;
        public bool school;


        protected Enemy()
        {
            texname = string.Empty;
            size = 0;
            speed = 0;
            location = 0;
            school = false;
        }

        public override void Initialize(Random rand)
        {
            enemyTex = Game1.Assets[texname];
            position = new Vector2(World.worldSize.X * rand.Next(1, 5) / 5f,
            (location / 5f * World.worldSize.Y) * (float)rand.NextDouble());// / 5f);
            origin = new Vector2(enemyTex.Width / 2.0f, 0);
            alive = true;
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(enemyTex, position, origin: origin, scale: new Vector2(0.5f, 0.5f));
        }

        public abstract void PatternMovement();
    }
}
