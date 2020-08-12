using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project
{
    public abstract class GameObject
    {
        public bool alive;
        public string name;
        public Vector2 position;
        public Vector2 origin;
        public Vector2 heading;

        protected GameObject()
        {
            name = string.Empty;
            alive = false;
            position = Vector2.Zero;
            origin = Vector2.Zero;
            heading = new Vector2(1f, 0f);
        }

        public abstract void Initialize();

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);


    }
}
