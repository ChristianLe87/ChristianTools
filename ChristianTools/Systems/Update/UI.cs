using System;
using ChristianTools.Helpers;

namespace ChristianTools.Systems
{
	public partial class Systems
	{
		public partial class Update
		{
			public static void UI(InputState lastInputState, InputState inputState, IUI ui)
			{
				if (ui.isActive == false)
					return;

				if (ui.dxUpdateSystem != null)
					ui.dxUpdateSystem(lastInputState, inputState);
			}
		}
	}
}