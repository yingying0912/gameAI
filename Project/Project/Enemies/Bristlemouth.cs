using Microsoft.Xna.Framework;

namespace Project
{
    class Bristlemouth : Enemy
    {
        public Bristlemouth()
        {
            name = "bristlemouth";
            gameSize = 1;
            speed = 3;
            location = 3;
        }
        public override void PatternMovement(GameTime gameTime)
        {
            BasicMovement(gameTime);
        }
    }
}
