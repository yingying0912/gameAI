using Microsoft.Xna.Framework;

namespace Project
{
    class Cuttlefish : Enemy
    {
        public Cuttlefish()
        {
            name = "cuttlefish";
            gameSize = 2;
            speed = 2;
            location = 2;
        }
        public override void PatternMovement(GameTime gameTime)
        {
            BasicMovement(gameTime);
        }
    }
}
