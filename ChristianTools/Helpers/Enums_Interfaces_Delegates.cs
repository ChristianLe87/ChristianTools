using System.Collections.Generic;
using ChristianTools.Components;
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
        public int AssetSize { get; }
        public string GameDataFileName { get; }
        public bool isMouseVisible { get; set; }
        public string FontFileName { get; }
        public string AtlasTextureFileName { get; }
    }

    public interface IScene
    {
        List<IEntity> entities { get; set; }
        List<IUI> UIs { get; set; }
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
        public Rigidbody rigidbody { get; }
        public Animation animation { get; }
        public bool isActive { get; set; }
        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }
        public string tag { get; }
    }

    // === Delegates ===
    public delegate void DxUpdateSystem(InputState lastInputState, InputState inputState);
    public delegate void DxDrawSystem(SpriteBatch spriteBatch);
}