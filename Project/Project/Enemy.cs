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
        public Vector2 acceleration;
        private int timeCounter, maxTime;
        private float respawnTimer, currentTime;

        public int moveCounter; 

        protected Enemy()
        {
            speed = 0;
            school = false;
            status = state.Idle;
            displacement = Vector2.Zero;
            respawnTimer = 20f;
            currentTime = 0f;

            tag = "enemy";

            moveCounter = 0; 
        }

        public override void Initialize(Random rand)
        {
            texture = Game1.Assets[name];

            scale = new Vector2(gameSize * 0.125f, gameSize * 0.125f); 

            float yRand = 0;
            while (yRand == 0)
                yRand = (float)rand.NextDouble();
            position = new Vector2(Game1.Screen.ClientBounds.Width / 2 + (World.worldSize.X - Game1.Screen.ClientBounds.Width) * rand.Next(1, 5) / 5f,
            Game1.Screen.ClientBounds.Height / 2 + (location / 5f * (World.worldSize.Y - Game1.Screen.ClientBounds.Height)) - Game1.Screen.ClientBounds.Height * yRand);

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
                    PatternMovement(gameTime);
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
            
            if ((Boundary().Left < World.objects["bg"].Boundary().Left + Game1.Screen.ClientBounds.Width / 2) && heading.X < 0
                || (Boundary().Right > World.objects["bg"].Boundary().Right - Game1.Screen.ClientBounds.Width / 2) && heading.X > 0)
            {
                heading.X *= -1;
            }
            if ((Boundary().Bottom > World.testLocationBoundary[location] && heading.Y > 0)
                || (Boundary().Top < World.testLocationBoundary[location - 1] && heading.Y < 0))
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

        public abstract void PatternMovement(GameTime gameTime);

        private void getStatus()
        {
            if (alive == true)
            {
                if ((float)Math.Sqrt((World.objects["player"].position.X - position.X)
                * (World.objects["player"].position.X - position.X)
                + (World.objects["player"].position.Y - position.Y)
                * (World.objects["player"].position.Y - position.Y)) < 200)
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

        public void BasicMovement(GameTime gameTime)
        {
            acceleration = Separate();
            heading += acceleration;
            position += heading * 150 * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        private Vector2 Separate()
        {
            Vector2 average = Vector2.Zero;
            int count = 0;

            foreach (var obj in World.objects)
            {
                if (obj.Key != "bg" && obj.Key != "player" && obj.Value.alive && obj.Key != this.name && IsNear(obj.Value, 100))
                {
                    Vector2 v = position - obj.Value.position;
                    float d = v.Length();
                    v /= d;

                    average += v;
                    count++;
                }
            }

            if (count > 0 && average.Length() > 0)
            {
                average /= count;
                average = Vector2.Normalize(average);
                Vector2 steer = average - heading;
                return steer * 1.5f;
            }
            else
                return Vector2.Zero;
        }

        private bool IsNear(GameObject obj, float radius)
        {
            float distance = (position - obj.position).Length();
            return (0 < distance && distance < radius);
        }
    }
}
