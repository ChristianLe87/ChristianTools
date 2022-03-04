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

    // === Others ===
    public class ClassicHardwareScreenSize
    {
        public static Point Gameboy => new Point(160, 144);
        public static Point GBA => new Point(240, 160);
        public static Point NES => new Point(256, 240);
        public static Point SNES => new Point(256, 224);
        public static Point Genesis => new Point(320, 224);
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
        public DxUpdateSystem dxUpdateSystem { get; }
        public DxDrawSystem dxDrawSystem { get; }
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
        public DxUpdateSystem dxUpdateSystem { get; }
        public DxDrawSystem dxDrawSystem { get; }
    }

    public interface IUI
    {
        public Rectangle rectangle { get; }
        public Texture2D texture { get; }
        public string tag { get; }
        public bool isActive { get; set; }
        public DxUpdateSystem dxUpdateSystem { get; }
        public DxDrawSystem dxDrawSystem { get; }
    }

    public interface ITile
    {
        public Texture2D texture { get; }
        public Rigidbody rigidbody { get; }
        public Tiled.LayerId layerID { get; }
        public bool isActive { get; set; }
        public DxUpdateSystem dxUpdateSystem { get; }
        public DxDrawSystem dxDrawSystem { get; }
    }

    public interface IShadow
    {
        public Texture2D texture { get; }
        public Rigidbody rigidbody { get; }
        public bool isActive { get; set; }
        public DxUpdateSystem dxUpdateSystem { get; }
        public DxDrawSystem dxDrawSystem { get; }
        public Color shadowColor { get; }
    }

    public interface ILight
    {
        public Rigidbody rigidbody { get; }
        public Texture2D texture { get; }
        public bool isActive { get; set; }
        public DxUpdateSystem dxUpdateSystem { get; }
        public DxDrawSystem dxDrawSystem { get; }
    }

    public interface ILanguage
    {
        public string GameWindowTitle { get; }
        public string Button_GoToMenu { get; }
        public string Button_GoToSetup { get; }
    }

    public interface IDefault
    {
        public string WindowTitle { get; }
        public double FPS { get; }
        public bool IsFullScreen { get; }
        public bool AllowUserResizing { get; }
        public int ScaleFactor { get; }
        public int canvasWidth { get; }
        public int canvasHeight { get; }
        public bool isMouseVisible { get; set; }
        public int AssetSize { get; }
        public string GameDataFileName { get; }
    }

    // === Delegates ===
    public delegate void DxUpdateSystem(InputState lastInputState, InputState inputState);
    public delegate void DxDrawSystem(SpriteBatch spriteBatch);
}