using ChristianTools.Helpers;
using ChristianTools.Helpers.Hybrids;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.UI
{
    public class ZeroZeroPoint_UI: ZeroZeroPoint, IUI
    {
        public ZeroZeroPoint_UI()
        {
            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => Update(lastInputState, inputState);
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => Draw(spriteBatch);
        }

        private void Update(InputState lastInputState, InputState inputState)
        {
            if (inputState.Mouse_LeftButton_Click)
            {
                System.Console.WriteLine("Mouse World (UI): " + inputState.Mouse_OnWindowPosition());
            }
        }

        private void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D_X, new Rectangle(-texture2D_X.Width / 2, -texture2D_X.Height / 2, texture2D_X.Width, texture2D_X.Height), Color.White);
            spriteBatch.Draw(texture2D_Y, new Rectangle(-texture2D_Y.Width / 2, -texture2D_Y.Height / 2, texture2D_Y.Width, texture2D_Y.Height), Color.White);
        }
    }
}