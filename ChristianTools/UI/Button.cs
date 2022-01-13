using System;
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
        public bool isActive { get; set; }

        public DxUiInitializeSystem dxUiInitializeSystem { get; }
        public DxUiUpdateSystem dxUiUpdateSystem { get; }
        public DxUiDrawSystem dxUiDrawSystem { get; }

        public Texture2D texture { get; }

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

            this.dxUiUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem(lastInputState, inputState);
            this.dxUiDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
            this.isActive = true;
        }

        private void UpdateSystem(InputState lastInputState, InputState inputState)
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

        private void DrawSystem(SpriteBatch spriteBatch)
        {
            Rectangle tempRectangle = new Rectangle((int)(rectangle.X + camera.rectangle.X), (int)(rectangle.Y + camera.rectangle.Y), rectangle.Width, rectangle.Height);

            if (isMouseOver)
                spriteBatch.Draw(mouseOverTexture, tempRectangle, Color.White);
            else
                spriteBatch.Draw(defaultTexture, tempRectangle, Color.White);


            label.dxUiDrawSystem(spriteBatch);
        }
    }
}