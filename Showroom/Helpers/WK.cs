namespace Showroom
{
    public class WK : IDefault
    {
        public int TileSize { get; } = 16;
        public double FPS { get; } = 60;
        public int CanvasWidth { get; set; } = (int)AspectRatio_16_9.Width;
        public int CanvasHeight { get; set; } = (int)AspectRatio_16_9.Height;
        public Rectangle Viewport { get; set; }
        public int ScaleFactor { get; set; } = 1;
        public string Atlas_Tileset { get; } = "AtlasTileset_PNG";
        public string Atlas_Entities { get; } = "AtlasEntities_PNG";
        public string WindowTitle { get; } = "Showroom";
        public string GameDataFileName { get; } = "MyTestData";
        public string FontFileName { get; } = "MyFont_130x28_PNG";
#if __ANDROID__ || __IOS__
        public bool IsFullScreen { get; } = true;
#else
        public bool IsFullScreen { get; } = false;
#endif
        public bool AllowUserResizing { get; } = !false;
        public bool IsMouseVisible { get; } = true;

        public Dictionary<string, string> Maps { get; } = new Dictionary<string, string>()
        {
            { "Zeldamon_1", "MyMap/Zeldamon_1" },
            { "Platformer_1", "MyMap/Platformer_1" },
        };

        public Dictionary<string, IScene> Scenes { get; set; } = new Dictionary<string, IScene>()
        {
            //{ "Scene_Test", new Scene_Test() },
            { "Scene_Entities", new Scene_Entities() },
            { "Scene_Menu", new Scene_Menu() },
            { "Scene_UI", new Scene_UI() },
            { "Scene_Platformer", new Scene_Platformer() },
            { "Scene_Camera", new Scene_Camera() },
            
            { "Scene_Tiles", new Scene_Tiles() },
            { "Scene_Zeldamon", new Scene_Zeldamon() },
        };
    }
}