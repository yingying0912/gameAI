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
        private float respawnTimer, currentTime;

        protected Enemy()
        {
            name = string.Empty;
            gameSize = 0;
            speed = 0;
            school = false;
            scale = new Vector2(0.5f, 0.5f);
            status = state.Idle;
            displacement = Vector2.Zero;
            respawnTimer = 20f;
            currentTime = 0f;
        }

        public override void Initialize(Random rand)
        {
            texture = Game1.Assets[name];

            float yRand = 0;
            while (yRand == 0)
                yRand = (float)rand.NextDouble();
            position = new Vector2(Game1.Screen.ClientBounds.Width / 2 + (World.worldSize.X - Game1.Screen.ClientBounds.Width) * rand.Next(1, 5) / 5f,
            Game1.Screen.ClientBounds.Height / 2 + (location / 5f * (World.worldSize.Y - Game1.Screen.ClientBounds.Height)) - Game1.Screen.ClientBounds.Height * yRand);
            scale = new Vector2(0.5f, 0.5f);
            size = new Vector2(texture.Width * scale.X, texture.Height * scale.Y);
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
            alive = true;
            timeCounter = 0;
            maxTime = 200;
        }

        public override void Update(GameTime gameTime)
        {
            getStatus();

            switch (status)
            {
                case state.Idle:
                    position += heading * 150 * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    //Wander(gameTime, Game1.rand);
                    break;
                case state.Seeking:
                    Seek(gameTime);
                    break;
                case state.Fleeing:
                    Flee(gameTime);
                    break;
                case state.Dead:
                    Console.WriteLine(position);
                    WaitForRespawn(gameTime);
                    break;
            }

            if (Boundary().Left < World.objects["bg"].Boundary().Left + Game1.Screen.ClientBounds.Width / 2
             || Boundary().Right > World.objects["bg"].Boundary().Right - Game1.Screen.ClientBounds.Width / 2)
            {
                heading.X *= -1;
            }
            if (Boundary().Top < World.objects["bg"].Boundary().Top + Game1.Screen.ClientBounds.Height / 2
             || Boundary().Bottom > World.objects["bg"].Boundary().Bottom - Game1.Screen.ClientBounds.Height / 2)
            {
                heading.Y *= -1;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (heading.X < 0)
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
            if (Boundary().Left < World.objects["bg"].Boundary().Left + Game1.Screen.ClientBounds.Width / 2 && heading.X < 0) heading.X = 0;
            if (Boundary().Right > World.objects["bg"].Boundary().Right - Game1.Screen.ClientBounds.Width / 2 && heading.X > 0) heading.X = 0;
            if (Boundary().Top < World.objects["bg"].Boundary().Top + Game1.Screen.ClientBounds.Height / 2 && heading.Y < 0) heading.Y = 0;
            if (Boundary().Bottom > World.objects["bg"].Boundary().Bottom - Game1.Screen.ClientBounds.Height / 2 && heading.Y > 0) heading.Y = 0;
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

        public void WaitForRespawn(GameTime gameTime)
        {
            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (currentTime >= respawnTimer)
            {
                currentTime = 0;
                position = World.worldPosition + new Vector2(Game1.Screen.ClientBounds.Width / 2 + (World.worldSize.X - Game1.Screen.ClientBounds.Width) * Game1.rand.Next(1, 5) / 5f,
                    Game1.Screen.ClientBounds.Height / 2 + (location / 5f * (World.worldSize.Y - Game1.Screen.ClientBounds.Height)) - Game1.Screen.ClientBounds.Height * (float)Game1.rand.NextDouble()); ;
                heading = new Vector2(1f, 0f);
                Console.WriteLine(name + " respawned at " + position);
                alive = true;
            }
        }
    }
}
