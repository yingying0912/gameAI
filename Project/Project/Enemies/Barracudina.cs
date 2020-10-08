using Microsoft.Xna.Framework;

namespace Project
{
    class Barracudina : Enemy
    {
        public Barracudina()
        {
            name = "barracudina";
            gameSize = 2;
            speed = 4;
            location = 3;
        }
        public override void PatternMovement(GameTime gameTime)
        {
            BasicMovement(gameTime);
        }
    }
}
