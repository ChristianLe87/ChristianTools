using System;
using Microsoft.Xna.Framework;

namespace ChristianTools.Tools
{
    public partial class Tools
    {
        public class MyMath
        {
            /// <summary>
            /// Calculate inclination
            /// </summary>
            public static float M(Vector2 start, Vector2 direction)
            {
                float y = direction.Y - start.Y;
                float x = direction.X - start.X;

                if (x == 0f)
                    return 0;
                else
                    return y / x;
            }

            public static float B(float x, float y, float m)
            {
                return y - (m * x);
            }

            public static double DegreeToRadian(double degree)
            {
                return ((Math.PI / 180) * degree);
            }

            public static double RadianToDegree(double radian)
            {
                return radian / (Math.PI / 180);
            }


            public static double GetAngleInDegree(Vector2 main, Vector2 target)
            {
                // Based on: tan^-1 (y/x) = angle
                double x = target.X - main.X;
                double y = target.Y - main.Y;
                double angleRad = Math.Atan(y / x);
                double angleDeg = MyMath.RadianToDegree(angleRad);


                // Not straight lines
                {
                    // Quadrant 1
                    if (x > 0 && y > 0)
                        return angleDeg;
                    // Quadrant 2
                    else if (x < 0 && y > 0)
                        return (90 * 2) + angleDeg;
                    // Quadrant 3
                    else if (x < 0 && y < 0)
                        return (90 * 2) + angleDeg;
                    // Quadrant 4
                    else if (x > 0 && y < 0)
                        return (90 * 4) + angleDeg;
                }


                // Straight lines
                {
                    // Right
                    if (x > 0 && y == 0)
                        return 0;
                    // Down
                    else if (x == 0 && y > 4)
                        return 90;
                    // Left
                    else if (x < 0 && y == 0)
                        return 180;
                    // Up
                    else if (x == 0 && y < 0)
                        return 270;
                }

                return 0; //throw new Exception("You broke the matrix");
            }


            public static double GetAngleInRadians(Vector2 main, Vector2 target)
            {
                double angleInDegrees = Tools.MyMath.GetAngleInDegree(main, target);
                double angleInRadians = Tools.MyMath.DegreeToRadian(angleInDegrees);

                return angleInRadians;
            }


            public static Vector2 Get_X_and_Y_BasedOnAngle_Radians(float slope, double angleInRadians)
            {
                float x = (float)(slope * Math.Cos(angleInRadians));
                float y = (float)(slope * Math.Sin(angleInRadians));
                return new Vector2(x, y);
            }

            public static Vector2 Get_X_and_Y_BasedOnAngle_Degrees(float slope, double angleInDegrees)
            {
                double angleInRadians = MyMath.DegreeToRadian(angleInDegrees);
                float x = (float)(slope * Math.Cos(angleInRadians));
                float y = (float)(slope * Math.Sin(angleInRadians));
                return new Vector2(x, y);
            }


            public class Pitagoras
            {
                public static double GetSlope(double x, double y)
                {
                    // r = (x^2 + y^2)^(1/2)
                    return Math.Sqrt((x * x) + (y * y));
                }

                public static double Get_Y(double slope, double x)
                {
                    // y = (r^2 - x^2)^(1/2)
                    return (float)Math.Sqrt((slope * slope) - (x * x));
                }

                public static double Get_X(double slope, double y)
                {
                    // x = (r^2 - y^2)^(1/2)
                    return Math.Sqrt((slope * slope) - (y * y));
                }
            }

            [Obsolete("Obsolete. \"Use Microsoft.Xna.Framework.MathHelper.Clamp\" or \"System.Math.Clamp\" instead.", error: true)]
            public static int Clamp(int Min, int Max, int Number)
            {
                if (Number <= Min) return Min;
                if (Number >= Max) return Max;
                return Number;
            }
        }

    }
}