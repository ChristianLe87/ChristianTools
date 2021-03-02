using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace zUI
{
    public class Dialogue
    {
        Texture2D background;
        Point centerPosition;
        Label[] labels;
        int labelCount;
        bool isActive;
        KeyboardState previousKeyboardState;

        Rectangle rectangle { get => new Rectangle(centerPosition.X - (background.Width / 2), centerPosition.Y - (background.Height / 2), background.Width, background.Height); }

        public Dialogue(string[] texts, Point centerPosition, Texture2D background, SpriteFont spriteFont, bool isActive = true)
        {
            this.background = background;
            this.centerPosition = centerPosition;
            this.labelCount = 0;
            this.isActive = isActive;
            this.labels = texts.Select(text =>  new Label(rectangle, spriteFont, text, Label.TextAlignment.Midle_Left, Color.Pink)).ToArray();
        }

        public void Update()
        {
            if (isActive == false) return;

            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.P) && previousKeyboardState.IsKeyUp(Keys.P))
            {
                labelCount++;

                if (labelCount >= labels.Length)
                {
                    isActive = false;
                    labelCount = 0;
                }
            }

            previousKeyboardState = keyboardState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isActive == false) return;

            spriteBatch.Draw(background, rectangle, Color.White);
            labels[labelCount].Draw(spriteBatch);
        }

        public void SetActiveState(bool isActive)
        {
            this.isActive = isActive;
        }
    }
}
