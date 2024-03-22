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
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
        public bool isActive { get; set; }


        public Texture2D texture { get; }

        public delegate void DxOnClickAction();

        DxOnClickAction OnClickAction;

        public Button(Rectangle rectangle, string text, DxOnClickAction OnClickAction, string tag = "", Texture2D defaultTexture = null, Texture2D mouseOverTexture = null, bool isActive = true)
        {
            this.rectangle = rectangle;
            this.defaultTexture = defaultTexture ?? ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray);
            this.mouseOverTexture = mouseOverTexture ?? ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray);
            this.isMouseOver = false;

            this.label = new Label(rectangle, text, Label.TextAlignment.Midle_Center, tag: "");

            this.tag = tag;

            this.OnClickAction = OnClickAction;


            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem(lastInputState, inputState);
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
            this.isActive = isActive;
        }

        private void UpdateSystem(InputState lastInputState, InputState inputState)
        {
         
            if (rectangle.Contains(inputState.Mouse_OnWindowPosition()))
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
            if (isMouseOver)
                spriteBatch.Draw(mouseOverTexture, rectangle, Color.White);
            else
                spriteBatch.Draw(defaultTexture, rectangle, Color.White);


            label.dxCustomDrawSystem(spriteBatch);
        }
    }
}