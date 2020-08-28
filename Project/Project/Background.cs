using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    public class Background
    {
        Texture2D bgTex; 
        string bgName;
        int x, y, height, width;
        float scale; 
        public Vector2 bgSize;

        bool wall = false; 
        bool grid = true; 

        public Background()
        {
            if (wall)
            {
                scale = 10f; 
                bgName = "wbackground";
                bgTex = Game1.Assets[bgName];
                width = Game1.Assets[bgName].Width;
                height = Game1.Assets[bgName].Height;
                x = y = (int)scale;
                bgSize = new Vector2(width * x, height * y);
            }
            if (!wall)
            {
                scale = 5f;
                if (grid) bgName = "backgroundwgrid"; 
                else bgName = "background"; 
                bgTex = Game1.Assets[bgName];
                bgSize = new Vector2(Game1.Assets[bgName].Width * scale, Game1.Assets[bgName].Height * scale); 
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (wall)
            {
                for (int i = 0; i < y; i++)
                    for (int j = 0; j < x; j++)
                        spriteBatch.Draw(bgTex, new Rectangle(width * i, height * j, width, height), Color.White);
            } 
            if (!wall)
                spriteBatch.Draw(bgTex, new Vector2(0,0), scale: new Vector2(5f, 5f)); 
        }
    }
}
