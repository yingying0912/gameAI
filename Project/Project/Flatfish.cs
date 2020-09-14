using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Flatfish : Enemy
    {
        public Flatfish()
        {
            texname = "flatfish";
            gameSize = 4;
            speed = 2;
            location = 5;
        }
        public override void PatternMovement()
        {

        }
    }
}
