using Microsoft.Xna.Framework;

namespace Project
{
    class Flatfish : Enemy
    {
        public Flatfish()
        {
            name = "flatfish";
            gameSize = 1;
            speed = 2;
            location = 5;
        }
        public override void PatternMovement(GameTime gameTime)
        {
            BasicMovement(gameTime);
        }
    }
}
