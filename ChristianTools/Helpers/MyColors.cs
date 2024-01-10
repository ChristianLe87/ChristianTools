using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Showroom_CrossPlatform;

namespace ChristianTools.Helpers
{
	public class MyColors
	{
		/// <summary>
		/// Create a new Texture2D from a Color
		/// </summary>
		public static Texture2D CreateColorTexture(Color color, int Width = 1, int Height = 1)
		{
			Texture2D texture2D = new Texture2D(ChristianGame.graphicsDeviceManager.GraphicsDevice, Width, Height, false, SurfaceFormat.Color);
			Color[] colors = new Color[Width * Height];

			// Set each pixel to color
			colors = colors
				.Select(x => x = color)
				.ToArray();

			texture2D.SetData(colors);

			return texture2D;
		}
	}
}