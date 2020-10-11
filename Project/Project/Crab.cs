using Microsoft.Xna.Framework;

namespace Project
{
    class Crab : Enemy
    {
        public Crab()
        {
            name = "crab";
            gameSize = 1;
            speed = 3;
            location = 5;
        }
        public override void PatternMovement(GameTime gameTime)
        {
            FlockingMovement(gameTime, World.stingray);
        }
    }
}
