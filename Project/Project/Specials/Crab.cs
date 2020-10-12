using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;

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
            position.Y = World.worldPosition.Y + World.worldSize.Y - Game1.Screen.ClientBounds.Height / 5;
            if (position.X < World.worldPosition.X + World.worldSize.X * 3 / 7)
                heading.X = 1; 
            if (position.X > World.worldPosition.X + World.worldSize.X * 3 / 4) 
                heading.X = -1;

            position += heading * speed * 80 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
