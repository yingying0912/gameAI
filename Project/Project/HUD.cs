using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    class HUD
    {
        Vector2 position, dimension;
        string textLabel, textValue;
        float valueMax, valueCurrent;
        Color textColor;
        int type; 

        public HUD(string textLabel, Vector2 position)
        {
            this.textLabel = textLabel;
            this.position = position;
            type = 0; 
        }

        public HUD(string textLabel, Vector2 position, float valueMax)
        {
            this.textLabel = textLabel;
            this.position = position;
            this.valueMax = valueMax;
            type = 1; 
        }

        public void Update(string textValue, Color textColor)
        {
            this.textValue = textValue;
            this.textColor = textColor;
        }

        public void Update(string textValue, Color textColor, float valueCurrent)
        {
            this.textValue = textValue;
            this.textColor = textColor;
            this.valueCurrent = valueCurrent; 
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont, GraphicsDevice graphicsDevice)
        {
            switch (type)
            {
                case 0: TextHUD(spriteBatch, spriteFont); break; 
                case 1: BarHUD(spriteBatch, spriteFont, graphicsDevice); break; 
                default: break; 
            }
        }

        public void TextHUD(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            spriteBatch.DrawString(spriteFont, textLabel + ": " + textValue, position, textColor); 
        }

        public void BarHUD(SpriteBatch spriteBatch, SpriteFont spriteFont, GraphicsDevice graphicsDevice)
        {
            float percent = valueCurrent / valueMax;

            Color backgroundColor = new Color(0, 0, 0, 128);
            Color barColor = new Color(0, 255, 0, 200);
            if (percent < 0.50)
                barColor = new Color(255, 255, 0, 200);
            if (percent < 0.20)
                barColor = new Color(255, 0, 0, 200);

            Rectangle backgroundRectangle = new Rectangle();
            backgroundRectangle.Width = (int)dimension.X;
            backgroundRectangle.Height = (int)dimension.Y;
            backgroundRectangle.X = (int)position.X;
            backgroundRectangle.Y = (int)position.Y;

            Texture2D dummyTexture = new Texture2D(graphicsDevice, 1, 1);
            dummyTexture.SetData(new Color[] { backgroundColor });

            spriteBatch.Draw(dummyTexture, backgroundRectangle, backgroundColor);

            backgroundRectangle.Width = (int)(dimension.X * 0.9);
            backgroundRectangle.Height = (int)(dimension.Y * 0.5);
            backgroundRectangle.X = (int)position.X + (int)(dimension.X * 0.05);
            backgroundRectangle.Y = (int)position.Y + (int)(dimension.Y * 0.25);

            spriteBatch.Draw(dummyTexture, backgroundRectangle, backgroundColor);

            backgroundRectangle.Width = (int)(dimension.X * 0.9 * percent);
            backgroundRectangle.Height = (int)(dimension.Y * 0.5);
            backgroundRectangle.X = (int)position.X + (int)(dimension.X * 0.05);
            backgroundRectangle.Y = (int)position.Y + (int)(dimension.Y * 0.25);

            dummyTexture = new Texture2D(graphicsDevice, 1, 1);
            dummyTexture.SetData(new Color[] { barColor });

            spriteBatch.Draw(dummyTexture, backgroundRectangle, barColor);
        }
    }
}
