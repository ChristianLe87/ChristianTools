using ChristianTools.Helpers;
using ChristianTools.Helpers.Enums_Interfaces_Delegates;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Systems
{
	public partial class Update
	{
		public static void UI(Viewport viewport, InputState lastInputState, InputState inputState, IScene scene, IUI ui)
		{
			if (ui.isActive == false)
				return;

			if (ui.dxUpdateSystem != null)
				ui.dxUpdateSystem(viewport, lastInputState, inputState, scene);
		}
	}
}