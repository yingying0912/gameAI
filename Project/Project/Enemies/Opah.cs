using Microsoft.Xna.Framework;

namespace Project
{
    class Opah : Enemy
    {
        public Opah()
        {
            name = "opah";
            gameSize = 3;
            speed = 1;
            location = 2;
        }
        public override void PatternMovement(GameTime gameTime)
        {
            BasicMovement(gameTime);
        }
    }
}
