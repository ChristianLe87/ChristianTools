using System;
using System.Collections.Generic;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;

namespace Showroom
{
    public class WK : IDefault
    {
        public string WindowTitle { get; } = "Showroom";
        public double FPS { get; } = 60;
        public bool IsFullScreen { get; set; } = false;
        public bool AllowUserResizing { get; } = false;
        //public int ScaleFactor { get; set; } = 2;
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
        
        public static class AtlasReferences
        {
            public static Rectangle _1 { get; } = new Rectangle(16, 16, 16, 16);
            public static Rectangle _2 { get; } = new Rectangle(32, 16, 16, 16);
            public static Rectangle _3 { get; } = new Rectangle(48, 16, 16, 16);

            public static Rectangle _4 { get; } = new Rectangle(16, 32, 16, 16);
            public static Rectangle _5 { get; } = new Rectangle(32, 32, 16, 16);
            public static Rectangle _6 { get; } = new Rectangle(48, 32, 16, 16);

            public static Rectangle _7 { get; } = new Rectangle(16, 48, 16, 16);
            public static Rectangle _8 { get; } = new Rectangle(32, 48, 16, 16);
            public static Rectangle _9 { get; } = new Rectangle(48, 48, 16, 16);
        }
    }
}