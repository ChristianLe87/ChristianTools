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

        public DxUpdateSystem dxUpdateSystem { get; }
        public DxDrawSystem dxDrawSystem { get; }

        public Texture2D texture { get; }

        public delegate void DxOnClickAction();
        DxOnClickAction OnClickAction;

        public Button(Rectangle rectangle, string text, Texture2D defaultTexture, Texture2D mouseOverTexture, SpriteFont spriteFont, string tag, DxOnClickAction OnClickAction)
        {

            this.rectangle = rectangle;
            this.defaultTexture = defaultTexture;
            this.mouseOverTexture = mouseOverTexture;
            this.isMouseOver = false;

            this.label = new Label(rectangle, spriteFont, text, Label.TextAlignment.Midle_Center, tag: "");

            this.tag = tag;

            this.OnClickAction = OnClickAction;
            

            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem(lastInputState, inputState);
            this.dxDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
            this.isActive = true;
        }

        private void UpdateSystem(InputState lastInputState, InputState inputState)
        {
            Rectangle tempRectangle;
            if (ChristianGame.GetScene.camera != null)
                tempRectangle = new Rectangle((int)(rectangle.X + ChristianGame.GetScene.camera.rectangle.X), (int)(rectangle.Y + ChristianGame.GetScene.camera.rectangle.Y), rectangle.Width, rectangle.Height);
            else
                tempRectangle = rectangle;

            if (tempRectangle.Contains(inputState.Mouse_Position()))
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
            Rectangle tempRectangle;
            if (ChristianGame.GetScene.camera != null)
                tempRectangle = new Rectangle((int)(rectangle.X + ChristianGame.GetScene.camera.rectangle.X), (int)(rectangle.Y + ChristianGame.GetScene.camera.rectangle.Y), rectangle.Width, rectangle.Height);
            else
                tempRectangle = rectangle;

            if (isMouseOver)
                spriteBatch.Draw(mouseOverTexture, tempRectangle, Color.White);
            else
                spriteBatch.Draw(defaultTexture, tempRectangle, Color.White);


            label.dxDrawSystem(spriteBatch);
        }
    }
}