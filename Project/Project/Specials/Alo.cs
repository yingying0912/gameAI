using Microsoft.Xna.Framework;

namespace Project
{
    public class Alo : Enemy
    {
        public Alo()
        {
            name = "alo";
            gameSize = 5;
            speed = 5;
            location = 5;
            scale = new Vector2(1f, 1f); 
        }
        public override void PatternMovement(GameTime gameTime)
        {
            BasicMovement(gameTime);
        }
    }
}