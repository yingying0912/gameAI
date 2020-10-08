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
        Character player; 
        
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
                    Console.WriteLine("Level " + i + " content: " + collider[0].name);
            }
            for (int i = 0; i < 6; i++)
            {
                levelCoord.Add( - 540 - 1080 * i); 
            }
        }

        public void Update()
        {
            for (int i = 0; i < 5;i++)
            {
                if (World.objects["bg"].position.Y > levelCoord[i])
                    CheckCollision(i+1); 
            }
        }

        void CheckCollision(int no)
        {
            foreach (GameObject obj in level[no])
            {
                if (obj.tag == "enemy" && obj.alive == true)
                {
                    if (World.objects["player"].Boundary().Intersects(obj.Boundary()))
                    {
                        if (obj.gameSize <= World.objects["player"].gameSize)
                        {
                            obj.alive = false;
                            Score.addScore(obj.gameSize);
                        }
                        else
                            World.objects["player"].alive = false;
                    }

                    foreach (GameObject obj2 in level[no])
                    {
                        if (obj2.tag == "obstacle" && obj2.alive == true && obj2.Boundary().Intersects(obj.Boundary()))
                        {
                            if (obj.Boundary().Top < obj2.Boundary().Bottom || obj2.Boundary().Top > obj.Boundary().Bottom)
                            {
                                obj.heading.Y *= -1;
                                Console.WriteLine(obj.name + " hit Y of " + obj2.name); 
                            }
                            if (obj.Boundary().Left < obj2.Boundary().Right || obj.Boundary().Right > obj2.Boundary().Left)
                            {
                                obj.heading.X *= -1;
                                Console.WriteLine(obj.name + " hit X of " + obj2.name);
                            }
                        }
                    }
                }
            }
        }
    }
}
