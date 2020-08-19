using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System; 

namespace Project
{
    public class Enemy : GameObject
    {
        Texture2D enemyTex;
        string enemyTexName;
        int size, speed, location;
        bool school;


        public Enemy(string enemyTexName, int size, int speed, int location, bool school)
        {
            this.enemyTexName = enemyTexName;
            this.size = size;
            this.speed = speed;
            this.location = location;
            this.school = school; 
        }

        public override void Initialize()
        {
            enemyTex = Game1.Assets[enemyTexName];
            Random rand = new Random(); 
            position = new Vector2(Game1.Screen.ClientBounds.Width/rand.Next(5),
                location * Game1.Screen.ClientBounds.Height);
            origin = new Vector2(enemyTex.Width / 2.0f, enemyTex.Height / 2.0f);
            alive = true;
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(enemyTex, position, origin: origin, scale: new Vector2(0.5f, 0.5f));
        }
    }
}
