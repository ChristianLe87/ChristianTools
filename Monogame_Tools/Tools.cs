using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame_Tools
{
    public class Tools
    {
        public static Texture2D GetTexture(GraphicsDevice graphicsDevice, ContentManager contentManager, string imageName, string folder = "")
        {
            string absolutePath = new DirectoryInfo(Path.Combine(Path.Combine(contentManager.RootDirectory, folder), $"{imageName}.png")).ToString();

            FileStream fileStream = new FileStream(absolutePath, FileMode.Open);

            var result = Texture2D.FromStream(graphicsDevice, fileStream);
            fileStream.Dispose();

            return result;
        }


        public static SpriteFont GenerateFont(GraphicsDevice graphicsDevice, ContentManager contentManager, string imageName, string folder = "")
        {
            // ===== Implementation =====
            {
                Texture2D texture2D = Tools.GetTexture(graphicsDevice, contentManager, imageName, folder);

                char[,] chars = new char[,]
                {
                    { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
                    { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },
                    { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ',', ':', ';', '?', '.', '!', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
                };

                List<FontChar> fontChars = GetFontChar(chars);

                // The line spacing (the distance from baseline to baseline) of the font
                List<char> characters = fontChars.Select(x => x.c).ToList();

                // The rectangles in the font texture containing letters
                List<Rectangle> glyphBounds = fontChars.Select(x => x.glyphBound).ToList();

                // The cropping rectangles, which are applied to the corresponding glyphBounds to calculate the bounds of the actual character
                List<Rectangle> cropping = fontChars.Select(x => x.cropping).ToList();

                // The line spacing (the distance from baseline to baseline) of the font
                int lineSpacing = 10;

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
                for (int col = 0; col < chars.GetLength(0); col++)
                {
                    for (int el = 0; el < chars.GetLength(1); el++)
                    {
                        fontChars.Add(new FontChar(chars[col, el], new Rectangle(el * 5, 7 * col, 5, 7)));
                    }
                }
                return fontChars.Where(x => x.c != ' ').OrderBy(x => x.c).ToList();
            }
        }

        class FontChar
        {
            public char c { get; }
            public Rectangle glyphBound { get; }
            public Rectangle cropping { get; }
            public Vector3 kerning { get; }

            public FontChar(char c, Rectangle glyphBound)
            {
                this.c = c;
                this.glyphBound = glyphBound;
                this.cropping = new Rectangle(0, 0, 0, 0);
                this.kerning = new Vector3(0, 7, 0);
            }
        }


        public static SpriteFont GetFont(ContentManager contentManager, string fontName, string folder = "")
        {
            return contentManager.Load<SpriteFont>(Path.Combine(folder, fontName));
        }


        public static Texture2D GetSubtextureFromAtlasTexture(GraphicsDevice graphicsDevice, ContentManager contentManager, string imageName, Point imagePosition)
        {
            Texture2D atlasTexture = GetTexture(graphicsDevice, contentManager, imageName, "");

            Texture2D subtexture = new Texture2D(graphicsDevice, 100, 100);
            int count = 100 * 100;
            Color[] data = new Color[count];

            atlasTexture.GetData(0, new Rectangle(imagePosition.X * 100, imagePosition.Y * 100, 100, 100), data, 0, count);
            subtexture.SetData(data);

            return subtexture;
        }


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
    }
}
