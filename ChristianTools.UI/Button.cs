using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChristianTools.UI
{
    public class Button : IUI
    {
        Texture2D defaultTexture;
        Texture2D mouseOverTexture;
        bool isMouseOver;
        Label label;

        public Rectangle rectangle { get; }
        public string tag { get; }

        public delegate void DxOnClickAction();

        public Button(Rectangle rectangle, string text, Texture2D defaultTexture, Texture2D mouseOverTexture, SpriteFont spriteFont, Color fontColor, string tag)
        {
            this.rectangle = rectangle;
            this.defaultTexture = defaultTexture;
            this.mouseOverTexture = mouseOverTexture;
            this.isMouseOver = false;

            this.label = new Label(rectangle, spriteFont, text, Label.TextAlignment.Midle_Center, fontColor, tag: "");

            this.tag = tag;
        }

        public void Update(InputState inputState, InputState lastInputState, DxOnClickAction OnClickAction)
        {
            if (rectangle.Contains(inputState.Mouse_Position))
            {
                isMouseOver = true;
                if (lastInputState.Mouse_LeftButton == ButtonState.Released && inputState.Mouse_LeftButton == ButtonState.Pressed)
                {
                    OnClickAction();
                }
            }
            else
            {
                isMouseOver = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isMouseOver)
                spriteBatch.Draw(mouseOverTexture, rectangle, Color.White);
            else
                spriteBatch.Draw(defaultTexture, rectangle, Color.White);

            label.Draw(spriteBatch);
        }
    }
}