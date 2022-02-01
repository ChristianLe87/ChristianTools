using System;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Tools
{
    public partial class Tools
    {
        public partial class Texture
        {
            public static Texture2D PunchHole(Texture2D bigTexture, Point point, int gradientLength = 20, int fullBrightDistance = 10)
            {
                return PunchHole(bigTexture, new Point[] { point }, gradientLength, fullBrightDistance);
            }

            public static Texture2D PunchHole(Texture2D bigTexture, Point[] points, int gradientLength = 20, int fullBrightDistance = 10)
            {
                // === Implementation ===
                {
                    GraphicsDevice graphicsDevice = ChristianGame.graphicsDevice;

                    Texture2D result = new Texture2D(graphicsDevice, bigTexture.Width, bigTexture.Height);
                    Color[] result_flatColors = new Color[result.Width * result.Height];

                    Color[,] bigTexture_Color;
                    {
                        Color[] colors = new Color[bigTexture.Width * bigTexture.Height];
                        bigTexture.GetData(0, new Rectangle(0, 0, bigTexture.Width, bigTexture.Height), colors, 0, (bigTexture.Width * bigTexture.Height));
                        bigTexture_Color = ChristianTools.Tools.Tools.Other.ToMultidimentional(colors, bigTexture.Width, bigTexture.Height);
                    }

                    foreach (var p in points)
                    {
                        _PunchHole(bigTexture_Color, p);
                    }

                    result_flatColors = Tools.Other.FlattenArray<Color>(bigTexture_Color);

                    result.SetData(result_flatColors);

                    return result;
                }

                // === Helpers ===
                void _PunchHole(Color[,] bigTexture_Color, Point _point)
                {
                    for (int row = 0; row < bigTexture_Color.GetLength(0); row++)
                    {
                        for (int el = 0; el < bigTexture_Color.GetLength(1); el++)
                        {
                            int distance = (int)Vector2.Distance(new Vector2(row, el), _point.ToVector2());

                            if (distance < gradientLength)
                            {
                                if (distance < fullBrightDistance)
                                {
                                    bigTexture_Color[row, el] = Color.Transparent;
                                }
                                else
                                {
                                    float alpha = ((bigTexture_Color[row, el].A / (gradientLength - fullBrightDistance)) * (distance - fullBrightDistance));
                                    bigTexture_Color[row, el].A = (byte)Math.Clamp(alpha, 0, byte.MaxValue);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}