using Microsoft.Xna.Framework;

namespace Project
{
    public class BlueWhale : Enemy
    {
        public BlueWhale()
        {
            name = "blueWhale";
            gameSize = 4;
            speed = 1;
            location = 1; 
        }
        public override void PatternMovement(GameTime gameTime)
        {
            BasicMovement(gameTime);
        }
    }
}
