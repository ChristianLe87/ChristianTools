using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ChristianTools.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Tools
{
    public class Tools
    {
        public class Texture
        {
            /*public static Texture2D FlipTexture(Texture2D originalTexture)
            {
                return null;
            }*/

            public static Texture2D[] SliceHorizontalTexture(GraphicsDevice graphicsDevice, Texture2D originalTexture, int cuts)
            {
                Texture2D[] textures = new Texture2D[cuts];
                int w = originalTexture.Width / cuts;
                int h = originalTexture.Height;
                for (int i = 0; i < cuts; i++)
                {
                    Rectangle rectangle = new Rectangle(i * w, 0, w, h);
                    textures[i] = Tools.Texture.CropTexture(graphicsDevice, originalTexture, rectangle);
                }

                return textures;
            }

            /// <summary>
            /// Automatic get a list of tiles based on a tilemap
            /// </summary>
            /// <param name="graphicsDevice"></param>
            /// <param name="atlasTexture"></param>
            /// <param name="pixelsPerTile_Width"></param>
            /// <param name="pixelsPerTile_Height"></param>
            /// <param name="units_Width"></param>
            /// <param name="units_Height"></param>
            /// <param name="scaleFactor"></param>
            /// <returns></returns>
            public static Dictionary<int, Texture2D> GetTileTextures(GraphicsDevice graphicsDevice, Texture2D atlasTexture, int pixelsPerTile_Width, int pixelsPerTile_Height, int units_Width, int units_Height, int scaleFactor)
            {
                Dictionary<int, Texture2D> tileTextures = new Dictionary<int, Texture2D>();
                tileTextures.Add(0, null);

                int count = 1;
                for (int y = 0; y < (pixelsPerTile_Height * units_Height); y += pixelsPerTile_Height)
                {
                    for (int x = 0; x < (pixelsPerTile_Width * units_Width); x += pixelsPerTile_Width)
                    {
                        Rectangle rectangle = new Rectangle(x, y, pixelsPerTile_Width, pixelsPerTile_Height);

                        Texture2D tileTexture_Scaled = Tools.Texture.CropAndScaleTexture(
                            graphicsDevice: graphicsDevice,
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
            /// Increase image size by a scale factor
            /// </summary>
            public static Texture2D ScaleTexture(GraphicsDevice graphicsDevice, Texture2D originalTexture, int scaleFactor)
            {
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
            public static Texture2D GetTexture(GraphicsDevice graphicsDevice, ContentManager contentManager, string imageName)
            {
                string absolutePath = Path.Combine(contentManager.RootDirectory, $"{imageName}.png");
                Texture2D result = Texture2D.FromFile(graphicsDevice, absolutePath);
                return result;
            }

            /// <summary>
            /// Get a new Texture2D from a bigger Texture2D
            /// </summary>
            public static Texture2D CropTexture(GraphicsDevice graphicsDevice, Texture2D originalTexture, Rectangle extractRectangle)
            {
                Texture2D subtexture = new Texture2D(graphicsDevice, extractRectangle.Width, extractRectangle.Height);
                int count = extractRectangle.Width * extractRectangle.Height;
                Color[] data = new Color[count];

                originalTexture.GetData(0, new Rectangle(extractRectangle.X, extractRectangle.Y, extractRectangle.Width, extractRectangle.Height), data, 0, count);
                subtexture.SetData(data);

                return subtexture;
            }

            /// <summary>
            /// Just combine CropTexture() and ScaleTexture()
            /// </summary>
            /// <returns></returns>
            public static Texture2D CropAndScaleTexture(GraphicsDevice graphicsDevice, Texture2D originalTexture, Rectangle extractRectangle, int scaleFactor)
            {
                Texture2D texture2D = Tools.Texture.CropTexture(graphicsDevice, originalTexture, extractRectangle);
                Texture2D scale = Tools.Texture.ScaleTexture(graphicsDevice, texture2D, scaleFactor);

                return scale;
            }

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

            /// <summary>
            /// Tint a texture
            /// </summary>
            public static Texture2D ReColorTexture(GraphicsDevice graphicsDevice, Texture2D originalTexture, Color color)
            {
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
            public static Texture2D CreateCircleTexture(GraphicsDevice graphicsDevice, Color color, int radius = 1)
            {
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
            public static Texture2D CreateTriangle(GraphicsDevice graphicsDevice, Color color, int Width, int Height, PointDirection pointDirection)
            {
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

        public class Font
        {
            /// <summary>
            /// Generate a new font from a Texture2D
            /// </summary>
            public static SpriteFont GenerateFont(Texture2D texture2D, char[,] chars)
            {
                int charWidth = texture2D.Width / chars.GetLength(1);
                int charHigh = texture2D.Height / chars.GetLength(0);

                // ===== Implementation =====
                {
                    List<FontChar> fontChars = GetFontChar(chars);

                    // The line spacing (the distance from baseline to baseline) of the font
                    List<char> characters = fontChars.Select(x => x._char).ToList();

                    // The rectangles in the font texture containing letters
                    List<Rectangle> glyphBounds = fontChars.Select(x => x.glyphBound).ToList();

                    // The cropping rectangles, which are applied to the corresponding glyphBounds to calculate the bounds of the actual character
                    List<Rectangle> cropping = fontChars.Select(x => x.cropping).ToList();

                    // The line spacing (the distance from baseline to baseline) of the font
                    int lineSpacing = charHigh + 2;

                    // The spacing (tracking) between characters in the font
                    float spacing = 0f;

                    // The letters kernings(X - left side bearing, Y - width and Z - right side bearing)
                    List<Vector3> kerning = fontChars.Select(x => x.kerning).ToList();

                    // The character that will be substituted when a given character is not included in the font
                    char defaultCharacter = '?';

                    SpriteFont spriteFont = new SpriteFont(texture2D, glyphBounds, cropping, characters, lineSpacing, spacing, kerning, defaultCharacter);

                    return spriteFont;
                }

                // ===== Helpers =====
                List<FontChar> GetFontChar(char[,] chars)
                {
                    List<FontChar> fontChars = new List<FontChar>();
                    for (int column = 0; column < chars.GetLength(0); column++)
                    {
                        for (int element = 0; element < chars.GetLength(1); element++)
                        {
                            fontChars.Add(new FontChar(
                                                    chars[column, element],
                                                    new Rectangle(element * charWidth, column * charHigh, charWidth, charHigh)));
                        }
                    }
                    return fontChars.Where(x => x._char != '\0').OrderBy(x => x._char).ToList();
                }
            }

            class FontChar
            {
                public char _char { get; }
                public Rectangle glyphBound { get; }
                public Rectangle cropping { get; }
                public Vector3 kerning { get; }

                public FontChar(char c, Rectangle glyphBound)
                {
                    this._char = c;
                    this.glyphBound = glyphBound;
                    this.cropping = new Rectangle(0, 0, 0, 0);
                    this.kerning = new Vector3(0, glyphBound.Width, glyphBound.Width / 3);
                }
            }

            /// <summary>
            /// Get a SpriteFont from ContentManager
            /// </summary>
            public static SpriteFont GetFont(ContentManager contentManager, string fontName)
            {
                return contentManager.Load<SpriteFont>(fontName);
            }
        }

        public class Sound
        {
            /// <summary>
            /// Get SoundEffect from WAV file
            /// </summary>
            /// <param name="soundName">File name of the WAV -> without the extension</param>
            /// <returns></returns>
            public static SoundEffect GetSoundEffect(GraphicsDevice graphicsDevice, ContentManager contentManager, string soundName)
            {
                string absolutePath = Path.Combine(contentManager.RootDirectory, $"{soundName}.wav");
                SoundEffect result = SoundEffect.FromFile(absolutePath);
                return result;
            }
        }

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

                public static double x(double slope, double y)
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

        public class Other
        {
            public static T[,] Expand<T>(T[,] original, int multiply)
            {
                // From stackoverflow: https://stackoverflow.com/questions/69705678/multiply-element-in-multidimensional-array?answertab=votes#tab-top
                int sizeX = original.GetLength(0);
                int sizeY = original.GetLength(1);

                T[,] newArray = new T[sizeX * multiply, sizeY * multiply];

                for (var i = 0; i < newArray.GetLength(0); i++)
                    for (var j = 0; j < newArray.GetLength(1); j++)
                        newArray[i, j] = original[i / multiply, j / multiply];

                return newArray;
            }


            public static T[] FlattenArray<T>(T[,] input)
            {
                T[] result = new T[input.Length];

                int count = 0;
                for (int w = 0; w <= input.GetUpperBound(0); w++)
                    for (int h = 0; h <= input.GetUpperBound(1); h++)
                        result[count++] = input[w, h];

                return result;
            }


            public static T[,] RotateArray_90_AntiClockwise<T>(T[,] array)
            {
                T[,] result = new T[array.GetLength(1), array.GetLength(0)];
                int newCol = 0;
                int newRow = 0;

                for (int col = array.GetLength(1) - 1; col >= 0; col--)
                {
                    newCol = 0;
                    for (int row = 0; row < array.GetLength(0); row++)
                    {
                        result[newRow, newCol] = array[row, col];
                        newCol++;
                    }
                    newRow++;
                }

                return result;
            }

            public static T[,] RotateArray_180_AntiClockwise<T>(T[,] array)
            {
                // todo: Do this better
                array = RotateArray_90_AntiClockwise(array);
                array = RotateArray_90_AntiClockwise(array);
                return array;
            }

            public static T[,] RotateArray_270_AntiClockwise<T>(T[,] array)
            {
                array = RotateArray_90_AntiClockwise(array);
                array = RotateArray_90_AntiClockwise(array);
                array = RotateArray_90_AntiClockwise(array);
                return array;
            }


            public static T[,] ToMultidimentional<T>(T[] array, int width, int height)
            {
                T[,] result = new T[height, width];

                int count = 0;
                for (int w = 0; w < height; w++)
                {
                    for (int h = 0; h < width; h++)
                    {
                        result[w, h] = array[count];
                        count++;
                    }
                }
                return result;
            }


            /// <summary>
            /// Get next new position base on a step
            /// </summary>
            /// <param name="mainRigidbody"></param>
            /// <param name="targetRigidbody"></param>
            /// <param name="maxAproximation"></param>
            /// <param name="steps"></param>
            /// <returns>New position</returns>
            public static Vector2 MoveTowards(Vector2 main, Vector2 target, int maxAproximation, float steps)
            {
                if (Vector2.Distance(main, target) < maxAproximation)
                    return main;

                double angleInRadians = Tools.MyMath.GetAngleInRadians(main, target);
                
                Vector2 result = main + MyMath.Get_X_and_Y_BasedOnAngle_Radians(steps, angleInRadians);

                return result;
            }

            public static Vector2 MoveTowards(Rigidbody main, Rigidbody target, int maxAproximation, float steps)
            {
                return MoveTowards(main.centerPosition, target.centerPosition, maxAproximation, steps);
            }

            public static Vector2 MoveTowards(Rigidbody main, Vector2 target, int maxAproximation, float steps)
            {
                return MoveTowards(main.centerPosition, target, maxAproximation, steps);
            }

            public static Vector2 MoveTowards(Vector2 main, Rigidbody target, int maxAproximation, float steps)
            {
                return MoveTowards(main, target.centerPosition, maxAproximation, steps);
            }
        }
    }
}