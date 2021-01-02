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

        public Label(Rectangle rectangle, SpriteFont spriteFont, string text, TextAlignment textAlignment, Texture2D texture = null, int lineSpacing = 10)
        {
            this.rectangle = rectangle;
            this.spriteFont = spriteFont;
            this.text = text;
            this.texture2D = texture;
            this.textAlignment = textAlignment;

            this.spriteFont.LineSpacing = lineSpacing;
        }

        public void Update(string text = null)
        {
            if (text != null)
                this.text = text;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture2D != null)
                spriteBatch.Draw(texture2D, rectangle, Color.White);


            int PosLeft_X = rectangle.X;
            int PosCenter_X = (rectangle.Width / 2) + (rectangle.X) - ((int)spriteFont.MeasureString(text).X / 2);
            int PosRight_X = rectangle.X + rectangle.Width - (int)spriteFont.MeasureString(text).X;

            int PosTop_Y = rectangle.Y;
            int PosMiddle_Y = rectangle.Center.Y - (((int)spriteFont.MeasureString(text).Y) / 2);
            int PosDown_Y = rectangle.Y + rectangle.Height - ((int)spriteFont.MeasureString(text).Y);




            Vector2 textPosition;

            switch (textAlignment)
            {
                // Left
                case TextAlignment.Top_Left:
                    textPosition = new Vector2(PosLeft_X, PosTop_Y);
                    break;
                case TextAlignment.Midle_Left:
                    textPosition = new Vector2(PosLeft_X, PosMiddle_Y);
                    break;
                case TextAlignment.Down_Left:
                    textPosition = new Vector2(PosLeft_X, PosDown_Y);
                    break;

                // Center
                case TextAlignment.Top_Center:
                    textPosition = new Vector2(PosCenter_X, PosTop_Y);
                    break;
                case TextAlignment.Midle_Center:
                    textPosition = new Vector2(PosCenter_X, PosMiddle_Y);
                    break;
                case TextAlignment.Down_Center:
                    textPosition = new Vector2(PosCenter_X, PosDown_Y);
                    break;

                // Right
                case TextAlignment.Top_Right:
                    textPosition = new Vector2(PosRight_X, PosTop_Y);
                    break;
                case TextAlignment.Midle_Right:
                    textPosition = new Vector2(PosRight_X, PosMiddle_Y);
                    break;
                case TextAlignment.Down_Right:
                    textPosition = new Vector2(PosRight_X, PosDown_Y);
                    break;
                default:
                    textPosition = new Vector2();
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
