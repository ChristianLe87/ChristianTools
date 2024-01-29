using ChristianTools.Helpers;

namespace Showroom
{
    public class WK : IDefault
    {
        public string WindowTitle { get; } = "Showroom";
        public double FPS { get; } = 60;
        public bool IsFullScreen { get; set; } = false;
        public bool AllowUserResizing { get; }
        public int ScaleFactor { get; set; } = 1;
        public int canvasWidth { get; } = 500;
        public int canvasHeight { get; } = 500;
        public int AssetSize { get; }
        public string GameDataFileName { get; }
        public bool isMouseVisible { get; set; } = true;
        public string FontFileName { get; } = "MyFont_130x28_PNG";
        public string Atlas_Tiles { get; } = "Atlas_PNG";
        public string Atlas_Entities { get; } = "Atlas_PNG";
    }
}