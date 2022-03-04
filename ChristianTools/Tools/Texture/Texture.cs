using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Tools
{
    public partial class Tools
    {
        public partial class Texture
        {
            public static Texture2D[] SliceHorizontalTexture(Texture2D originalTexture, int cuts)
            {
                GraphicsDevice graphicsDevice = ChristianGame.graphicsDevice;

                Texture2D[] textures = new Texture2D[cuts];
                int w = originalTexture.Width / cuts;
                int h = originalTexture.Height;
                for (int i = 0; i < cuts; i++)
                {
                    Rectangle rectangle = new Rectangle(i * w, 0, w, h);
                    textures[i] = Tools.Texture.CropTexture(originalTexture, rectangle);
                }

                return textures;
            }

            private static Dictionary<int, Texture2D> GetTileTextures(Texture2D atlasTexture, int pixelsPerTile_Width, int pixelsPerTile_Height, int units_Width, int units_Height, int scaleFactor)
            {
                Dictionary<int, Texture2D> tileTextures = new Dictionary<int, Texture2D>();
                tileTextures.Add(0, null);

                int count = 1;
                for (int y = 0; y < (pixelsPerTile_Height * units_Height); y += pixelsPerTile_Height)
                {
                    for (int x = 0; x < (pixelsPerTile_Width * units_Width); x += pixelsPerTile_Width)
                    {
                        Rectangle rectangle = new Rectangle(x, y, pixelsPerTile_Width, pixelsPerTile_Height);

                        Texture2D tileTexture_Scaled = Tools.Texture.CropTexture(
                            originalTexture: atlasTexture,
                            extractRectangle: rectangle,
                            scaleFactor: scaleFactor
                        );

                        tileTextures.Add(count, tileTexture_Scaled);
                        count++;
                    }
                }

                return tileTextures;
            }

            /// <summary>
            /// Automatic get a list of tiles based on a tilemap
            /// </summary>
            public static Dictionary<int, Texture2D> GetTileTextures(Texture2D atlasTexture)
            {
                Dictionary<int, Texture2D> tileTextures = GetTileTextures(
                    atlasTexture: atlasTexture,
                    pixelsPerTile_Height: ChristianGame.Default.AssetSize,
                    pixelsPerTile_Width: ChristianGame.Default.AssetSize,
                    units_Height: atlasTexture.Height / ChristianGame.Default.AssetSize,
                    units_Width: atlasTexture.Width / ChristianGame.Default.AssetSize,
                    scaleFactor: ChristianGame.Default.ScaleFactor
                );

                return tileTextures;
            }

            /// <summary>
            /// Increase image size by a scale factor
            /// </summary>
            public static Texture2D ScaleTexture(Texture2D originalTexture, int scaleFactor)
            {
                GraphicsDevice graphicsDevice = ChristianGame.graphicsDevice;

                Color[] originalColors = new Color[originalTexture.Width * originalTexture.Height];
                originalTexture.GetData(0, new Rectangle(0, 0, originalTexture.Width, originalTexture.Height), originalColors, 0, (originalTexture.Width * originalTexture.Height));

                Color[,] multidimentionalColors = Tools.Other.ToMultidimentional<Color>(originalColors, originalTexture.Width, originalTexture.Height);

                Color[,] expandedColors = Tools.Other.Expand<Color>(multidimentionalColors, scaleFactor);

                Color[] flatResult = Tools.Other.FlattenArray<Color>(expandedColors);

                Texture2D newTexture2D = new Texture2D(graphicsDevice, originalTexture.Width * scaleFactor, originalTexture.Height * scaleFactor, false, SurfaceFormat.Color);
                newTexture2D.SetData(flatResult);

                return newTexture2D;
            }

            /// <summary>
            /// Generate a new texture from a PNG file
            /// </summary>
            /// <param name="imageName">File name of the PNG -> without the extension</param>
            /// <returns></returns>
            public static Texture2D GetTexture(string imageName)
            {
                GraphicsDevice graphicsDevice = ChristianGame.graphicsDevice;
                ContentManager contentManager = ChristianGame.contentManager;

                string absolutePath = Path.Combine(contentManager.RootDirectory, $"{imageName}.png");
                Texture2D result = Texture2D.FromFile(graphicsDevice, absolutePath);
                return result;
            }

            public static Texture2D GetTexture(string imageName, int scaleFactor)
            {
                GraphicsDevice graphicsDevice = ChristianGame.graphicsDevice;
                ContentManager contentManager = ChristianGame.contentManager;

                Texture2D texture2D = Tools.Texture.GetTexture(imageName);
                Texture2D result = Tools.Texture.ScaleTexture(texture2D, scaleFactor);
                return result;
            }

            /// <summary>
            /// Get a new Texture2D from a bigger Texture2D
            /// </summary>
            public static Texture2D CropTexture(Texture2D originalTexture, Rectangle extractRectangle, int scaleFactor = 1)
            {
                GraphicsDevice graphicsDevice = ChristianGame.graphicsDevice;

                Texture2D subtexture = new Texture2D(graphicsDevice, extractRectangle.Width, extractRectangle.Height);
                int count = extractRectangle.Width * extractRectangle.Height;
                Color[] data = new Color[count];

                originalTexture.GetData(0, new Rectangle(extractRectangle.X, extractRectangle.Y, extractRectangle.Width, extractRectangle.Height), data, 0, count);
                subtexture.SetData(data);

                if (scaleFactor > 1)
                    subtexture = Tools.Texture.ScaleTexture(subtexture, scaleFactor);

                return subtexture;
            }

            public static Texture2D GetUnitTileFromAtlasTexture(Texture2D atlasTexture, int unit_X, int unit_Y, int scaleFactor = 1)
            {
                GraphicsDevice graphicsDevice = ChristianGame.graphicsDevice;

                Rectangle rectangle = new Rectangle(
                    unit_X * ChristianGame.Default.AssetSize,
                    unit_Y * ChristianGame.Default.AssetSize,
                    ChristianGame.Default.AssetSize,
                    ChristianGame.Default.AssetSize
                );

                Texture2D subtexture = new Texture2D(graphicsDevice, rectangle.Width, rectangle.Height);
                int count = rectangle.Width * rectangle.Height;
                Color[] data = new Color[count];

                atlasTexture.GetData(0, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height), data, 0, count);
                subtexture.SetData(data);

                if (scaleFactor > 1)
                    subtexture = Tools.Texture.ScaleTexture(subtexture, scaleFactor);

                return subtexture;
            }

            /// <summary>
            /// Just combine CropTexture() and ScaleTexture()
            /// </summary>
            /// <returns></returns>
            /*public static Texture2D CropAndScaleTexture(Texture2D originalTexture, Rectangle extractRectangle, int scaleFactor)
            {
                GraphicsDevice graphicsDevice = ChristianGame.graphicsDevice;

                Texture2D texture2D = Tools.Texture.CropTexture(originalTexture, extractRectangle);
                Texture2D scale = Tools.Texture.ScaleTexture(texture2D, scaleFactor);

                return scale;
            }*/

            /// <summary>
            /// Create a new Texture2D from a Color
            /// </summary>
            public static Texture2D CreateColorTexture(Color color, int Width = 1, int Height = 1)
            {
                GraphicsDevice graphicsDevice = ChristianGame.graphicsDevice;

                Texture2D texture2D = new Texture2D(graphicsDevice, Width, Height, false, SurfaceFormat.Color);
                Color[] colors = new Color[Width * Height];

                // Set each pixel to color
                colors = colors
                            .Select(x => x = color)
                            .ToArray();

                texture2D.SetData(colors);

                return texture2D;
            }

            /// <summary>
            /// Tint a texture
            /// </summary>
            public static Texture2D ReColorTexture(Texture2D originalTexture, Color color)
            {
                GraphicsDevice graphicsDevice = ChristianGame.graphicsDevice;

                Texture2D texture2D = new Texture2D(graphicsDevice, originalTexture.Width, originalTexture.Height, false, SurfaceFormat.Color);

                int count = originalTexture.Width * originalTexture.Height;
                Color[] data = new Color[count];

                originalTexture.GetData(0, new Rectangle(0, 0, originalTexture.Width, originalTexture.Height), data, 0, count);

                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i].A != 0)
                    {
                        data[i] = new Color(color.R, color.G, color.B, data[i].A);
                    }
                }

                texture2D.SetData(data);


                return texture2D;
            }

            /// <summary>
            /// CreateCircleTexture
            /// </summary>
            public static Texture2D CreateCircleTexture(Color color, int radius = 1)
            {
                GraphicsDevice graphicsDevice = ChristianGame.graphicsDevice;

                // Implementation
                {
                    List<Color> circle = new List<Color>();
                    for (int y = (radius * -1); y < radius; y++)
                    {
                        for (int x = (radius * -1); x < radius; x++)
                        {
                            float pitagoras = Pitagoras(x, y);

                            if (pitagoras <= radius)
                                circle.Add(color);
                            else
                                circle.Add(Color.Transparent);
                        }
                    }

                    Texture2D texture2D = new Texture2D(graphicsDevice, radius * 2, radius * 2, false, SurfaceFormat.Color);
                    texture2D.SetData(circle.ToArray());

                    return texture2D;
                }

                // Helpers
                float Pitagoras(int x, int y)
                {
                    // r = (x^2 + y^2)^(1/2)
                    return (float)Math.Sqrt(((x * x) + (y * y)));
                }
            }


            public enum PointDirection { Up, Down, Right, Left }
            public static Texture2D CreateTriangle(Color color, int Width, int Height, PointDirection pointDirection)
            {
                GraphicsDevice graphicsDevice = ChristianGame.graphicsDevice;

                Color[] colors = new Color[Width * Height];

                Point p1 = new Point(0, 0); // top
                Point p2 = new Point(Width, Height / 2); // middle
                Point p3 = new Point(0, Height); // down

                float m1 = Tools.MyMath.M(p1.ToVector2(), p2.ToVector2());
                float m2 = Tools.MyMath.M(p3.ToVector2(), p2.ToVector2());

                int count = 0;
                for (int h = 0; h < Height; h++)
                {
                    for (int w = 0; w < Width; w++)
                    {
                        if (h < Height / 2)
                        {
                            int result = (int)(m1 * w + p1.Y);

                            if (result <= h)
                                colors[count] = color;
                            else
                                colors[count] = Color.Transparent;
                        }
                        else
                        {
                            int result = (int)(m2 * w + p3.Y);

                            if (result >= h)
                                colors[count] = color;
                            else
                                colors[count] = Color.Transparent;
                        }

                        count++;
                    }
                }

                Texture2D texture2D = new Texture2D(graphicsDevice, Width, Height, false, SurfaceFormat.Color);
                switch (pointDirection)
                {
                    case PointDirection.Up:
                        {
                            Color[,] multidimentionalColors = Tools.Other.ToMultidimentional(colors, Width, Height);
                            multidimentionalColors = Tools.Other.RotateArray_90_AntiClockwise(multidimentionalColors);
                            colors = Tools.Other.FlattenArray(multidimentionalColors);
                        }
                        break;
                    case PointDirection.Down:
                        {
                            Color[,] multidimentionalColors = Tools.Other.ToMultidimentional(colors, Width, Height);
                            multidimentionalColors = Tools.Other.RotateArray_270_AntiClockwise(multidimentionalColors);
                            colors = Tools.Other.FlattenArray(multidimentionalColors);
                        }
                        break;
                    case PointDirection.Right:
                        // original
                        break;
                    case PointDirection.Left:
                        {
                            Color[,] multidimentionalColors = Tools.Other.ToMultidimentional(colors, Width, Height);
                            multidimentionalColors = Tools.Other.RotateArray_180_AntiClockwise(multidimentionalColors);
                            colors = Tools.Other.FlattenArray(multidimentionalColors);
                        }
                        break;
                }
                texture2D.SetData(colors);

                return texture2D;
            }
        }
    }
}