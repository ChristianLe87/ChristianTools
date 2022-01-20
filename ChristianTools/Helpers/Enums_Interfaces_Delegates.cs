using System;
using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Helpers
{
    // === Enums ===
    public enum GameState
    {
        Play,
        Pause,
        GameOver
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
        JumpRight,
        JumpLeft,
        FallRight,
        FallLeft,
        HangRight,
        HangLeft,
        ShootRight,
        ShootLeft,
    }

    public enum AnimationOption
    {
        Loop,
        //Bounce,
        Stop,
    }



    // === Interfaces ===
    public interface IEntity
    {
        public Animation animation { get; }
        public Rigidbody rigidbody { get; }
        public CharacterState characterState { get; set; }
        public bool isActive { get; set; }
        public string tag { get; }
        public int health { get; }
        //public ExtraComponents extraComponents { get; set; }

        //public DxEntityInitializeSystem dxEntityInitializeSystem { get; }
        public DxEntityUpdateSystem dxEntityUpdateSystem { get; }
        public DxEntityDrawSystem dxEntityDrawSystem { get; }
    }

    public interface IScene
    {
        public GameState gameState { get; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; }
        public Camera camera { get; }
        public Map map { get; }
        public void Initialize(Vector2? playerPosition = null);

        //public DxSceneInitializeSystem dxSceneInitializeSystem { get; }
        public DxSceneUpdateSystem dxSceneUpdateSystem { get; }
        public DxSceneDrawSystem dxSceneDrawSystem { get; }
    }

    public interface IUI
    {
        public Rectangle rectangle { get; }
        public Texture2D texture { get; }
        public string tag { get; }
        public bool isActive { get; set; }

        //public DxUiInitializeSystem dxUiInitializeSystem { get;}
        public DxUiUpdateSystem dxUiUpdateSystem { get; }
        public DxUiDrawSystem dxUiDrawSystem { get; }
    }

    public interface ITile
    {
        public Texture2D texture { get; }
        public Rigidbody rigidbody { get; }
        public bool isActive { get; set; }
        //public DxTileInitializeSystem dxTileInitializeSystem { get; }
        public DxTileUpdateSystem dxTileUpdateSystem { get; }
        public DxTileDrawSystem dxTileDrawSystem { get; }
    }

    public interface ILanguage
    {
        public string GameWindowTitle { get; }

        public string Button_GoToMenu { get; }
        public string Button_GoToSetup { get; }
    }

    public interface ISetup
    {
        public string WindowTitle { get; }
        public double FPS { get; }
        public bool IsFullScreen { get; }
        public bool AllowUserResizing { get; }
        public int ScaleFactor { get; }
        public int canvasWidth { get; }
        public int canvasHeight { get; }
        public bool isMouseVisible { get; set; }
        //public Point Center => new Point(Width / 2, Height / 2);
        public int AssetSize { get; }
        public string GameDataFileName { get; }
    }

    // === Delegates ===
    //public delegate void DxEntityInitializeSystem();
    public delegate void DxEntityUpdateSystem(InputState lastInputState, InputState inputState);
    public delegate void DxEntityDrawSystem(SpriteBatch spriteBatch);

    //public delegate void DxSceneInitializeSystem();
    public delegate void DxSceneUpdateSystem(InputState lastInputState, InputState inputState);
    public delegate void DxSceneDrawSystem(SpriteBatch spriteBatch);

    //public delegate void DxTileInitializeSystem();
    public delegate void DxTileUpdateSystem(InputState lastInputState, InputState inputState);
    public delegate void DxTileDrawSystem(SpriteBatch spriteBatch);

    //public delegate void DxUiInitializeSystem();
    public delegate void DxUiUpdateSystem(InputState lastInputState, InputState inputState);
    public delegate void DxUiDrawSystem(SpriteBatch spriteBatch);
}