using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System; 

namespace Project
{
    public abstract class Enemy: GameObject
    {
        public Texture2D enemyTex;
        public int gameSize, speed;
        public bool school;
        
        protected Enemy()
        {
            texname = string.Empty;
            gameSize = 0;
            speed = 0;
            school = false;
            scale = new Vector2(0.5f, 0.5f); 
        }

        public override void Initialize(Random rand)
        {
            enemyTex = Game1.Assets[texname];

            float yRand = 0;
            while (yRand == 0)
                yRand = (float)rand.NextDouble(); 
            position = new Vector2(World.worldSize.X * rand.Next(1, 5) / 5f,
            (location / 5f * World.worldSize.Y) - 1080 * yRand);
            
            origin = new Vector2(enemyTex.Width / 2, enemyTex.Height / 2);
            alive = true;
            size = new Vector2(enemyTex.Width, enemyTex.Height);
        }

        public override void Update(GameTime gameTime)
        {
            if (position.X > World.objects["bg"].position.X + World.objects["bg"].size.X +  - enemyTex.Width / 4
                || position.X < World.objects["bg"].position.X + enemyTex.Width / 4)
                heading.X *= -1;
            position += heading * 300 * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(enemyTex, position, origin: origin, scale: scale);
        }

        public abstract void PatternMovement();
    }
}
