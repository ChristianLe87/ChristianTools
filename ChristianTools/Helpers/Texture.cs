using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Helpers
{
    public partial class Texture
	{
		public static Texture2D GetTextureFromFile(GraphicsDevice graphicsDevice, string imageName, int scaleFactor = 1)
		{
			///Remember: First compile project, it will generate a "bin" folder inside default "Content" folder, then, manualy add the files (Just copy and paste)
			/// Will not be necessary to change properties of each file
			/// /Users/christianlehnhoff/Repositories/GitHub/ChristianLe87/MonoGame/MyCoolGame/CrossPlatform/Content/bin/Android/Content/Tree.png
			/// --> Remember to add the file to not ignore on Git


			// For iOS, always set Poroperties to "always copy" and use this
			if (System.OperatingSystem.IsIOS()) imageName = Path.Combine("bin", "iOS", "Content", imageName);

			string absolutePath = Path.Combine("Content" /*Helpers.ChristianGame.contentManager.RootDirectory*/, $"{imageName}.png");
			using (var stream = TitleContainer.OpenStream(absolutePath))
			{
				Texture2D result = Texture2D.FromStream(graphicsDevice, stream);
				return ScaleTexture(graphicsDevice, result, scaleFactor);
			}
		}

		public static Texture2D ScaleTexture(GraphicsDevice graphicsDevice, Texture2D originalTexture, int scaleFactor)
		{
			Color[] originalColors = new Color[originalTexture.Width * originalTexture.Height];
			originalTexture.GetData(0, new Rectangle(0, 0, originalTexture.Width, originalTexture.Height), originalColors, 0, (originalTexture.Width * originalTexture.Height));

			Color[,] multidimentionalColors = Helpers.Other.ToMultidimentional<Color>(originalColors, originalTexture.Width, originalTexture.Height);

			Color[,] expandedColors = Helpers.Other.Expand<Color>(multidimentionalColors, scaleFactor);

			Color[] flatResult = Helpers.Other.FlattenArray<Color>(expandedColors);

			Texture2D newTexture2D = new Texture2D(graphicsDevice, originalTexture.Width * scaleFactor, originalTexture.Height * scaleFactor, false, SurfaceFormat.Color);
			newTexture2D.SetData(flatResult);

			return newTexture2D;
		}
		
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