using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic; 

namespace Project
{
    public class Collision
    {
        public List<GameObject> collider;
        public Dictionary<int, List<GameObject>> level; 

        public Collision()
        {
            level = new Dictionary<int, List<GameObject>>();
            System.Diagnostics.Debug.WriteLine("Collider contents:"); 
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
                    System.Diagnostics.Debug.WriteLine("Level " + i + " content: " + collider[0]); 
            }
        }

        public static void Initialize()
        {

        }

        public static void Update()
        {
            if (World.objects["bg"].position.Y > -525)
            {

            }
            else if (World.objects["bg"].position.Y > -1600)
            {

            }
            else if (World.objects["bg"].position.Y > -2683)
            {

            }
            else if (World.objects["bg"].position.Y > -3765)
            {

            }
            else 
            {

            }
        }
    }
}
