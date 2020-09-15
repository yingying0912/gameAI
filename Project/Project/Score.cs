using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace Project
{
    public class Score
    {
        public int score;
        public bool alive;
        public int level;
        public List<int> maxScorePerLevel;

        public Score()
        {
            maxScorePerLevel = new List<int>();
        }

        public void Initialize()
        {
            score = 0;
            alive = true;
            level = 1;
            maxScorePerLevel.Add(200);
            maxScorePerLevel.Add(500);
            maxScorePerLevel.Add(750);
            maxScorePerLevel.Add(1000);
        }

        public void Update(Game1.gameState gameStatus)
        {
            alive = World.objects["player"].alive;
            if (alive)
            {
                if (level == 1 && score >= 200)
                    level++;
                if (level == 2 && score >= 500)
                    level++;
                if (level == 3 && score >= 750)
                    level++;
                if (level == 4 && score >= 1000)
                    level++;
                //if (level == 5 && EndTriggered)
                //Game1.gameStatus = gameState.Win
            }
            else
            {
                gameStatus = Game1.gameState.Lose;
            }
            
        }

    }
}
