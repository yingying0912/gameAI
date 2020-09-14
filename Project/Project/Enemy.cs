using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System; 

namespace Project
{
    public abstract class Enemy: GameObject
    {
        public int gameSize, speed;
        public bool school;
        
        protected Enemy()
        {
            name = string.Empty;
            gameSize = 0;
            speed = 0;
            school = false;
            scale = new Vector2(0.5f, 0.5f); 
        }
        
        public override void Initialize(Random rand)
        {
            texture = Game1.Assets[name];

            float yRand = 0;
            while (yRand == 0)
                yRand = (float)rand.NextDouble(); 
            position = new Vector2(World.worldSize.X * rand.Next(1, 5) / 5f,
            (location / 5f * World.worldSize.Y) - 1080 * yRand);
            scale = new Vector2(0.5f, 0.5f);
            size = new Vector2(texture.Width * scale.X, texture.Height * scale.Y);
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
            alive = true;
        }

        public override void Update(GameTime gameTime)
        {
            if (Boundary().Left < World.objects["bg"].Boundary().Left 
             || Boundary().Right > World.objects["bg"].Boundary().Right)
            {
                heading.X *= -1; 
            }
            if (Boundary().Top < World.objects["bg"].Boundary().Top 
             || Boundary().Bottom > World.objects["bg"].Boundary().Bottom)
            {
                heading.Y *= -1; 
            }

            position += heading * 300 * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture, position, origin: origin, scale: scale);
        }

        public abstract void PatternMovement();
    }
}
