using System.Collections;

namespace ChristianTools.Helpers
{
    public interface IDefault
    {
        public int TileSize { get; }
        public double FPS { get; }
        public int CanvasWidth { get; set; }
        public int CanvasHeight { get; set; }
        public Rectangle Viewport { get; set; }
        public int ScaleFactor { get; set; }
        public int MaxScaleFactor { get; set; }
        public string Atlas_Tileset { get; }
        public string Atlas_Entities { get; }
        public string WindowTitle { get; }
        public string GameDataFileName { get; }
        public string FontFileName { get; }
        public bool IsFullScreen { get; }
        public bool AllowUserResizing { get; }
        public bool IsMouseVisible { get; }
        public Dictionary<string, string> Maps { get; }
        public Dictionary<string, IScene> Scenes { get; }
    }

    public interface IScene
    {
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<ITrigger> triggers { get; set; }
        public Map map { get; set; }

        public Camera camera { get; set; }

        //public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        //public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
        public void Initialize();
    }

    public interface IUI
    {
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
        public bool isActive { get; set; }
        public string tag { get; }
        public void UpdateOnGameWindowSizeChangeEvent();
    }

    public interface IEntity
    {
        public IRigidbody rigidbody { get; set; }
        public Animation animation { get; }
        public bool isActive { get; set; }
        public string tag { get; }
        public Guid guid { get; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
    }

    public interface ITrigger
    {
        public IRigidbody rigidbody { get; set; }
        public Animation animation { get; }
        public bool isActive { get; set; }
        public string tag { get; }
        public Guid guid { get; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
    }

    // === Enums ===
    public enum LayerDepth
    {
        Background = 1,
        Main = 2,
        Colliders = 3,
        Front = 4,
        Entities = 5,
    }

    public enum CharacterState
    {
        IdleUp,
        IdleDown,
        IdleRight,
        IdleLeft,
        MoveUp,
        MoveDown,
        MoveRight,
        MoveLeft,
    }

    public enum AspectRatio_16_9 : int
    {
        Width = 640,
        Height = 360,
    }

    public enum AspectRatio_4_3 : int
    {
        Width = 640,
        Height = 480,
    }
    
    public enum Alignment
    {
        Null,
        
        Top_Center,
        Midle_Center,
        Down_Center,

        Top_Left,
        Midle_Left,
        Down_Left,

        Top_Right,
        Midle_Right,
        Down_Right,
    }
    
    public interface IGameDataSystem
    {
        public GameData GetFromDevice();
        public void SaveInDevice(GameData gameData);
    }
    
    public interface IRigidbody
    {
        Vector2 force { get; set; }
        Vector2 centerPosition { get; set; }
        Point size { get; }
        List<Tile> tiles { get; }
        float gravity { get; set; }
        void Update();
        void Move_X(float X);
        void Move_Y(float Y);
        bool CanMoveUp(uint Y);
        bool CanMoveDown(uint Y);
        bool CanMoveRight(uint X);
        bool CanMoveLeft(uint X);
        Rectangle GetRectangle { get; }
    }

    // === Delegates ===
    public delegate void DxCustomUpdateSystem(InputState lastInputState, InputState inputState);
    public delegate void DxCustomDrawSystem(SpriteBatch spriteBatch);
}