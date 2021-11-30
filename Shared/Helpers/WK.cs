
using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class WK
    {
        public class Default
        {
            public static readonly string WindowTitle = "Showroom";
            public static readonly double FPS = 60;
            public static readonly int ScaleFactor = 3;
            public static readonly int Width = 500;
            public static readonly int Height = 500;
            public static readonly Point Center = new Point(Width / 2, Height / 2);
            public static readonly int AssetSize = 16;
            public static readonly string gameDataFileName = "ChristianTools_Showroom_GameData";
        }

        public class Scene
        {
            public static readonly string Menu = "Menu";

            // Components
            public static readonly string Components = "Components";
            public static readonly string Components_Animation = "Components_Animation";
            public static readonly string Components_Camera = "Components_Camera";
            public static readonly string Components_Map = "Components_Map";
            public static readonly string Components_Rigidbody = "Components_Rigidbody";


            // Entities
            public static readonly string Entities = "Entities";
            public static readonly string Entities_Bullet = "Entities_Bullet";
            public static readonly string Entities_Line = "Entities_Line";
            public static readonly string Entities_Prefab = "Entities_Prefab";

            // Helpers
            public static readonly string Helpers = "Helpers";
            public static readonly string Helpers_InputState = "Helpers_InputState";
            public static readonly string Helpers_JsonSerialization = "Helpers_JsonSerialization";

            // Tools
            public static readonly string Tools = "Tools";

            // UI
            public static readonly string UI = "UI";
        }

        public class Texture
        {
            public static readonly string Background = "Cuadricula_500x500_PNG";
            public static readonly string RunLeft_64x450_PNG = "RunLeft_64x450_PNG";

            public static readonly Texture2D Green = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green);
            public static readonly Texture2D Gray = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Gray);
            public static readonly Texture2D LightGray = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.LightGray);
            public static readonly Texture2D Blue = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Blue);
            public static readonly Texture2D Red = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red);
            public static readonly Texture2D DarkRed = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.DarkRed);


            public class Player
            {
                public static readonly string AtlasPlayer_20x40_PNG = "AtlasPlayer_20x40_PNG";

                public static readonly Texture2D atlasTexture = Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Texture.Player.AtlasPlayer_20x40_PNG);

                // IdleRight
                public static readonly Texture2D IdleRight = Tools.Texture.CropTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, originalTexture: atlasTexture, extractRectangle: new Rectangle(0, 0, 5, 10));
                public static readonly Texture2D IdleRight_Multiply = Tools.Texture.ScaleTexture(Game1.graphicsDeviceManager.GraphicsDevice, IdleRight, WK.Default.ScaleFactor);

                // IdleLeft
                public static readonly Texture2D IdleLeft = Tools.Texture.CropTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, originalTexture: atlasTexture, extractRectangle: new Rectangle(5, 0, 5, 10));
                public static readonly Texture2D IdleLeft_Multiply = Tools.Texture.ScaleTexture(Game1.graphicsDeviceManager.GraphicsDevice, IdleLeft, WK.Default.ScaleFactor);

                // WalkRight1
                public static readonly Texture2D WalkRight1 = Tools.Texture.CropTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, originalTexture: atlasTexture, extractRectangle: new Rectangle(0, 10, 5, 10));
                public static readonly Texture2D WalkRight1_Multiply = Tools.Texture.ScaleTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, originalTexture: WalkRight1, scaleFactor: WK.Default.ScaleFactor);

                // WalkRight2
                public static readonly Texture2D WalkRight2 = Tools.Texture.CropTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, originalTexture: atlasTexture, extractRectangle: new Rectangle(5, 10, 5, 10));
                public static readonly Texture2D WalkRight2_Multiply = Tools.Texture.ScaleTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, originalTexture: WalkRight2, scaleFactor: WK.Default.ScaleFactor);

                // WalkLeft1
                public static readonly Texture2D WalkLeft1 = Tools.Texture.CropTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, originalTexture: atlasTexture, extractRectangle: new Rectangle(10, 10, 5, 10));
                public static readonly Texture2D WalkLeft1_Multiply = Tools.Texture.ScaleTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, originalTexture: WalkLeft1, scaleFactor: WK.Default.ScaleFactor);

                // WalkLeft2
                public static readonly Texture2D WalkLeft2 = Tools.Texture.CropTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, originalTexture: atlasTexture, extractRectangle: new Rectangle(15, 10, 5, 10));
                public static readonly Texture2D WalkLeft2_Multiply = Tools.Texture.ScaleTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, originalTexture: WalkLeft2, scaleFactor: WK.Default.ScaleFactor);

                // JumpRight
                public static readonly Texture2D JumpRight = Tools.Texture.CropTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, originalTexture: atlasTexture, extractRectangle: new Rectangle(0, 20, 5, 10));
                public static readonly Texture2D JumpRight_Multiply = Tools.Texture.ScaleTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, originalTexture: JumpRight, scaleFactor: WK.Default.ScaleFactor);

                // JumpLeft
                public static readonly Texture2D JumpLeft = Tools.Texture.CropTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, originalTexture: atlasTexture, extractRectangle: new Rectangle(5, 20, 5, 10));
                public static readonly Texture2D JumpLeft_Multiply = Tools.Texture.ScaleTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, originalTexture: JumpLeft, scaleFactor: WK.Default.ScaleFactor);
            }

            public class Tiles
            {
                private static readonly string AtlasTiles_15x25_PNG = "AtlasTiles_15x25_PNG";
                private static readonly Texture2D atlasTexture = Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Texture.Tiles.AtlasTiles_15x25_PNG);

                public static Dictionary<int, Texture2D> tileTextures = Tools.Texture.GetTileTextures(
                    graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                    atlasTexture: atlasTexture,
                    pixelsPerTile_Height: 5,
                    pixelsPerTile_Width: 5,
                    units_Height: 5,
                    units_Width: 3,
                    scaleFactor: WK.Default.ScaleFactor * 3
                );
            }
        }

        public class Font
        {
            private static readonly string MyFont_130x28_PNG = "MyFont_130x28_PNG";
            private static readonly char[,] chars = new char[,]
            {
                { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
                { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },
                { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ñ', 'ñ', 'ß','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0' },
                { ',', ':', ';', '?', '.', '!', ' ','\'','(',')','_','\"','<','>','-','+','\\','\0','\0','\0','\0','\0','\0','\0','\0','\0' }
            };

            public static readonly SpriteFont font_7 = Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.MyFont_130x28_PNG), WK.Font.chars);
        }

        public class Map
        {
            public static readonly int[,] map0 = new int[,]
            {
                { 0, 0, 0, 0, 0 },
                { 0, 1, 2, 3, 0 },
                { 0, 4, 5, 6, 0 },
                { 0, 7, 8, 9, 0 },
                { 0,10,11,12, 0 },
                { 0,13,14,15, 0 },
                { 0, 0, 0, 0, 0 }
            };

            public static readonly int[,] map1 = new int[,]
            {
                //1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 1
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 2
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 3
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 4
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 5
                { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 1, 1, 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 6
                { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 1, 1, 1, 1, 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 7
                { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 8
                { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 9
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, // 10
            };


            public static readonly int[,] map2 = new int[,]
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
            };
        }
    }
}