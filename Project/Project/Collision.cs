using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic; 

namespace Project
{
    public class Collision
    {
        Dictionary<int, List<GameObject>> level;
        List<GameObject> collider;
        List<int> levelCoord;
        int counter; 
        
        public Collision()
        {
            level = new Dictionary<int, List<GameObject>>();
            levelCoord = new List<int>(); 
        }

        public void Initialize()
        {
            Console.WriteLine("Collider contents:");
            for (int i = 1; i < 6; i++)
            {
                collider = new List<GameObject>();
                foreach (var obj in World.objects)
                {
                    if (obj.Key != "player" && World.objects[obj.Key].location == i)
                        collider.Add(World.objects[obj.Key]);
                }
                level.Add(i, collider);

                if (collider.Count > 0)
                    Console.WriteLine("Level " + i + " content: " + collider[0]);
            }
            for (int i = 0; i < 6; i++)
            {
                levelCoord.Add( - 540 - 1080 * i); 
            }
        }

        public void Update()
        {
            Console.WriteLine(World.objects["bg"].position.Y); 
            counter = 0;
            for (int i = 0; i < 5;)
            {
                i++; 
                if (World.objects["bg"].position.Y > levelCoord[i])
                    CheckCollision(i); 
            }
        }

        void CheckCollision(int no)
        {
            foreach (GameObject enemy in level[no])
            {
                if (World.objects["player"].Boundary().Intersects(enemy.Boundary()))
                {
                    if (enemy.gameSize <= World.objects["player"].gameSize)
                        enemy.alive = false;
                    else
                        World.objects["player"].alive = false;
                }
            }
        }
    }
}
