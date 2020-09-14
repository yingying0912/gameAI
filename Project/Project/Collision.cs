using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic; 

namespace Project
{
    public class Collision
    {
        public static List<GameObject> collider;
        public static Dictionary<int, List<GameObject>> level;
        static int lvl; 

        public Collision()
        {
            level = new Dictionary<int, List<GameObject>>();
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
        }

        public static void Initialize()
        {

        }

        public static void Update(GameTime gameTime)
        {
            Rectangle playerBounds = World.objects["player"].Boundary();

            if (World.objects["bg"].position.Y > -525)
            {
                foreach (GameObject enemy in level[1])
                {
                   // if (playerBounds.Intersects(enemy.Boundary()))
                        //enemy.alive = false; 
                }
            }
            else if (World.objects["bg"].position.Y > -1600)
            {
                foreach (GameObject enemy in level[2])
                {
                    //if (playerBounds.Intersects(enemy.Boundary()))
                        //enemy.alive = false;
                }
            }
            else if (World.objects["bg"].position.Y > -2683)
            {
                foreach (GameObject enemy in level[3])
                {
                    //if (playerBounds.Intersects(enemy.Boundary()))
                        //enemy.alive = false;
                }
            }
            else if (World.objects["bg"].position.Y > -3765)
            {
                foreach (GameObject enemy in level[4])
                {
                   // if (playerBounds.Intersects(enemy.Boundary()))
                        //enemy.alive = false;
                }
            }
            else 
            {
                foreach (GameObject enemy in level[5])
                {
                    //if (playerBounds.Intersects(enemy.Boundary()))
                        //enemy.alive = false;
                }
            }
        }
    }
}
