using System;
using System.Collections.Generic; 

namespace Project
{
    public class Collision
    {
        Dictionary<int, List<GameObject>> level;
        List<GameObject> collider;
        List<int> levelCoord;
        Player player; 
        
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
                levelCoord.Add(- 1080 - 864 * i); 
            }
        }

        public void Update()
        {
            /*
            for (int i = 0; i < 5; i++)
            {
                if (World.objects["bg"].position.Y > levelCoord[i])
                    CheckCollision(i+1); 
            }
            */

            CheckCollision2(); 
        }

        void CheckCollision(int no)
        {
            foreach (GameObject obj in level[no])
            {
                if (obj.alive == true)
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
                }
            }
        }

        void CheckCollision2()
        {
            foreach (var obj in World.objects)
            {
                if (obj.Key != "bg" && obj.Key != "player" && obj.Value.alive == true)
                {
                    if (World.objects["player"].Boundary().Intersects(obj.Value.Boundary()))
                    {
                        if (obj.Value.gameSize <= World.objects["player"].gameSize)
                        {
                            obj.Value.alive = false;
                            Score.addScore(obj.Value.gameSize);
                        }
                        else
                            World.objects["player"].alive = false;
                    }
                }
            }
        }
    }
}
