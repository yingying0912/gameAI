using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Tripodfish : Enemy
    {
        public Tripodfish()
        {
            name = "tripodfish";
            gameSize = 4;
            speed = 4;
            location = 4;
        }
        public override void PatternMovement(GameTime gameTime)
        {
            BasicMovement(gameTime);
        }
    }
}
