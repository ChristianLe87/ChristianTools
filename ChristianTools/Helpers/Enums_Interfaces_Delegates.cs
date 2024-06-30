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
        List<IEntity> entities { get; set; }
        List<IUI> UIs { get; set; }
        Map map { get; set; }

        Camera camera { get; set; }

        //public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        //public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
        public void Initialize();
    }

    public interface IUI
    {
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
        public bool isActive { get; }
        public string tag { get; }
        public void UpdateOnGameWindowSizeChangeEvent();
    }

    public interface IEntity
    {
        public Rigidbody rigidbody { get; set; }
        public Animation animation { get; }
        public bool isActive { get; set; }
        public string tag { get; }
        public Guid guid { get; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
    }


    /*public interface IRigidbody
    {
        //public Vector2 velocity { get; set; }
        //public float mass { get; set; }
        //public float friction { get; set; }
        //public double rotationDegree { get; set; }
        public Vector2 force { get; set; }

        public Rectangle rectangle { get; set; }

        public Rectangle GetRectangleUp { get; }
        public Rectangle GetRectangleDown { get; }
        public Rectangle GetRectangleLeft { get; }
        public Rectangle GetRectangleRight { get; }
        public void Update();
        public void Move_X(int X);
        public void Move_Y(int Y);
        public void SetCenterPosition(Point newCenterPosition);
    }*/

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

    // === Delegates ===
    public delegate void DxCustomUpdateSystem(InputState lastInputState, InputState inputState);
    public delegate void DxCustomDrawSystem(SpriteBatch spriteBatch);
}