using ChristianTools.Helpers;
using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace My_EasyTests_Core
{
    public class WK
    {
        public class Default : IDefault
        {
            public string WindowTitle => "Monogame_EasyTests_Core";
            public double FPS => 60;
            public bool IsFullScreen => false;
            public bool AllowUserResizing => true;
            public int ScaleFactor => 3;
            public int canvasWidth { get => AssetSize * 28 * ScaleFactor; }
            public int canvasHeight { get => AssetSize * 16 * ScaleFactor; }
            public int AssetSize => 16;
            public string GameDataFileName => "Monogame_Template_GameData";
            public bool isMouseVisible { get; set; } = true;
        }

        public class Scene
        {
            public static string Game => "SceneGame";
        }

        public class Font
        {
            static Texture2D texture2D = Tools.Texture.GetTexture("MyFont_130x28_PNG", ChristianGame.Default.ScaleFactor);
            static char[,] chars = new char[,]
            {
                { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
                { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },
                { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ñ', 'ñ', 'ß','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0' },
                { ',', ':', ';', '?', '.', '!', ' ','\'','(',')','_','\"','<','>','-','+','\\','\0','\0','\0','\0','\0','\0','\0','\0','\0' }
            };

            public static SpriteFont MyFont_130x28 => Tools.Font.GenerateFont(texture2D, chars);
        }

        public class Texture
        {
            public class PixelColor
            {
                public static Texture2D Gray = Tools.Texture.CreateColorTexture(Color.Gray);
                public static Texture2D LightGray = Tools.Texture.CreateColorTexture(Color.LightGray);
                public static Texture2D Pink = Tools.Texture.CreateColorTexture(Color.Pink);
                public static Texture2D Red = Tools.Texture.CreateColorTexture(Color.Red);
            }

            public static Texture2D Player = Tools.Texture.ScaleTexture(WK.Texture.PixelColor.Pink, ChristianGame.Default.AssetSize * ChristianGame.Default.ScaleFactor);
            public static Texture2D Lightmask => ChristianTools.Tools.Tools.Texture.GetTexture("lightmask");
            public static Texture2D Tree => Tools.Texture.GetTexture("Tree");
        }
    }
}