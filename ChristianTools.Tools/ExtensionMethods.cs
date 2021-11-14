using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Tools
{
    internal static class ExtensionMethods
    {
        internal static Rectangle Create(this Rectangle rectangle, Point centerPoint, int Width, int Height)
        {
            rectangle.X = centerPoint.X - (Width / 2);
            rectangle.Y = centerPoint.Y - (Height / 2);
            rectangle.Width = Width;
            rectangle.Height = Height;

            return rectangle;
        }

        internal static Rectangle Create(this Rectangle rectangle, Point centerPoint, Texture2D texture2D)
            => Create(rectangle, centerPoint, texture2D.Width, texture2D.Height);

        internal static Rectangle Create(this Rectangle rectangle, float X, float Y, float Width, float Height)
            => new Rectangle((int)X, (int)Y, (int)Width, (int)Height);
    }
}
