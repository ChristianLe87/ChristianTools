using System;
using System.Collections.Generic;
using ChristianTools.Helpers;

namespace Showroom
{
    public class WK : IDefault
    {
        public string WindowTitle { get; } = "Showroom";
        public double FPS { get; } = 60;
        public bool IsFullScreen { get; set; } = false;
        public bool AllowUserResizing { get; } = false;
        public int ScaleFactor { get; set; } = 2;
        public int canvasWidth { get; } = 500;
        public int canvasHeight { get; } = 500;
        public bool isMouseVisible { get; set; } = true;
        public string FontFileName { get; } = "MyFont_130x28_PNG";

        public Dictionary<string, string> Atlas_Tilemap { get; } = new Dictionary<string, string>()
        {
            { AtlasTilemaps.MyMap_1, "MyMap/MyMap_1" }
        };

        public string Atlas_Tileset { get; } = "Atlas_PNG";
        public string Atlas_Entities { get; } = "Atlas_PNG";
        public int TileSize { get; set; } = 16;

        public static class AtlasTilemaps
        {
            public static string MyMap_1 { get; } = "MyMap_1";
        }

        public static class Scenes
        {
            public static string Scene_Test { get; } = "Scene_Test";
            public static string Scene_Menu { get; } = "Scene_Menu";
            public static string Scene_UI { get; } = "Scene_UI";
            public static string Scene_Camera { get; } = "Scene_Camera";
            public static string Scene_Entities { get; } = "Scene_Entities";
            public static string Scene_Tiles { get; } = "Scene_Tiles";
        }
    }
}