using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;

namespace Project
{
    public abstract class GameObject
    {
        public bool alive;
        public string texname;
        public Vector2 heading, position, origin, size, scale;

        protected GameObject()
        {
            alive = false;
            texname = string.Empty;
            heading = new Vector2(1f, 0f);
            position = origin = size = scale = Vector2.Zero;
        }

        public abstract void Initialize(Random rand);

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
        
    }
}
