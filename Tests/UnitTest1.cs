using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        public class Test_ChristianTools_Tools
        {
            public class Test_GetRectangle
            {
                static Vector2 centerPosition = new Vector2(0, 0);
                static int Width = 100;
                static int Height = 100;
                static int scaleFactor = 1;

                public class Test_GetRectangle_Rectangle
                {
                    [Test]
                    public void Test_Rectangle_centerPosition_Width_Height()
                    {
                        Rectangle rectangle = Tools.GetRectangle.Rectangle(centerPosition, Width, Height);

                        // check center
                        Assert.True(rectangle.Center.X == centerPosition.X);
                        Assert.True(rectangle.Center.Y == centerPosition.Y);

                        // check size
                        Assert.True(rectangle.Width == Width);
                        Assert.True(rectangle.Height == Height);

                        // check top right corner
                        Assert.True(rectangle.X == (centerPosition.X - (Width / 2)));
                        Assert.True(rectangle.Y == (centerPosition.Y - (Height / 2)));
                    }

                    [Test]
                    public void Test_Rectangle_centerPosition_texture2D()
                    {
                        // Todo: Implement me
                    }
                }

                public class Test_GetRectangle_Up
                {
                    [Test]
                    public void Test_Up_mainRectangle_scaleFactor()
                    {
                        Rectangle mainRectangle = Tools.GetRectangle.Rectangle(centerPosition, Width, Height);
                        Rectangle upRectangle = Tools.GetRectangle.Up(mainRectangle, scaleFactor);

                        Rectangle expected_upRectangle = new Rectangle(
                            x: mainRectangle.X,
                            y: mainRectangle.Y - scaleFactor,
                            width: Width,
                            height: scaleFactor
                        );

                        // check center
                        Assert.True(upRectangle.Center.X == expected_upRectangle.Center.X);
                        Assert.True(upRectangle.Center.Y == expected_upRectangle.Center.Y);

                        // check size
                        Assert.True(upRectangle.Width == Width);
                        Assert.True(upRectangle.Height == scaleFactor);

                        // check top right corner
                        Assert.True(upRectangle.X == expected_upRectangle.X);
                        Assert.True(upRectangle.Y == expected_upRectangle.Y);
                    }
                }

                public class Test_GetRectangle_Down
                {
                    [Test]
                    public void Test_Down_mainRectangle_scaleFactor()
                    {
                        Rectangle mainRectangle = Tools.GetRectangle.Rectangle(centerPosition, Width, Height);
                        Rectangle downRectangle = Tools.GetRectangle.Down(mainRectangle, scaleFactor);

                        Rectangle expected_downRectangle = new Rectangle(
                            x: mainRectangle.X,
                            y: mainRectangle.Y + Height,
                            width: Width,
                            height: scaleFactor
                        );

                        // check center
                        Assert.True(downRectangle.Center.X == expected_downRectangle.Center.X);
                        Assert.True(downRectangle.Center.Y == expected_downRectangle.Center.Y);

                        // check size
                        Assert.True(downRectangle.Width == Width);
                        Assert.True(downRectangle.Height == scaleFactor);

                        // check top right corner
                        Assert.True(downRectangle.X == expected_downRectangle.X);
                        Assert.True(downRectangle.Y == expected_downRectangle.Y);
                    }
                }

                public class Test_GetRectangle_Right
                {
                    [Test]
                    public void Test_Right_mainRectangle_scaleFactor()
                    {
                        Rectangle mainRectangle = Tools.GetRectangle.Rectangle(centerPosition, Width, Height);
                        Rectangle rightRectangle = Tools.GetRectangle.Right(mainRectangle, scaleFactor);

                        Rectangle expected_rightRectangle = new Rectangle(
                            x: mainRectangle.X + Width,
                            y: mainRectangle.Y,
                            width: scaleFactor,
                            height: Height
                        );

                        // check center
                        Assert.True(rightRectangle.Center.X == expected_rightRectangle.Center.X);
                        Assert.True(rightRectangle.Center.Y == expected_rightRectangle.Center.Y);

                        // check size
                        Assert.True(rightRectangle.Width == scaleFactor);
                        Assert.True(rightRectangle.Height == Height);

                        // check top right corner
                        Assert.True(rightRectangle.X == expected_rightRectangle.X);
                        Assert.True(rightRectangle.Y == expected_rightRectangle.Y);
                    }
                }

                public class Test_GetRectangle_Left
                {
                    [Test]
                    public void Test_Left_mainRectangle_scaleFactor()
                    {
                        Rectangle mainRectangle = Tools.GetRectangle.Rectangle(centerPosition, Width, Height);
                        Rectangle leftRectangle = Tools.GetRectangle.Left(mainRectangle, scaleFactor);

                        Rectangle expected_leftRectangle = new Rectangle(
                            x: mainRectangle.X - scaleFactor,
                            y: mainRectangle.Y,
                            width: scaleFactor,
                            height: Height
                        );

                        // check center
                        Assert.True(leftRectangle.Center.X == expected_leftRectangle.Center.X);
                        Assert.True(leftRectangle.Center.Y == expected_leftRectangle.Center.Y);

                        // check size
                        Assert.True(leftRectangle.Width == scaleFactor);
                        Assert.True(leftRectangle.Height == Height);

                        // check top right corner
                        Assert.True(leftRectangle.X == expected_leftRectangle.X);
                        Assert.True(leftRectangle.Y == expected_leftRectangle.Y);
                    }
                }
            }
        }
    }
}