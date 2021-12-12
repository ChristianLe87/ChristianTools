using ChristianTools.Components;
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
        DxOnClickAction OnClickAction;
        Camera camera;

        public Button(Rectangle rectangle, string text, Texture2D defaultTexture, Texture2D mouseOverTexture, SpriteFont spriteFont, string tag, DxOnClickAction OnClickAction, Camera camera)
        {
            this.rectangle = rectangle;
            this.defaultTexture = defaultTexture;
            this.mouseOverTexture = mouseOverTexture;
            this.isMouseOver = false;

            this.label = new Label(rectangle, spriteFont, text, Label.TextAlignment.Midle_Center, tag: "", camera);

            this.tag = tag;

            this.OnClickAction = OnClickAction;
            this.camera = camera ?? new Camera();
        }

        public void Update(InputState inputState, InputState lastInputState)
        {
            Rectangle tempRectangle = new Rectangle((int)(rectangle.X + camera.rectangle.X), (int)(rectangle.Y + camera.rectangle.Y), rectangle.Width, rectangle.Height);
            if (tempRectangle.Contains(inputState.Mouse_Position(camera)))
            {
                isMouseOver = true;
                if (lastInputState.Mouse_LeftButton == ButtonState.Released && inputState.Mouse_LeftButton == ButtonState.Pressed)
                {
                    if (OnClickAction != null)
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
            Rectangle tempRectangle = new Rectangle((int)(rectangle.X + camera.rectangle.X), (int)(rectangle.Y + camera.rectangle.Y), rectangle.Width, rectangle.Height);

            if (isMouseOver)
                spriteBatch.Draw(mouseOverTexture, tempRectangle, Color.White);
            else
                spriteBatch.Draw(defaultTexture, tempRectangle, Color.White);

            label.Draw(spriteBatch);

        }
    }
}