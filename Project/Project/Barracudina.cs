using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Barracudina : Enemy
    {
        public Barracudina()
        {
            name = "barracudina";
            gameSize = 4;
            speed = 4;
            location = 3;
        }
        public override void PatternMovement()
        {

        }
    }
}
