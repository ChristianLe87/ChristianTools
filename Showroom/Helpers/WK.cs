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
        public int MaxScaleFactor { get; set; } = 1;
        public string StartScene { get; } = "Scene_Menu";

        public Dictionary<string, Texture2D> Atlas_Tileset { get; set; } = new Dictionary<string, Texture2D>()
        {
            { "AtlasTileset_PNG", null },
        };

        public Dictionary<string, Texture2D> Atlas_Entities { get; set; } = new Dictionary<string, Texture2D>()
        {
            { "AtlasEntities_PNG", null },
        };

        public Dictionary<int, SpriteFont> spriteFonts { get; set; } = new Dictionary<int, SpriteFont>()
        {

        };

        public string WindowTitle { get; } = "Showroom";
        public string GameDataFileName { get; } = "MyTestData";
        public string FontFileName { get; } = "MyFont_130x28_PNG";
#if __ANDROID__ || __IOS__
        public bool IsFullScreen { get; } = true;
#else
        public bool IsFullScreen { get; } = false;
#endif
        public bool AllowUserResizing { get; } = true;
        public bool IsMouseVisible { get; } = true;

        public Dictionary<string, string> Maps { get; } = new Dictionary<string, string>()
        {
            { "Zeldamon_1", "MyMap/Zeldamon_1" },
            { "House_1", "MyMap/House_1" },
            { "Platformer_1", "MyMap/Platformer_1" },
        };

        public Dictionary<string, IScene> Scenes { get; set; } = new Dictionary<string, IScene>()
        {
            { "Scene_Test", new Scene_Test() },
            { "Scene_Menu", new Scene_Menu() },
            //{ "Scene_Test", new Scene_Test() },
            { "Scene_Entities", new Scene_Entities() },
            { "Scene_UI", new Scene_UI() },
            { "Scene_Platformer", new Scene_Platformer() },
            { "Scene_Camera", new Scene_Camera() },
            { "Scene_Tiles", new Scene_Tiles() },
            { "House_1", new House_1() },
            { "Scene_Zeldamon", new Scene_Zeldamon() },
        };
    }
}