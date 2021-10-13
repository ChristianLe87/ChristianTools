using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace My_EasyTests
{
    public class Tools
    {
        /// <summary>
        /// Create a new Texture2D from a Color
        /// </summary>
        public static Texture2D CreateColorTexture(GraphicsDevice graphicsDevice, Color color, int Width = 1, int Height = 1)
        {
            Texture2D texture2D = new Texture2D(graphicsDevice, Width, Height, false, SurfaceFormat.Color);
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
