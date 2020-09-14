using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using System;

namespace Project
{
    class World
    {
        public static Dictionary<string, GameObject> objects = new Dictionary<string, GameObject>();
        private static LinkedList<GameObject> drawList = new LinkedList<GameObject>();
        public static Vector2 worldSize;
        static Collision coll;

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

            coll = new Collision(); 
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
            Collision.Update(gameTime); 
        }
        
        public static void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (GameObject obj in drawList) 
                if (obj.alive)
                    obj.Draw(spriteBatch, gameTime);
        }
    }
}
