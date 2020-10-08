using Microsoft.Xna.Framework;

namespace Project
{
    class Anglerfish : Enemy 
    {
        public Anglerfish()
        {
            name = "anglerfish";
            gameSize = 3;
            speed = 1;
            location = 4;
        }
        public override void PatternMovement(GameTime gameTime)
        {
            BasicMovement(gameTime);
        }
    }
}
