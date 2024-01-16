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

        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }

        public Texture2D texture { get; }

        public delegate void DxOnClickAction();

        DxOnClickAction OnClickAction;

        public Button(Rectangle rectangle, string text, DxOnClickAction OnClickAction, string tag = "", Texture2D defaultTexture = null, Texture2D mouseOverTexture = null)
        {
            this.rectangle = rectangle;
            this.defaultTexture = defaultTexture ?? ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray);
            this.mouseOverTexture = mouseOverTexture ?? ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray);
            this.isMouseOver = false;

            this.label = new Label(rectangle, text, Label.TextAlignment.Midle_Center, tag: "");

            this.tag = tag;

            this.OnClickAction = OnClickAction;


            this.dxUpdateSystem = (InputState lastInputState, InputState inputState, IScene scene) => UpdateSystem(lastInputState, inputState, scene);
            this.dxDrawSystem = (SpriteBatch spriteBatch, IScene scene) => DrawSystem(spriteBatch, scene);
            this.isActive = true;
        }

        private void UpdateSystem(InputState lastInputState, InputState inputState, IScene scene)
        {
            Rectangle tempRectangle;
            if (scene.camera != null)
                tempRectangle = new Rectangle((int)(rectangle.X + scene.camera.rectangle.X),
                    (int)(rectangle.Y + scene.camera.rectangle.Y), rectangle.Width, rectangle.Height);
            else
                tempRectangle = rectangle;

            if (tempRectangle.Contains(inputState.Mouse_Position()))
            {
                isMouseOver = true;
                if (lastInputState.Mouse_LeftButton == ButtonState.Released &&
                    inputState.Mouse_LeftButton == ButtonState.Pressed)
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

        private void DrawSystem(SpriteBatch spriteBatch, IScene scene)
        {
            Rectangle tempRectangle;
            if (scene.camera != null)
                tempRectangle = new Rectangle((int)(rectangle.X + scene.camera.rectangle.X),
                    (int)(rectangle.Y + scene.camera.rectangle.Y), rectangle.Width, rectangle.Height);
            else
                tempRectangle = rectangle;

            if (isMouseOver)
                spriteBatch.Draw(mouseOverTexture, tempRectangle, Color.White);
            else
                spriteBatch.Draw(defaultTexture, tempRectangle, Color.White);


            label.dxDrawSystem(spriteBatch, scene);
        }
    }
}