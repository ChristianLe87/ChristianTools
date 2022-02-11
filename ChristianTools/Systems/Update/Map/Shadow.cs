using System;
using ChristianTools.Components;
using ChristianTools.Helpers;

namespace ChristianTools.Systems
{
	public partial class Systems
	{
		public partial class Update
		{
			public static void Shadow(InputState lastInputState, InputState inputState, IShadow shadow)
			{
				if (shadow.isActive == false)
					return;

				if (shadow.dxUpdateSystem != null)
					shadow.dxUpdateSystem(lastInputState, inputState);
			}
		}
	}
}