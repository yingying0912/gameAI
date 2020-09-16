using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System; 

namespace Project
{
    public abstract class Enemy : GameObject
    {
        public enum state { Idle, Seeking, Fleeing, Dead }

        public int speed;
        public bool school;
        public state status;
        private Vector2 displacement;
        private int timeCounter, maxTime;

        protected Enemy()
        {
            name = string.Empty;
            gameSize = 0;
            speed = 0;
            school = false;
            scale = new Vector2(0.5f, 0.5f);
            status = state.Idle;
            displacement = Vector2.Zero;
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
            timeCounter = 0;
            maxTime = 200;
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

            getStatus();

            switch (status)
            {
                case state.Idle:
                    //position += heading * 150 * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Wander(gameTime, Game1.rand);
                    break;
                case state.Seeking:
                    Seek(gameTime);
                    break;
                case state.Fleeing:
                    Flee(gameTime);
                    break;
                case state.Dead:
                    Console.WriteLine(name + " is dead");
                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (heading.X > 0)
                spriteBatch.Draw(texture, position, origin: origin, scale: scale);
            else
                spriteBatch.Draw(texture, position, origin: origin, scale: scale, effects: SpriteEffects.FlipHorizontally);
        }

        public abstract void PatternMovement();

        private void getStatus()
        {
            if (alive == true)
            {
                if ((float)Math.Sqrt((World.objects["player"].position.X - position.X)
                * (World.objects["player"].position.X - position.X)
                + (World.objects["player"].position.Y - position.Y)
                * (World.objects["player"].position.Y - position.Y)) < 500)
                {
                    if (gameSize <= World.objects["player"].gameSize)
                        status = state.Fleeing;
                    else
                        status = state.Seeking;
                }
                else
                    status = state.Idle;
            }
            else
                status = state.Dead;
        }

        public void Seek(GameTime gameTime)
        {
            heading = World.objects["player"].position - position;
            heading.Normalize();
            position += heading * speed * 150 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Flee(GameTime gameTime)
        {
            heading = position - World.objects["player"].position;
            heading.Normalize();

            //next -> can try random heading number of opposite direction when enemy reached the boundary.
            if (Boundary().Left < World.objects["bg"].Boundary().Left && heading.X < 0) heading.X = 0;
            if (Boundary().Right > World.objects["bg"].Boundary().Right && heading.X > 0) heading.X = 0;
            if (Boundary().Top < World.objects["bg"].Boundary().Top && heading.Y < 0) heading.Y = 0;
            if (Boundary().Bottom > World.objects["bg"].Boundary().Bottom && heading.Y > 0) heading.Y = 0;
            position += heading * speed * 150 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Wander(GameTime gameTime, Random rand)
        {
            if (timeCounter == 0)
            {
                position += heading * speed * 150 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                displacement = new Vector2((float)rand.NextDouble(), (float)rand.NextDouble());
                heading += displacement;
                heading.Normalize();
                timeCounter = maxTime;
            }
            else
            {
                timeCounter--;
                position += heading * speed * 150 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }    
        }
    }
}
