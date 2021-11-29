using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.UI
{
    public class Label : IUI
    {
        SpriteFont spriteFont;
        string text;
        Texture2D texture2D;
        Vector2 textPosition;
        TextAlignment textAlignment;
        Camera camera;

        public Rectangle rectangle { get; }

        public string tag { get; }

        public Label(Rectangle rectangle, SpriteFont spriteFont, string text, TextAlignment textAlignment, string tag, Camera camera, Texture2D texture = null, int lineSpacing = 10)
        {
            this.rectangle = rectangle;
            this.spriteFont = spriteFont;
            this.text = text;
            this.texture2D = texture;
            this.textAlignment = textAlignment;
            this.spriteFont.LineSpacing = lineSpacing;
            this.textPosition = GetTextPosition();
            this.tag = tag;
            this.camera = camera;
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture2D != null)
                spriteBatch.Draw(texture2D, new Rectangle((int)(rectangle.X + camera.center.X), (int)(rectangle.Y + camera.center.Y), rectangle.Width, rectangle.Height), Color.White);


            if(camera != null)
                spriteBatch.DrawString(spriteFont, text, textPosition + camera.center, Color.White);
        }

        private Vector2 GetTextPosition()
        {
            int PosLeft_X = rectangle.X;
            int PosCenter_X = (rectangle.Width / 2) + (rectangle.X) - ((int)spriteFont.MeasureString(text).X / 2);
            int PosRight_X = rectangle.X + rectangle.Width - (int)spriteFont.MeasureString(text).X;

            int PosTop_Y = rectangle.Y;
            int PosMiddle_Y = rectangle.Center.Y - (((int)spriteFont.MeasureString(text).Y) / 2);
            int PosDown_Y = rectangle.Y + rectangle.Height - ((int)spriteFont.MeasureString(text).Y);

            return textAlignment switch
            {
                // Left
                TextAlignment.Top_Left => new Vector2(PosLeft_X, PosTop_Y),
                TextAlignment.Midle_Left => new Vector2(PosLeft_X, PosMiddle_Y),
                TextAlignment.Down_Left => new Vector2(PosLeft_X, PosDown_Y),

                // Center
                TextAlignment.Top_Center => new Vector2(PosCenter_X, PosTop_Y),
                TextAlignment.Midle_Center => new Vector2(PosCenter_X, PosMiddle_Y),
                TextAlignment.Down_Center => new Vector2(PosCenter_X, PosDown_Y),

                // Right
                TextAlignment.Top_Right => new Vector2(PosRight_X, PosTop_Y),
                TextAlignment.Midle_Right => new Vector2(PosRight_X, PosMiddle_Y),
                TextAlignment.Down_Right => new Vector2(PosRight_X, PosDown_Y),
                _ => new Vector2(),
            };
        }

        public void UpdateText(string text = null)
        {
            if (text != null)
                this.text = text;
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