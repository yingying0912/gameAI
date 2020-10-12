using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Project
{
    public class Collision
    {
        Dictionary<int, List<GameObject>> level;
        List<GameObject> collider;
        List<int> levelCoord;
        
        public Collision()
        {
            level = new Dictionary<int, List<GameObject>>();
            levelCoord = new List<int>();
        }

        public void Initialize()
        {
            for (int i = 1; i < 6; i++)
            {
                collider = new List<GameObject>();

                foreach (var obj in World.objects)
                {
                    if (obj.Key != "player" && World.objects[obj.Key].location == i)
                        collider.Add(World.objects[obj.Key]);
                }
                level.Add(i, collider);
            }
            for (int i = 0; i < 6; i++)
            {
                levelCoord.Add(- 1080 - 864 * i); 
            }
        }

        public void Update()
        {
            CheckCollision(); 
        }

        void CheckCollision()
        {
            foreach (var obj in World.objects)
            {
                if (obj.Key != "bg" && obj.Key != "player" && obj.Key != "mermaid" && obj.Value.alive == true)
                {
                    if (World.objects["player"].Boundary().Intersects(obj.Value.Boundary()))
                    {
                        if (obj.Value.gameSize <= World.objects["player"].gameSize)
                        {
                            obj.Value.alive = false;
                            Score.addScore(obj.Value.gameSize);
                            Game1.soundEffects[3].Play();
                        }
                        else
                            World.objects["player"].alive = false;
                    }
                }
            }

            if (World.objects["player"].Boundary().Intersects(World.objects["mermaid"].Boundary()) && Game1.endState)
                Game1.triggerEnd = true;
        }
    }
}
