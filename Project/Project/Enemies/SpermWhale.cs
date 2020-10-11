using Microsoft.Xna.Framework;

namespace Project
{
    class SpermWhale : Enemy 
    {
        public SpermWhale()
        {
            name = "spermWhale";
            gameSize = 4;
            speed = 3;
            location = 4;
        }
        public override void PatternMovement(GameTime gameTime)
        {
            FlockingMovement(gameTime, World.sperm);
        }
    }
}
