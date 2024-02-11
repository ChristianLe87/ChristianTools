using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Helpers
{
    public static class MyRectangle
    {
        public static Rectangle CreateRectangle(Point centerPosition, int Width, int Height)
        {
            Rectangle rectangle = new Rectangle(
                x: (int)(centerPosition.X - (Width / 2)),
                y: (int)(centerPosition.Y - (Height / 2)),
                width: Width,
                height: Height
            );

            return rectangle;
        }

        public static Rectangle CreateRectangle(Point centerPosition, Texture2D texture2D)
        {
            return CreateRectangle(centerPosition, texture2D.Width, texture2D.Height);
        }

        public static Rectangle ScaleRectangleSides(Rectangle originalRectangle)
        {
            Rectangle rectangle = new Rectangle(
                x: (int)(originalRectangle.X - ChristianGame.WK.ScaleFactor),
                y: (int)(originalRectangle.Y - ChristianGame.WK.ScaleFactor),
                width: originalRectangle.Width + (ChristianGame.WK.ScaleFactor * 2),
                height: originalRectangle.Height + (ChristianGame.WK.ScaleFactor * 2)
            );

            return rectangle;
        }

        public static Rectangle GetRectangleUp(Rectangle mainRectangle)
        {
            Rectangle rectangleUp = new Rectangle(
                x: mainRectangle.X,
                y: mainRectangle.Y - ChristianGame.WK.ScaleFactor,
                width: mainRectangle.Width,
                height: ChristianGame.WK.ScaleFactor
            );

            return rectangleUp;
        }

        public static Rectangle GetRectangleDown(Rectangle mainRectangle)
        {
            Rectangle rectangleDown = new Rectangle(
                x: mainRectangle.X,
                y: mainRectangle.Bottom,
                width: mainRectangle.Width,
                height: ChristianGame.WK.ScaleFactor
            );

            return rectangleDown;
        }

        public static Rectangle GetRectangleLeft(Rectangle mainRectangle)
        {
            Rectangle rectangleLeft = new Rectangle(
                x: mainRectangle.X - ChristianGame.WK.ScaleFactor,
                y: mainRectangle.Y,
                width: ChristianGame.WK.ScaleFactor,
                height: mainRectangle.Height
            );

            return rectangleLeft;
        }

        public static Rectangle GetRectangleRight(Rectangle mainRectangle)
        {
            Rectangle rectangleRight = new Rectangle(
                x: mainRectangle.Right,
                y: mainRectangle.Y,
                width: ChristianGame.WK.ScaleFactor,
                height: mainRectangle.Height
            );

            return rectangleRight;
        }
    }
}
