using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    class HUD
    {
        Vector2 position, dimension, desPos;
        string textLabel, textValue, textDescription;
        float valueMax, valueCurrent;
        Color textColor;
        int type; 

        public HUD(string textLabel, Vector2 position)
        {
            this.textLabel = textLabel;
            this.position = position;
            type = 0; 
        }
        
        public HUD(string textLabel, Vector2 position, Vector2 dimension, float valueMax)
        {
            this.textLabel = textLabel; 
            this.position = position;
            this.dimension = dimension;
            this.valueMax = valueMax;
            textColor = new Color(255, 255, 255);
            type = 1; 
        }

        public HUD()
        {
            textLabel = "Pause";
            textDescription = "Right click to resume";
            textColor = new Color(255, 255, 255);
            position = new Vector2(Game1.Screen.ClientBounds.Width / 2, Game1.Screen.ClientBounds.Height / 2);
            desPos = new Vector2(Game1.Screen.ClientBounds.Width / 2, Game1.Screen.ClientBounds.Height / 2 + 55);
            dimension = new Vector2(850, 100);
            type = 2;
        }

        public HUD(string textLabel)
        {
            this.textLabel = "You " + textLabel;
            textDescription = "Press Enter to replay";
            textColor = new Color(255, 255, 255);
            position = new Vector2(Game1.Screen.ClientBounds.Width / 2, Game1.Screen.ClientBounds.Height / 2);
            desPos = new Vector2(Game1.Screen.ClientBounds.Width / 2, Game1.Screen.ClientBounds.Height / 2 + 55);
            dimension = new Vector2(850, 100);
            type = 3; 
        }

        public void Update(string textValue, Color textColor)
        {
            this.textValue = textValue;
            this.textColor = textColor;
        }

        public void Update(float valueCurrent)
        {
            this.valueCurrent = valueCurrent;
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
                case 2: PauseHUD(spriteBatch, spriteFont, graphicsDevice); break;
                case 3: EndHUD(spriteBatch, spriteFont, graphicsDevice); break;
                default: break; 
            }
        }

        public void TextHUD(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            spriteBatch.DrawString(spriteFont, textLabel + ": " + textValue, position, textColor); 
        }

        public void BarHUD(SpriteBatch spriteBatch, SpriteFont spriteFont, GraphicsDevice graphicsDevice)
        {
            //spriteBatch.DrawString(spriteFont, textLabel + ": ", position, textColor);

            float percent = valueCurrent / valueMax;

            Color backgroundColor = new Color(0, 0, 0, 128);
            Color barColor = new Color( 0, 255, 0, 200);
            Color barColor2 = new Color(100, 100, 200, 200);

            Rectangle backgroundRectangle = new Rectangle();
            Texture2D dummyTexture = new Texture2D(graphicsDevice, 1, 1);

            dummyTexture.SetData(new Color[] { backgroundColor });
            backgroundRectangle.Width = (int)dimension.X / 5;
            backgroundRectangle.Height = (int)dimension.Y;
            //backgroundRectangle.Y = 13 + (int)position.Y;
            backgroundRectangle.Y = (int)position.Y;
            for (int i = 0; i < valueMax; i++)
            {
                //backgroundRectangle.X = (int)(position.X + 180 + dimension.X / 4.5 * i);
                backgroundRectangle.X = (int)(position.X + dimension.X / 4.5 * i);
                spriteBatch.Draw(dummyTexture, backgroundRectangle, backgroundColor);
            }

            dummyTexture.SetData(new Color[] { barColor });
            backgroundRectangle.Width = (int)(dimension.X / 6);
            backgroundRectangle.Height = (int)(dimension.Y * 0.5);
            //backgroundRectangle.Y = 13 + (int)position.Y + (int)(dimension.Y * 0.25);
            backgroundRectangle.Y = (int)position.Y + (int)(dimension.Y * 0.25);
            for (int i = 0; i < valueCurrent; i++)
            {
                //backgroundRectangle.X = (int)(position.X + 180 + dimension.X / 60) + (int)(dimension.X / 4.5 * i);
                backgroundRectangle.X = (int)(position.X + dimension.X / 60) + (int)(dimension.X / 4.5 * i);
                spriteBatch.Draw(dummyTexture, backgroundRectangle, barColor);
            }

            backgroundRectangle.Width = (int)(dimension.X * 0.75);
            backgroundRectangle.Height = (int)(dimension.Y * 1.5);
            backgroundRectangle.X = (int)position.X;
            backgroundRectangle.Y = (int)position.Y + 55;
            spriteBatch.Draw(dummyTexture, backgroundRectangle, backgroundColor);
        }

        public void PauseHUD(SpriteBatch spriteBatch, SpriteFont spriteFont, GraphicsDevice graphicsDevice)
        {
            Rectangle backgroundRectangle = new Rectangle();
            Color backgroundColor = new Color(0, 0, 0, 128);
            Texture2D dummyTexture = new Texture2D(graphicsDevice, 1, 1);
            dummyTexture.SetData(new Color[] { backgroundColor });

            spriteBatch.DrawString(spriteFont, textLabel, position, textColor);
            spriteBatch.DrawString(spriteFont, textDescription, desPos, textColor);

            backgroundRectangle.Width = (int)(dimension.X * 0.75);
            backgroundRectangle.Height = (int)(dimension.Y * 1.5);
            backgroundRectangle.X = Game1.Screen.ClientBounds.Width / 2 - 5;
            backgroundRectangle.Y = Game1.Screen.ClientBounds.Height / 2;
            spriteBatch.Draw(dummyTexture, backgroundRectangle, backgroundColor);
        }

        public void EndHUD(SpriteBatch spriteBatch, SpriteFont spriteFont, GraphicsDevice graphicsDevice)
        {
            Rectangle backgroundRectangle = new Rectangle();
            Color backgroundColor = new Color(0, 0, 0, 128);
            Texture2D dummyTexture = new Texture2D(graphicsDevice, 1, 1);
            dummyTexture.SetData(new Color[] { backgroundColor });

            spriteBatch.DrawString(spriteFont, textLabel, position, textColor);
            spriteBatch.DrawString(spriteFont, textDescription, desPos, textColor);

            backgroundRectangle.Width = (int)(dimension.X * 0.75);
            backgroundRectangle.Height = (int)(dimension.Y * 1.5);
            backgroundRectangle.X = Game1.Screen.ClientBounds.Width / 2 - 5;
            backgroundRectangle.Y = Game1.Screen.ClientBounds.Height / 2;
            spriteBatch.Draw(dummyTexture, backgroundRectangle, backgroundColor);
        }
    }
}
