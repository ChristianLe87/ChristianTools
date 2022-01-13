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


				if(ui.tag == "coin")
                {
					int bla = 0;
                }
				if (ui.dxUiUpdateSystem != null)
                {
					ui.dxUiUpdateSystem(lastInputState, inputState);
                }
                else
                {

                }
			}
		}
	}
}