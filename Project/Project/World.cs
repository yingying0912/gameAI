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
        public static Vector2 worldPosition;
        public static List<float> locationBoundary = new List<float>();
        public static List<float> testLocationBoundary = new List<float>();

        public static List<Anglerfish>      angler  = new List<Anglerfish>(); 
        public static List<Barracudina>     barra   = new List<Barracudina>(); 
        public static List<BlueWhale>       blue    = new List<BlueWhale>(); 
        public static List<Bristlemouth>    bristle = new List<Bristlemouth>(); 
        public static List<Clownfish>       clown   = new List<Clownfish>(); 
        public static List<Cuttlefish>      cuttle  = new List<Cuttlefish>(); 
        public static List<Flatfish>        flat    = new List<Flatfish>(); 
        public static List<Lancetfish>      lancet  = new List<Lancetfish>(); 
        public static List<Opah>            opah    = new List<Opah>(); 
        public static List<SpermWhale>      sperm   = new List<SpermWhale>(); 
        public static List<Stingray>        stingray= new List<Stingray>(); 
        public static List<Surgeonfish>     surgeon = new List<Surgeonfish>(); 
        public static List<Tripodfish>      tripod  = new List<Tripodfish>(); 

        public static void Sort()
        {
            foreach (var obj in objects)
            {
                switch (objects[obj.Key].name)
                {
                    case "anglerfish":
                        angler.Add((Anglerfish)objects[obj.Key]);
                        break; 
                    case "barracudina":
                        barra.Add((Barracudina)objects[obj.Key]); 
                            break; 
                    case "blueWhale":
                        blue.Add((BlueWhale)objects[obj.Key]);
                        break; 
                    case "brislemouth":
                        bristle.Add((Bristlemouth)objects[obj.Key]);
                        break; 
                    case "clownfish":
                        clown.Add((Clownfish)objects[obj.Key]);
                        break; 
                    case "cuttlefish":
                        cuttle.Add((Cuttlefish)objects[obj.Key]);
                        break; 
                    case "flatfish":
                        flat.Add((Flatfish)objects[obj.Key]);
                        break; 
                    case "lancetfish":
                        lancet.Add((Lancetfish)objects[obj.Key]);
                        break; 
                    case "opah":
                        opah.Add((Opah)objects[obj.Key]);
                        break; 
                    case "spermWhale":
                        sperm.Add((SpermWhale)objects[obj.Key]);
                        break; 
                    case "stingray":
                        stingray.Add((Stingray)objects[obj.Key]);
                        break; 
                    case "surgeonfish":
                        surgeon.Add((Surgeonfish)objects[obj.Key]);
                        break; 
                    case "tripodfish":
                        tripod.Add((Tripodfish)objects[obj.Key]);
                        break;
                    default:
                        break; 
                }
            }
        }

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
