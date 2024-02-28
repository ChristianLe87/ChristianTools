using System;
using System.Collections.Generic;
using ChristianTools.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Helpers
{
    public interface IDefault
    {
        public string WindowTitle { get; }
        public double FPS { get; }
        public bool IsFullScreen { get; set; }
        public bool AllowUserResizing { get; }
        public int ScaleFactor { get; set; }
        public int canvasWidth { get; }
        public int canvasHeight { get; }
        //public int AssetSize { get; }
        //public string GameDataFileName { get; }
        public bool isMouseVisible { get; set; }
        public string FontFileName { get; }
        public Dictionary<string, string> Atlas_Tilemap { get; }
        public string Atlas_Tileset { get; }
        public string Atlas_Entities { get; }
        public int TileSize { get; set; }
    }

    public interface IScene
    {
        List<IEntity> entities { get; set; }
        List<IUI> UIs { get; set; }
        Map map { get; set; }
        Camera camera { get; set; }
        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }
        public void Initialize();
    }

    public interface IUI
    {
        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }
        public bool isActive { get; }
    }

    public interface IEntity
    {
        public IRigidbody rigidbody { get; }
        public Animation animation { get; }
        public bool isActive { get; set; }
        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }
        public string tag { get; }
    }


    public interface IRigidbody
    {
        public double rotationDegree { get; set; }
        public Vector2 force { get; set; }

        public Rectangle rectangle { get; set; }

        public Rectangle GetRectangleUp { get; }
        public Rectangle GetRectangleDown { get; }
        public Rectangle GetRectangleLeft { get; }
        public Rectangle GetRectangleRight { get; }

        public Rectangle GetRectangleScaled { get; }
        public void InitializeRigidbody(Rectangle rectangle, Vector2 force = new Vector2());
        public void Update();
        public void Move_X(int X);
        public void Move_Y(int Y);
        public void SetCenterPosition(Point newCenterPosition);
    }

    // === Delegates ===
    public delegate void DxUpdateSystem(InputState lastInputState, InputState inputState);
    public delegate void DxDrawSystem(SpriteBatch spriteBatch);
}