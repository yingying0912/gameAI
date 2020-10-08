using Microsoft.Xna.Framework;

namespace Project
{
    class Surgeonfish : Enemy
    {
        public Surgeonfish()
        {
            name = "surgeonfish";
            gameSize = 2;
            speed = 3;
            location = 1;
        }
        public override void PatternMovement(GameTime gameTime)
        {
            BasicMovement(gameTime);
        }
    }
}
