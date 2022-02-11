using System.Linq;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChristianTools.UI
{
    public class Dialogue : IUI
    {
        public Texture2D texture { get; }
        Point centerPosition;
        Label[] labels;
        int labelCount;
        InputState previousinputState;
        public Rectangle rectangle { get => new Rectangle(centerPosition.X - (texture.Width / 2), centerPosition.Y - (texture.Height / 2), texture.Width, texture.Height); }

        public string tag => throw new System.NotImplementedException();
        public bool isActive { get; set; }

        public DxUpdateSystem dxUpdateSystem { get; }
        public DxDrawSystem dxDrawSystem { get; }

        public Dialogue(string[] texts, Point centerPosition, Texture2D background, SpriteFont spriteFont, bool isActive = true)
        {
            this.texture = background;
            this.centerPosition = centerPosition;
            this.labelCount = 0;
            this.isActive = isActive;
            this.labels = texts.Select(text => new Label(rectangle, spriteFont, text, Label.TextAlignment.Midle_Left, tag: "")).ToArray();

            //this.dxUiUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem(lastInputState, inputState);
            this.dxDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
        }

        private void DrawSystem(SpriteBatch spriteBatch)
        {
            if (isActive == false) return;

            spriteBatch.Draw(texture, rectangle, Color.White);
            labels[labelCount].dxDrawSystem(spriteBatch);
        }

        public void SetActiveState(bool isActive)
        {
            this.isActive = isActive;
        }

        public void UpdateText()
        {
            if (isActive == false)
                return;

            InputState inputState = new InputState();
            if (inputState.IsKeyboardKeyDown(Keys.P) && previousinputState.IsKeyboardKeyUp(Keys.P))
            {
                labelCount++;

                if (labelCount >= labels.Length)
                {
                    isActive = false;
                    labelCount = 0;
                }
            }

            previousinputState = inputState;
        }
    }
}