using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using System;

namespace Project
{
    class World
    {
        public static Dictionary<string, GameObject> objects = new Dictionary<string, GameObject>();
        static LinkedList<GameObject> drawList = new LinkedList<GameObject>(); 
        static Collision collision = new Collision();
        public static Vector2 worldSize;

        public static void Add(string key, GameObject obj)
        {
            try
            {
                objects.Add(key, obj);
                drawList.AddLast(obj);
            }
            catch (Exception)
            {
                Console.WriteLine("World.Add: Exception");
            }
        }

        public static void Remove(string key)
        {
            try
            {
                drawList.Remove(objects[key]);
                objects.Remove(key);
            }
            catch (Exception)
            {
                Console.WriteLine("World.Remove: Exception");
            }
        }

        public static void Clear()
        {
            objects.Clear();
            drawList.Clear();
        }

        public static void Initialize(Random rand)
        {
            foreach (GameObject obj in drawList)
                obj.Initialize(rand);

            collision.Initialize(); 
            Console.WriteLine("world.cs: " + worldSize);
        }

        public static void Update(GameTime gameTime)
        {
            LinkedListNode<GameObject> itr = drawList.First;
            while (itr != null)
            {
                if (itr.Value.alive)
                    itr.Value.Update(gameTime);
                itr = itr.Next;
            }
            collision.Update(); 
        }
        
        public static void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (GameObject obj in drawList)
            {
                if (obj.alive)
                    obj.Draw(spriteBatch, gameTime);
            }
        }

        public static void Move(GameTime gameTime, Vector2 velocity, float distance)
        {
            foreach (var obj in objects)
            {
                if (obj.Key != "player")
                    objects[obj.Key].position += velocity * 2f * distance * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }                
        }
    }
}
