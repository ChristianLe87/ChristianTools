namespace ChristianTools.Helpers
{
    public class Font
    {
        public static char[,] defaultChars = new char[,]
        {
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U',
                'V', 'W', 'X', 'Y', 'Z'
            },
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u',
                'v', 'w', 'x', 'y', 'z'
            },
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ñ', 'ñ', 'ß', '\0', '\0', '\0', '\0', '\0', '\0',
                '\0', '\0', '\0', '\0', '\0', '\0', '\0'
            },
            {
                ',', ':', ';', '?', '.', '!', ' ', '\'', '(', ')', '_', '\"', '<', '>', '-', '+', '\\', '\0', '\0',
                '\0', '\0', '\0', '\0', '\0', '\0', '\0'
            }
        };

        /// <summary>
        /// Generate a new font from a Texture2D
        /// </summary>
        public static SpriteFont GenerateFont(Texture2D texture2D)
        {
            int charWidth = texture2D.Width / defaultChars.GetLength(1);
            int charHigh = texture2D.Height / defaultChars.GetLength(0);

            // ===== Implementation =====
            {
                List<FontChar> fontChars = GetFontChar(defaultChars);

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

                SpriteFont spriteFont = new SpriteFont(texture2D, glyphBounds, cropping, characters, lineSpacing,
                    spacing, kerning, defaultCharacter);

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
    }
}
