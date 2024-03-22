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
        }

        private void Update(InputState lastInputState, InputState inputState)
        {
            if (inputState.Mouse_LeftButton_Click)
            {
                System.Console.WriteLine("Mouse World (UI): " + inputState.Mouse_OnWindowPosition());
            }
        }
    }
}