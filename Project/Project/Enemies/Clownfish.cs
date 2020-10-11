using Microsoft.Xna.Framework;

namespace Project
{
    class Clownfish : Enemy
    {
        public Clownfish()
        {
            name = "clownfish";
            gameSize = 1;
            speed = 3;
            location = 1;
        }
        public override void PatternMovement(GameTime gameTime)
        {
            BasicMovement(gameTime);
        }
    }
}
