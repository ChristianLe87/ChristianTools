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
            if (inputState.Action == true && lastInputState.Action == false)
            {
                System.Console.WriteLine("Mouse World (UI): " + inputState.mouse.GetOnWindowPosition());
            }
        }
    }
}
