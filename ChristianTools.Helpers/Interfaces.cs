using System.Collections.Generic;
using ChristianTools.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using static ChristianTools.Components.Animation;

namespace ChristianTools.Helpers
{
    public interface IEntity
    {
        public Rigidbody rigidbody { get; }
        public Animation animation { get; }
        public CharacterState characterState { get; }
        public bool isActive { get; }
        public string tag { get; }
        public int health { get; }
        public Components.Components components { get; set; }
        public void Update(InputState lastInputState, InputState inputState);
        public void Draw(SpriteBatch spriteBatch);
    }

    public interface IScene
    {
        public GameState gameState { get; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; }
        public Camera camera { get; }
        public Map map { get; }
        public void Initialize();
        public void Update(InputState lastInputState, InputState inputState);
        public void Draw(SpriteBatch spriteBatch);
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
}