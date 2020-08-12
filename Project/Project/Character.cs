using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project
{
    public class Character : GameObject
    {
        Texture2D chartex;
        string charTexName;

        public Character()
        {
            charTexName = "player";
        }

        public override void Initialize()
        {
            chartex = Game1.Assets[charTexName];
            position = new Vector2(Game1.Screen.ClientBounds.Width / 2.0f,
                Game1.Screen.ClientBounds.Height / 2.0f);
            origin = new Vector2(chartex.Width / 2.0f, chartex.Height / 2.0f);
            alive = true;
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();

            heading = mouse.Position.ToVector2() - position;
            position += heading * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(chartex, position, origin:origin, scale: new Vector2(0.5f,0.5f));
        }
    }
}
