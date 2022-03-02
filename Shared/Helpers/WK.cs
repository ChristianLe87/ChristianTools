
using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class WK
    {
        public class Default : IDefault
        {
            public string WindowTitle => "Monogame_Showroom";
            public double FPS => 60;
            public bool IsFullScreen => false;
            public bool AllowUserResizing => true;
            public int ScaleFactor => 3;
            public int canvasWidth { get => AssetSize * 28 * ScaleFactor; }
            public int canvasHeight { get => AssetSize * 16 * ScaleFactor; }
            public int AssetSize => 16;
            public string GameDataFileName => "ChristianTools_Showroom_GameData";
            public bool isMouseVisible { get; set; } = true;
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

            // Systems
            public static readonly string Systems = "Systems";
            public static readonly string Systems_DrawSystems = "Systems_DrawSystems";

            // Others
            public static readonly string Others = "Others";
            public static readonly string Others_PunchHole = "Scene_Others_PunchHole";
            public static readonly string Scene_Others_Lights = "Scene_Others_Lights";
            public static readonly string Scene_Others_Tiled = "Scene_Others_Tiled";
        }

        public class Texture
        {
            public static readonly string Background = "Cuadricula_500x500_PNG";
            public static readonly string RunLeft_64x450_PNG = "RunLeft_64x450_PNG";

            public static readonly Texture2D Green = Tools.Texture.CreateColorTexture(Color.Green);
            public static readonly Texture2D Gray = Tools.Texture.CreateColorTexture(Color.Gray);
            public static readonly Texture2D LightGray = Tools.Texture.CreateColorTexture(Color.LightGray);
            public static readonly Texture2D Blue = Tools.Texture.CreateColorTexture(Color.Blue);
            public static readonly Texture2D Red = Tools.Texture.CreateColorTexture(Color.Red);
            public static readonly Texture2D DarkRed = Tools.Texture.CreateColorTexture(Color.DarkRed);


            public static readonly Texture2D Tree = Tools.Texture.GetTexture("Tree", ChristianGame.Default.ScaleFactor);


            public class Player
            {
                private static readonly string AtlasPlayer_10x40_PNG = "AtlasPlayer_10x40_PNG";
                private static readonly Texture2D atlasAnimation = Tools.Texture.GetTexture(WK.Texture.Player.AtlasPlayer_10x40_PNG, ChristianGame.Default.ScaleFactor);

                // Right
                private static readonly (CharacterState, int)[] characterState_tilesRight = new (CharacterState, int)[]
                {
                    (CharacterState.IdleRight, 1),
                    (CharacterState.MoveRight, 2),
                    (CharacterState.JumpRight, 1),
                    (CharacterState.HangRight, 1)
                };

                public static Dictionary<CharacterState, Texture2D[]> animationsRight = Tools.Other.GetCharacterAnimation(atlasAnimation, characterState_tilesRight);


                // Left
                private static readonly (CharacterState, int)[] characterState_tilesLeft = new (CharacterState, int)[]
                {
                    (CharacterState.IdleLeft, 1),
                    (CharacterState.MoveLeft, 2),
                    (CharacterState.JumpLeft, 1),
                    (CharacterState.HangLeft, 1)
                };

                public static Dictionary<CharacterState, Texture2D[]> animationsLeft = Tools.Other.GetCharacterAnimation(atlasAnimation, characterState_tilesLeft, true);
            }

            public class Tiles
            {
                public class Tiles1
                {
                    private static readonly string AtlasTiles_15x25_PNG = "AtlasTiles_15x25_PNG";
                    private static readonly Texture2D atlasTexture = Tools.Texture.GetTexture(WK.Texture.Tiles.Tiles1.AtlasTiles_15x25_PNG);

                    public static Dictionary<int, Texture2D> tileTextures = Tools.Texture.GetTileTextures(atlasTexture: atlasTexture);
                }

                public class Tiles2
                {
                    private static readonly string AtlasTiles2_48x80_PNG = "AtlasTiles2_48x80_PNG";
                    private static readonly Texture2D atlasTexture = Tools.Texture.GetTexture(WK.Texture.Tiles.Tiles2.AtlasTiles2_48x80_PNG);

                    public static Dictionary<int, Texture2D> tileTextures = Tools.Texture.GetTileTextures(atlasTexture: atlasTexture);
                }
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

            public static readonly SpriteFont font_7 = Tools.Font.GenerateFont(Tools.Texture.GetTexture(WK.Font.MyFont_130x28_PNG), WK.Font.chars);
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

            public static readonly int[,] lights = new int[,]
            {
                { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 },
                { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 },
                { 5, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5 },
                { 5, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 5 },
                { 5, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5 },
                { 5, 5, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 14 },
                { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 },
                { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 },
                { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 },
                { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 },
                { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 },
                { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 },
                { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 },
                { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 },
                { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 },
            };
        }
    }
}