using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Tools
{
    public partial class Tools
    {
        public class GetRectangle
        {
            public static Rectangle Rectangle(Vector2 centerPosition, int Width, int Height)
            {
                Rectangle rectangle = new Rectangle(
                    x: (int)(centerPosition.X - (Width / 2)),
                    y: (int)(centerPosition.Y - (Height / 2)),
                    width: Width,
                    height: Height
                );

                return rectangle;
            }

            public static Rectangle ScaleSides(Rectangle originalRectangle, int scaleFactor)
            {
                Rectangle rectangle = new Rectangle(
                    x: (int)(originalRectangle.X - scaleFactor),
                    y: (int)(originalRectangle.Y - scaleFactor),
                    width: originalRectangle.Width + (scaleFactor * 2),
                    height: originalRectangle.Height + (scaleFactor * 2)
                );

                return rectangle;
            }

            public static Rectangle Rectangle(Vector2 centerPosition, Texture2D texture2D)
            {
                return Rectangle(centerPosition, texture2D.Width, texture2D.Height);
            }

            public static Rectangle Up(Rectangle mainRectangle, int scaleFactor)
            {
                Rectangle rectangleUp = new Rectangle(
                    x: mainRectangle.X,
                    y: mainRectangle.Y - scaleFactor,
                    width: mainRectangle.Width,
                    height: scaleFactor
                );

                return rectangleUp;
            }

            public static Rectangle Down(Rectangle mainRectangle, int scaleFactor)
            {
                Rectangle rectangleDown = new Rectangle(
                    x: mainRectangle.X,
                    y: mainRectangle.Bottom,
                    width: mainRectangle.Width,
                    height: scaleFactor
                );

                return rectangleDown;
            }

            public static Rectangle Left(Rectangle mainRectangle, int scaleFactor)
            {
                Rectangle rectangleLeft = new Rectangle(
                    x: mainRectangle.X - scaleFactor,
                    y: mainRectangle.Y,
                    width: scaleFactor,
                    height: mainRectangle.Height
                );

                return rectangleLeft;
            }

            public static Rectangle Right(Rectangle mainRectangle, int scaleFactor)
            {
                Rectangle rectangleRight = new Rectangle(
                    x: mainRectangle.Right,
                    y: mainRectangle.Y,
                    width: scaleFactor,
                    height: mainRectangle.Height
                );

                return rectangleRight;
            }
        }
    }
}