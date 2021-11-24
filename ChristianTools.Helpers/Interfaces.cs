using System.Collections.Generic;
using ChristianTools.Tools;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Helpers
{
    public interface IEntity
    {
        public Rigidbody rigidbody { get; }
        public bool isActive { get; }
        public void Update(InputState lastInputState, InputState inputState);
        public void Draw(SpriteBatch spriteBatch);
        public string tag { get; }
    }

    public interface IScene
    {
        //public Player player { get; set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        //public List<Bullet> bullets { get; set; }
        public Camera camera { get; }
        public Map map { get; }
        public void Initialize();
        public void Update(InputState lastInputState, InputState inputState);
        public void Draw(SpriteBatch spriteBatch);
    }

    public interface IUI
    {
    }

    public interface ILanguage
    {
        public string GameWindowTitle { get; }

        public string Button_GoToMenu { get; }
        public string Button_GoToSetup { get; }
    }
}
