using Microsoft.Xna.Framework;

namespace Project
{
    class Jellyfish : Enemy
    {
        public Jellyfish()
        {
            name = "jellyfish";
            gameSize = 1;
            speed = 1;
            location = 2;
        }
        public override void PatternMovement(GameTime gameTime)
        {
            FlockingMovement(gameTime, World.stingray);
        }
    }
}
