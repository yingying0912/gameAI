using Microsoft.Xna.Framework;

namespace Project
{
    class Stingray : Enemy 
    {
        public Stingray()
        {
            name = "stingray";
            gameSize = 3;
            speed = 3;
            location = 5;
        }
        public override void PatternMovement(GameTime gameTime)
        {
            BasicMovement(gameTime);
        }
    }
}
