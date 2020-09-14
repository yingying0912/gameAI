using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;

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

        public override void PatternMovement()
        {
            
        }
    }
}
