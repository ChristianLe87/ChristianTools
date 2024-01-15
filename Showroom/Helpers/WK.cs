using ChristianTools.Helpers;

namespace Showroom
{
    public class WK : IDefault
    {
        public string WindowTitle { get; }
        public double FPS { get; } = 60;
        public bool IsFullScreen { get; set; }
        public bool AllowUserResizing { get; }
        public int ScaleFactor { get; set; }
        public int canvasWidth { get; }
        public int canvasHeight { get; }
        public int AssetSize { get; }
        public string GameDataFileName { get; }
        public bool isMouseVisible { get; set; }
        public string FontFileName { get; } = "MyFont_130x28_PNG";
        public string AtlasTextureFileName { get; } = "Atlas_PNG";
    }
}