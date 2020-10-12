using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Project
{
    public class Collision
    {
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
