using System;
using ChristianTools.Components;
using ChristianTools.Helpers;

namespace ChristianTools.Systems
{
	public partial class Systems
	{
		public partial class Update
		{
			public static void Light(InputState lastInputState, InputState inputState, ILight light)
			{
				if (light.isActive == false)
					return;

				if (light.dxUpdateSystem != null)
					light.dxUpdateSystem(lastInputState, inputState);
			}
		}
	}
}