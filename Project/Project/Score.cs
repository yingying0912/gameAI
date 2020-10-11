using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace Project
{
    public class Score
    {
        public static int score;
        public bool alive;
        private static int level;
        public List<int> maxScorePerLevel;

        public Score()
        {
            maxScorePerLevel = new List<int>();
        }

        public void Initialize()
        {
            score = 0;
            alive = true;
            // Testing purposes
            // level = 1;
            level = 5;
            maxScorePerLevel.Add(200);
            maxScorePerLevel.Add(500);
            maxScorePerLevel.Add(750);
            maxScorePerLevel.Add(1000);
        }

        public void Update()
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
                Game1.gameStatus = Game1.gameState.Lose;
            }
            World.objects["player"].gameSize = level; 
        }

        public static void addScore(int enemySize)
        {
            if (level == enemySize)
                score += 10;
            else if (level == enemySize + 1)
                score += 5;
            else if (level == enemySize + 2)
                score += 3;
            else if (level == enemySize + 3)
                score += 2;
            Console.WriteLine(score);
        }

    }
}
