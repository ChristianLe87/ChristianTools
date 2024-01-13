using ChristianTools.Helpers;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Systems
{
    public partial class Update
    {
        public static void UI(InputState lastInputState, InputState inputState, IScene scene, IUI ui)
        {
            if (ui.isActive == false)
                return;

            if (ui.dxUpdateSystem != null)
                ui.dxUpdateSystem(lastInputState, inputState, scene);
        }
    }
}