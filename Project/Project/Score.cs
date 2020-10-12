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
        public static int level;
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

        public void Update()
        {
            alive = World.objects["player"].alive;
            if (alive)
            {
                if (level == 1 && score >= maxScorePerLevel[level - 1])
                {
                    Game1.soundEffects[0].Play();
                    level++;
                }
                if (level == 2 && score >= maxScorePerLevel[level - 1])
                {
                    Game1.soundEffects[0].Play();
                    level++;
                }
                if (level == 3 && score >= maxScorePerLevel[level - 1])
                {
                    Game1.soundEffects[0].Play();
                    level++;
                }
                if (level == 4 && score >= maxScorePerLevel[level - 1])
                {
                    Game1.soundEffects[0].Play();
                    level++;
                }
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
        }

    }
}
