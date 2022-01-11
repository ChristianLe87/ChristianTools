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
        public ExtraComponents extraComponents { get; set; }

        public DxEntityInitializeSystem dxEntityInitializeSystem { get; }
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

        public DxSceneInitializeSystem dxSceneInitializeSystem { get; }
        public DxSceneUpdateSystem dxSceneUpdateSystem { get; }
        public DxSceneDrawSystem dxSceneDrawSystem { get; }
    }

    public interface IUI
    {
        public Rectangle rectangle { get; }
        public string tag { get; }
        public void Update(InputState lastInputState, InputState inputState);
        public void Draw(SpriteBatch spriteBatch);
    }

    public interface ILanguage
    {
        public string GameWindowTitle { get; }

        public string Button_GoToMenu { get; }
        public string Button_GoToSetup { get; }
    }


    // === Delegates ===
    public delegate void DxEntityInitializeSystem();
    public delegate void DxEntityUpdateSystem(InputState lastInputState, InputState inputState, IEntity entity);
    public delegate void DxEntityDrawSystem(SpriteBatch spriteBatch, IEntity entity);

    public delegate void DxSceneInitializeSystem();
    public delegate void DxSceneUpdateSystem(InputState lastInputState, InputState inputState);
    public delegate void DxSceneDrawSystem(SpriteBatch spriteBatch);

}