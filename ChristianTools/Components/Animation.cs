using System.Collections.Generic;
using ChristianTools.Helpers.Enums_Interfaces_Delegates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Components
{
	public class Animation
	{
		public Rectangle imageFromAtlas;

		public Animation(Rectangle imageFromAtlas)
		{
			this.imageFromAtlas = imageFromAtlas;
		}
	}
}