using Microsoft.Xna.Framework;

namespace Project
{
    class Lancetfish : Enemy
    {
        public Lancetfish()
        {
            name = "lancetfish";
            gameSize = 3;
            speed = 4;
            location = 2;
        }
        public override void PatternMovement(GameTime gameTime)
        {
            BasicMovement(gameTime);
        }
    }
}
