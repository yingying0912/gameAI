using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;

namespace Project
{
    public abstract class GameObject
    {
        public bool alive;
        public string texname;
        public Vector2 position;
        public Vector2 origin;
        public Vector2 heading;
        public Vector2 size;

        protected GameObject()
        {
            texname = string.Empty;
            alive = false;
            position = Vector2.Zero;
            origin = Vector2.Zero;
            heading = new Vector2(1f, 0f);
            size = Vector2.Zero;
        }

        public abstract void Initialize(Random rand);

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);


    }
}
