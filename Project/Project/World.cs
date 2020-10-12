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

        public static List<Enemy>    angler     = new List<Enemy>(); 
        public static List<Enemy>    barra      = new List<Enemy>(); 
        public static List<Enemy>    blue       = new List<Enemy>(); 
        public static List<Enemy>    bristle    = new List<Enemy>(); 
        public static List<Enemy>    clown      = new List<Enemy>(); 
        public static List<Enemy>    cuttle     = new List<Enemy>(); 
        public static List<Enemy>    flat       = new List<Enemy>(); 
        public static List<Enemy>    lancet     = new List<Enemy>(); 
        public static List<Enemy>    opah       = new List<Enemy>(); 
        public static List<Enemy>    sperm      = new List<Enemy>(); 
        public static List<Enemy>    stingray   = new List<Enemy>(); 
        public static List<Enemy>    surgeon    = new List<Enemy>(); 
        public static List<Enemy>    tripod     = new List<Enemy>();

        public static List<Enemy>   crab        = new List<Enemy>();
        public static List<Enemy>   jelly       = new List<Enemy>();
        public static List<Enemy>   prawn       = new List<Enemy>();
        public static List<Enemy>   turtle      = new List<Enemy>();

        public static void Sort()
        {
            foreach (var obj in objects)
            {
                switch (obj.Value.name)
                {
                    case "anglerfish":
                        angler.Add((Anglerfish)obj.Value);
                        break;
                    case "barracudina":
                        barra.Add((Barracudina)obj.Value);
                        break;
                    case "blueWhale":
                        blue.Add((BlueWhale)obj.Value);
                        break;
                    case "bristlemouth":
                        bristle.Add((Bristlemouth)obj.Value);
                        break;
                    case "clownfish":
                        clown.Add((Clownfish)obj.Value);
                        break;
                    case "cuttlefish":
                        cuttle.Add((Cuttlefish)obj.Value);
                        break;
                    case "flatfish":
                        flat.Add((Flatfish)obj.Value);
                        break;
                    case "lancetfish":
                        lancet.Add((Lancetfish)obj.Value);
                        break;
                    case "opah":
                        opah.Add((Opah)obj.Value);
                        break;
                    case "spermWhale":
                        sperm.Add((SpermWhale)obj.Value);
                        break;
                    case "stingray":
                        stingray.Add((Stingray)obj.Value);
                        break;
                    case "surgeonfish":
                        surgeon.Add((Surgeonfish)obj.Value);
                        break;
                    case "tripodfish":
                        tripod.Add((Tripodfish)obj.Value);
                        break;
                    case "crab":
                        crab.Add((Crab)obj.Value);
                        break;
                    case "jellyfish":
                        jelly.Add((Jellyfish)obj.Value);
                        break;
                    case "prawn":
                        prawn.Add((Prawn)obj.Value);
                        break;
                    case "turtle":
                        turtle.Add((Turtle)obj.Value);
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

        public static void Reset()
        {
            foreach (var obj in objects)
            {
                if (obj.Key != "player" && obj.Key != "bg")
                    objects[obj.Key].position -= worldPosition;
            }
            objects["bg"].position = Vector2.Zero;
        }
    }
}
