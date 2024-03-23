using ChristianTools.Helpers;
using ChristianTools.Helpers.Hybrids;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Entities
{
    public class ZeroZeroPoint_Entity : ZeroZeroPoint, IEntity
    {
        public ZeroZeroPoint_Entity()
        {
            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => Update(lastInputState, inputState);
        }

        private void Update(InputState lastInputState, InputState inputState)
        {
            if (inputState.Action == true && lastInputState.Action == false)
            {
                System.Console.WriteLine("Mouse World (Entity): " + inputState.mouse.GetOnWorldPosition());
            }
        }
    }
}
