using Microsoft.Xna.Framework;

namespace Project
{
    class Prawn : Enemy
    {
        public Prawn()
        {
            name = "prawn";
            gameSize = 5;
            speed = 3;
            location = 4;
        }
        public override void PatternMovement(GameTime gameTime)
        {
            BasicMovement(gameTime);
        }
    }
}
