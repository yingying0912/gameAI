using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;

namespace Project
{
    public abstract class GameObject
    {
        public bool alive; 
        public string name; 
        public Vector2 heading, position, origin, size, scale;
        public Texture2D texture; 
        public int location, gameSize; 

        protected GameObject()
        {
            alive = false;
            name = string.Empty;
            heading = new Vector2(1f, 0f);
            location = gameSize = 0;
            position = origin = size = scale = Vector2.Zero;
        }

        public abstract void Initialize(Random rand);

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);

        public Rectangle Boundary()
        {
            Vector2 pos;
            if (name == "backgroundwgrid") pos = position; 
            else pos = position - size / 2; 
            return new Rectangle((int)pos.X, (int)pos.Y, (int)size.X, (int)size.Y);
        }
    }
}
