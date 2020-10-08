using Microsoft.Xna.Framework;

namespace Project
{
    class Tripodfish : Enemy
    {
        public Tripodfish()
        {
            name = "tripodfish";
            gameSize = 2;
            speed = 4;
            location = 4;
        }
        public override void PatternMovement(GameTime gameTime)
        {
            BasicMovement(gameTime);
        }
    }
}
