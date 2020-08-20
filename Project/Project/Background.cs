using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    public class Background
    {
        Texture2D bgTex; 
        string bgName;
        int x, y, height, width;
        public Vector2 bgSize;

        public Background()
        {
            bgName = "background";
            bgTex = Game1.Assets[bgName];
            width = Game1.Assets[bgName].Width;
            height = Game1.Assets[bgName].Height;
            x = y = 5;
            bgSize = new Vector2(width * x, height * y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0 ; i < 2*y; i++)
                for (int j = 0; j < 2*x; j++)
                    spriteBatch.Draw(bgTex, new Rectangle(width * i, height * j, width, height), Color.White);
        }
    }
}
