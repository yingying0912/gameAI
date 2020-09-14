using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    class HUD
    {
        private Vector2 position;
        string textLabel;
        private string textValue;
        private Color textColor;

        private bool enabled = true;

        public HUD(string textLabel, Vector2 position)
        {
            this.textLabel = textLabel.ToUpper();
            this.position = position;
        }

        public void Update(string textValue, Color textColor)
        {
            this.textValue = textValue.ToUpper();
            this.textColor = textColor;
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            spriteBatch.DrawString(spriteFont, textLabel + ": " + textValue, position, textColor);
        }
    }
}
