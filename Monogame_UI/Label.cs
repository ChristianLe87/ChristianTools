using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame_UI
{
    public class Label
    {
        SpriteFont spriteFont;
        string text;
        Texture2D texture2D;
        Rectangle rectangle;
        TextAlignment textAlignment;

        public Label(Rectangle rectangle, SpriteFont spriteFont, string text, TextAlignment textAlignment, Texture2D texture = null)
        {
            this.rectangle = rectangle;
            this.spriteFont = spriteFont;
            this.text = text;
            this.texture2D = texture;
            this.textAlignment = textAlignment;
        }

        public void Update(string text = null)
        {
            if (text != null)
                this.text = text;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(texture2D != null)
                spriteBatch.Draw(texture2D, rectangle, Color.White);


            int PosCenter_X = (rectangle.Width / 2) + (rectangle.X) - ((int)spriteFont.MeasureString(text).X / 2);
            int PosCenter_Y = (
                            rectangle.Center.Y -
                            ((int)spriteFont.MeasureString(text).Y) / 2
                            );
            int PosLeft = rectangle.X;


            Vector2 textPosition;

            switch (textAlignment)
            {
                case TextAlignment.Top_Center:
                    textPosition = new Vector2(PosCenter_X, rectangle.Y);
                    break;
                case TextAlignment.Midle_Center:
                    textPosition = new Vector2(PosCenter_X, PosCenter_Y);
                    break;
                default:
                    textPosition = new Vector2(rectangle.X, rectangle.Y);
                    break;
            };
            spriteBatch.DrawString(spriteFont, text, textPosition, Color.White);
        }

        public enum TextAlignment
        {
            Top_Center,
            Midle_Center,
            Down_Center,

            Top_Left,
            Midle_Left,
            Down_Left,

            Top_Right,
            Midle_Right,
            Down_Right,
        }
    }
}
