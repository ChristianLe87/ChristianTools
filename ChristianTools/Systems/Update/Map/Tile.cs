using System;
using ChristianTools.Components;
using ChristianTools.Helpers;

namespace ChristianTools.Systems
{
	public partial class Systems
	{
		public partial class Update
		{
			public static void Tile(InputState lastInputState, InputState inputState, ITile tile)
			{
				if (tile.isActive == false)
					return;

				if (tile.dxUpdateSystem != null)
					tile.dxUpdateSystem(lastInputState, inputState);
			}
		}
	}
}