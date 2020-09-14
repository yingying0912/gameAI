using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    class HUD
    {
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        private GraphicsDevice graphicsDevice;

        private Vector2 position;

        private String textLabel;
        private String textValue = "test";
        private Color textColor = new Color(0, 0, 0, 127);

        private bool enabled = true;

        /// Creates a new TextComponent for the HUD.
        /// </summary>
        /// <param name="textLabel">Label text that is displayed before ":".</param>
        /// <param name="position">Component position on the screen.</param>
        /// <param name="spriteBatch">SpriteBatch that is required to draw the sprite.</param>
        /// <param name="spriteFont">Font that will be used to display the text.</param>
        /// <param name="graphicsDevice">Graphicsdevice that is required to create the semi transparent background texture.</param>
        public HUD(String textLabel, Vector2 position, SpriteBatch spriteBatch, SpriteFont spriteFont, GraphicsDevice graphicsDevice)
        {
            this.textLabel = textLabel.ToUpper();
            this.position = position;

            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            this.graphicsDevice = graphicsDevice;
        }
        
        /// <summary>
        /// Sets whether the component should be drawn.
        /// </summary>
        /// <param name="enabled">enable the component</param>
        public void Enable(bool enabled)
        {
            this.enabled = enabled;
        }

        /// <summary>
        /// Updates the text that is displayed after ":".
        /// </summary>
        /// <param name="textValue">Text to be displayed.</param>
        /// <param name="textColor">Text color.</param>
        public void Update(String textValue, Color textColor)
        {
            this.textValue = "test";//textValue.ToUpper();
            this.textColor = textColor;
        }

        /// <summary>
        /// Draws the TextComponent with the values set before.
        /// </summary>
        public void Draw()
        {
            if (enabled)
            {
                /*
                Color myTransparentColor = new Color(0, 0, 0, 127);

                Vector2 stringDimensions = spriteFont.MeasureString(textLabel + ": " + textValue);
                float width = stringDimensions.X;
                float height = stringDimensions.Y;

                Rectangle backgroundRectangle = new Rectangle();
                backgroundRectangle.Width = (int)width + 10;
                backgroundRectangle.Height = (int)height + 10;
                backgroundRectangle.X = (int)position.X - 5;
                backgroundRectangle.Y = (int)position.Y - 5;

                Texture2D dummyTexture = new Texture2D(graphicsDevice, 1, 1);
                dummyTexture.SetData(new Color[] { myTransparentColor });

                spriteBatch.Draw(dummyTexture, backgroundRectangle, myTransparentColor);
                */
                spriteBatch.DrawString(spriteFont, textLabel + ": " + textValue, position, textColor);
            }
        }
    }
}
