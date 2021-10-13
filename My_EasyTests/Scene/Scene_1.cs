using Microsoft.Xna.Framework.Graphics;

namespace My_EasyTests
{
    public class Scene_1 : IScene
    {
        Plyaer plyaer;

        public Scene_1()
        {
            this.plyaer = new Plyaer();
        }

        public void Update()
        {
            plyaer.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            plyaer.Draw(spriteBatch);
        }
    }
}
