using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Opah : Enemy
    {
        public Opah()
        {
            name = "opah";
            gameSize = 1;
            speed = 1;
            location = 2;
        }
        public override void PatternMovement()
        {

        }
    }
}
