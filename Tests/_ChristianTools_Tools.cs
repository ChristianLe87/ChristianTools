using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NUnit.Framework;

namespace Tests
{
    public class _ChristianTools_Tools
    {
        public class _Texture
        {
            [Test]
            public void MergeTexture()
            {
                // === Implementation ===
                {
                    int[,] bigArr = new int[,]
                    {
                        {    1,    2,    3,    4 },
                        {   11,   22,   33,   44 },
                        {  111,  222,  333,  444 },
                        { 1111, 2222, 3333, 4444 }
                    };

                    int[,] smallArr = new int[,]
                    {
                        {  220,  330 },
                        { 2220, 3330 }
                    };

                    int[,] result = Bla(bigArr, smallArr, 1, 1, 2, 2);


                    int[,] expected = new int[,]
                    {
                        {    1,     2,     3,    4 },
                        {   11,   220,   330,   44 },
                        {  111,  2220,  3330,  444 },
                        { 1111,  2222,  3333, 4444 }
                    };

                    Assert.AreEqual(result, expected);
                }

                // === Helpers ===
                int[,] Bla(int[,] bigArr, int[,] smallArr, int _X, int _Y, int W, int H)
                {
















                    int[,] result = new int[bigArr.GetLength(0), bigArr.GetLength(1)];

                    int[] values = new int[] { 20, 30, 40 };
                    int[] self = new int[] { 1, 2, 3, 4, 5 };
                    int sourceIndex = 0;
                    int index = 1;

                    Array.Copy(
                        sourceArray: values,
                        sourceIndex: 0,
                        destinationArray: self,
                        destinationIndex: index,
                        length: values.Length
                    );


                    Tools.Other.GetRow(bigArr, _Y);

                    for (int row = _X-1; row == W; row++)
                    {
                        for (int element = _Y-1; element == H; element++)
                        {
                            bigArr[row, element] = 99;
                        }
                    }

                    return bigArr;
                }
            }


            [Test]
            public void _GetTileTextures()
            {
                Assert.Warn("");
            }

            [Test]
            public void _ScaleTexture()
            {
                Assert.Warn("");
            }

            [Test]
            public void _GetTexture()
            {
                Assert.Warn("");
            }

            [Test]
            public void _CropTexture()
            {
                Assert.Warn("");
            }

            [Test]
            public void _CropAndScaleTexture()
            {
                Assert.Warn("");
            }

            [Test]
            public void _CreateColorTexture()
            {
                Assert.Warn("");
            }

            [Test]
            public void _ReColorTexture()
            {
                Assert.Warn("");
            }

            [Test]
            public void _CreateCircleTexture()
            {
                Assert.Warn("");
            }

            [Test]
            public void _CreateTriangle()
            {
                Assert.Warn("");
            }
        }

        public class _Font
        {
            [Test]
            public void _GenerateFont()
            {
                Assert.Warn("");
            }

            [Test]
            public void _GetFont()
            {
                Assert.Warn("");
            }
        }

        public class _Sound
        {
            [Test]
            public void _GetSoundEffect()
            {
                Assert.Warn("");
            }
        }

        public class _MyMath
        {
            [Test]
            public void _M()
            {
                Assert.Warn("");
            }

            [Test]
            public void _B()
            {
                Assert.Warn("");
            }

            [Test]
            public void _DegreeToRadian()
            {
                Assert.Warn("");
            }

            [Test]
            public void _RadianToDegree()
            {
                Assert.Warn("");
            }

            [Test]
            public void GetAngleInDegree()
            {
                Assert.Warn("");
            }

            [Test]
            public void _GetAngleInRadians()
            {
                Assert.Warn("");
            }

            [Test]
            public void _Get_X_and_Y_BasedOnAngle_Radians()
            {
                Assert.Warn("");
            }

            [Test]
            public void _Get_X_and_Y_BasedOnAngle_Degrees()
            {
                Assert.Warn("");
            }

            [Test]
            public void _Pitagoras_GetSlope()
            {
                Assert.Warn("");
            }

            [Test]
            public void _Pitagoras_Get_Y()
            {
                Assert.Warn("");
            }

            [Test]
            public void _Pitagoras_Get_X()
            {
                Assert.Warn("");
            }
        }

        public class _GetRectangle
        {
            static Vector2 centerPosition = new Vector2(500, 500);
            static int Width = 100;
            static int Height = 100;
            static int scaleFactor = 3;

            [Test]
            public void _Rectangle_1()
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
            public void _Rectangle_2()
            {
                Assert.Warn("");
                return;

                Texture2D texture = new Texture2D(null, Width, Height);
                Rectangle rectangle = Tools.GetRectangle.Rectangle(centerPosition, texture);
            }


            [Test]
            public void _Up()
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
                Assert.True(upRectangle.Width == expected_upRectangle.Width);
                Assert.True(upRectangle.Height == expected_upRectangle.Height);

                // check top right corner
                Assert.True(upRectangle.X == expected_upRectangle.X);
                Assert.True(upRectangle.Y == expected_upRectangle.Y);
            }

            [Test]
            public void _Down()
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
                Assert.True(downRectangle.Width == expected_downRectangle.Width);
                Assert.True(downRectangle.Height == expected_downRectangle.Height);

                // check top right corner
                Assert.True(downRectangle.X == expected_downRectangle.X);
                Assert.True(downRectangle.Y == expected_downRectangle.Y);
            }

            [Test]
            public void _Right()
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
                Assert.True(rightRectangle.Width == expected_rightRectangle.Width);
                Assert.True(rightRectangle.Height == expected_rightRectangle.Height);

                // check top right corner
                Assert.True(rightRectangle.X == expected_rightRectangle.X);
                Assert.True(rightRectangle.Y == expected_rightRectangle.Y);
            }

            [Test]
            public void _Left()
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
                Assert.True(leftRectangle.Width == expected_leftRectangle.Width);
                Assert.True(leftRectangle.Height == expected_leftRectangle.Height);

                // check top right corner
                Assert.True(leftRectangle.X == expected_leftRectangle.X);
                Assert.True(leftRectangle.Y == expected_leftRectangle.Y);
            }
        }

        public class _Other
        {
            [Test]
            public void GetColumn()
            {
                int[,] arr = new int[,]
                {
                    { 1, 2, 3 },
                    { 4, 5, 6 },
                    { 7, 8, 9 }
                };

                int[] result = Tools.Other.GetColumn(arr, 1);

                Assert.AreEqual(result, new int[] { 2, 5, 8 });
            }


            [Test]
            public void GetRow()
            {
                int[,] arr = new int[,]
                {
                    { 1, 2, 3 },
                    { 4, 5, 6 },
                    { 7, 8, 9 }
                };

                int[] result = Tools.Other.GetRow(arr, 1);

                Assert.AreEqual(result, new int[] { 4, 5, 6 });
            }


            [Test]
            public void _Expand()
            {
                Assert.Warn("");
            }

            [Test]
            public void _FlattenArray()
            {
                Assert.Warn("");
            }

            [Test]
            public void _RotateArray_90_AntiClockwise()
            {
                Assert.Warn("");
            }

            [Test]
            public void _RotateArray_180_AntiClockwise()
            {
                Assert.Warn("");
            }

            [Test]
            public void _RotateArray_270_AntiClockwise()
            {
                Assert.Warn("");
            }

            [Test]
            public void _ToMultidimentional()
            {
                Assert.Warn("");
            }

            public class _MoveTowards
            {
                public class _Quadrant_posX_posY
                {
                    [Test]
                    public void _MoveTowards_Right()
                    {
                        Vector2 start = new Vector2(2, 2);
                        Vector2 end = new Vector2(10, 2);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_Left()
                    {
                        Vector2 start = new Vector2(10, 2);
                        Vector2 end = new Vector2(2, 2);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_Down()
                    {
                        Vector2 start = new Vector2(2, 2);
                        Vector2 end = new Vector2(2, 10);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_Up()
                    {
                        Vector2 start = new Vector2(2, 10);
                        Vector2 end = new Vector2(2, 2);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_DownRight()
                    {
                        Vector2 start = new Vector2(2, 2);
                        Vector2 end = new Vector2(10, 10);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_UpLeft()
                    {
                        Vector2 start = new Vector2(10, 10);
                        Vector2 end = new Vector2(2, 2);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_DownLeft()
                    {
                        Vector2 start = new Vector2(10, 2);
                        Vector2 end = new Vector2(2, 10);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_UpRight()
                    {
                        Vector2 start = new Vector2(2, 10);
                        Vector2 end = new Vector2(10, 2);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }
                }

                public class _Quadrant_negX_posY
                {
                    [Test]
                    public void _MoveTowards_Right()
                    {
                        Vector2 start = new Vector2(-10, 2);
                        Vector2 end = new Vector2(-2, 2);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_Left()
                    {
                        Vector2 start = new Vector2(-10, 2);
                        Vector2 end = new Vector2(-2, 2);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_Down()
                    {
                        Vector2 start = new Vector2(-2, 2);
                        Vector2 end = new Vector2(-2, 10);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_Up()
                    {
                        Vector2 start = new Vector2(-2, 10);
                        Vector2 end = new Vector2(-2, 2);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_DownRight()
                    {
                        Vector2 start = new Vector2(-2, 2);
                        Vector2 end = new Vector2(-10, 10);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_UpLeft()
                    {
                        Vector2 start = new Vector2(-10, 10);
                        Vector2 end = new Vector2(-2, 2);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_DownLeft()
                    {
                        Vector2 start = new Vector2(-2, 2);
                        Vector2 end = new Vector2(-10, 10);
                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_UpRight()
                    {
                        Vector2 start = new Vector2(-2, 10);
                        Vector2 end = new Vector2(-10, 2);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }
                }

                public class _Quadrant_negX_negY
                {
                    [Test]
                    public void _MoveTowards_Right()
                    {
                        Vector2 start = new Vector2(-2, -2);
                        Vector2 end = new Vector2(-10, -2);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_Left()
                    {
                        Vector2 start = new Vector2(-10, -2);
                        Vector2 end = new Vector2(-2, -2);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_Down()
                    {
                        Vector2 start = new Vector2(-2, -2);
                        Vector2 end = new Vector2(-2, -10);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_Up()
                    {
                        Vector2 start = new Vector2(-2, -10);
                        Vector2 end = new Vector2(-2, -2);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_DownRight()
                    {
                        Vector2 start = new Vector2(-2, -2);
                        Vector2 end = new Vector2(-10, -10);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_UpLeft()
                    {
                        Vector2 start = new Vector2(-10, -10);
                        Vector2 end = new Vector2(-2, -2);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_DownLeft()
                    {
                        Vector2 start = new Vector2(-2, -10);
                        Vector2 end = new Vector2(-10, -2);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_UpRight()
                    {
                        Vector2 start = new Vector2(-2, -10);
                        Vector2 end = new Vector2(-10, -2);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }
                }

                public class _Quadrant_posX_negY
                {
                    [Test]
                    public void _MoveTowards_Right()
                    {
                        Vector2 start = new Vector2(2, -2);
                        Vector2 end = new Vector2(10, -2);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_Left()
                    {
                        Vector2 start = new Vector2(10, -2);
                        Vector2 end = new Vector2(2, -2);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_Down()
                    {
                        Vector2 start = new Vector2(2, -2);
                        Vector2 end = new Vector2(2, -10);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_Up()
                    {
                        Vector2 start = new Vector2(2, -10);
                        Vector2 end = new Vector2(2, -2);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_DownRight()
                    {
                        Vector2 start = new Vector2(2, -2);
                        Vector2 end = new Vector2(10, -10);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_UpLeft()
                    {
                        Vector2 start = new Vector2(10, -10);
                        Vector2 end = new Vector2(2, -2);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_DownLeft()
                    {
                        Vector2 start = new Vector2(2, -2);
                        Vector2 end = new Vector2(10, -10);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_UpRight()
                    {
                        Vector2 start = new Vector2(2, -10);
                        Vector2 end = new Vector2(10, -2);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }
                }

                public class _Center
                {
                    [Test]
                    public void _MoveTowards_Right()
                    {
                        Vector2 start = new Vector2(-5, 0);
                        Vector2 end = new Vector2(5, 0);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_Left()
                    {
                        Vector2 start = new Vector2(5, 0);
                        Vector2 end = new Vector2(-5, 0);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_Down()
                    {
                        Vector2 start = new Vector2(0, -5);
                        Vector2 end = new Vector2(0, 5);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_Up()
                    {
                        Vector2 start = new Vector2(0, 5);
                        Vector2 end = new Vector2(0, -5);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_DownRight()
                    {
                        Vector2 start = new Vector2(-5, -5);
                        Vector2 end = new Vector2(5, 5);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_UpLeft()
                    {
                        Vector2 start = new Vector2(5, 5);
                        Vector2 end = new Vector2(-5, -5);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_DownLeft()
                    {
                        Vector2 start = new Vector2(5, -5);
                        Vector2 end = new Vector2(-5, 5);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }

                    [Test]
                    public void _MoveTowards_UpRight()
                    {
                        Vector2 start = new Vector2(-5, 5);
                        Vector2 end = new Vector2(5, -5);

                        while (true)
                        {
                            Vector2 result = Tools.Other.MoveTowards(start, end, 1, 1);

                            if (result == start)
                                break;

                            start = result;
                        }

                        Assert.IsTrue(Vector2.Distance(start, end) <= 1);
                    }
                }
            }
        }
    }
}