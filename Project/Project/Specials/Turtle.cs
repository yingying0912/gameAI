using Microsoft.Xna.Framework;

namespace Project
{
    class Turtle : Enemy
    {
        public Turtle()
        {
            name = "turtle";
            gameSize = 3;
            speed = 2;
            location = 1;
        }
        public override void PatternMovement(GameTime gameTime)
        {
            BasicMovement(gameTime);
        }
    }
}
