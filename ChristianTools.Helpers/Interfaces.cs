using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Helpers
{
    public interface IEntity
    {
        public bool isActive { get; }
        public void Update();
        public void Draw(SpriteBatch spriteBatch);
    }

    public interface IScene
    {
        //public Player player { get; set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        //public List<Bullet> bullets { get; set; }
        public Camera camera { get; }
        //public Map map { get; }
        public void Initialize();
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
