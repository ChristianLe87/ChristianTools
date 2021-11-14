using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Tools
{
    public static class ExtensionMethods
    {
        public static Rectangle Create(this Rectangle rectangle, Point centerPoint, int Width, int Height)
        {
            rectangle.X = centerPoint.X - (Width / 2);
            rectangle.Y = centerPoint.Y - (Height / 2);
            rectangle.Width = Width;
            rectangle.Height = Height;

            return rectangle;
        }

        public static Rectangle Create(this Rectangle rectangle, Point centerPoint, Texture2D texture2D)
            => Create(rectangle, centerPoint, texture2D.Width, texture2D.Height);

        public static Rectangle Create(this Rectangle rectangle, float X, float Y, float Width, float Height)
            => new Rectangle((int)X, (int)Y, (int)Width, (int)Height);
    }
}
