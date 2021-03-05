
using Microsoft.Xna.Framework;

namespace Showroom_dotNet5
{
    public class WK
    {
        public class Default
        {
            public static readonly int FPS = 60;

            public class Window
            {
                public class Pixels
                {
                    public static readonly int Width = 500;
                    public static readonly int Height = 500;

                    public static readonly int CenterX = Width / 2;
                    public static readonly int CenterY = Height / 2;

                    public static readonly Point Center = new Point(CenterX, CenterY);
                }

                public class Units
                {
                    public static readonly int Width = Pixels.Width / Block.Pixels.Width;
                    public static readonly int Height = Pixels.Height / Block.Pixels.Height;

                }
            }

            public class Block
            {
                public class Pixels
                {
                    public static readonly int Width = 16;
                    public static readonly int Height = 16;
                }

            }
        }

        public class Scene
        {
            public static readonly string Scene_Menu = "Scene_Menu";
            public static readonly string Scene_UI = "Scene_UI";
            public static readonly string Scene_Physics = "Scene_Physics";
            public static readonly string Scene_Shoot = "Scene_Shoot";
            public static readonly string Scene_Tools = "Scene_Tools";
            public static readonly string Scene_Assets = "Scene_Assets";
            public static readonly string Scene_Dialogue = "Scene_Dialogue";
            public static readonly string Scene_Playground_1 = "Scene_Playground_1";
        }

        public class Image
        {
            public static readonly string Background = "Cuadricula_500x500_PNG";
        }

        public class Font
        {
            public static readonly string Font_14 = "MyFont_PNG_260x56";

            public static readonly char[,] chars = new char[,]
            {
                { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
                { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },
                { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0' },
                { ',', ':', ';', '?', '.', '!', ' ','\'','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0' }
            };
        }
    }
}