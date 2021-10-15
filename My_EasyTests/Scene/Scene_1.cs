using Microsoft.Xna.Framework.Graphics;

namespace My_EasyTests
{
    public class Scene_1 : IScene
    {
        Player player;

        public Scene_1()
        {
            this.player = new Player();
        }

        public void Update()
        {
            player.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
        }
    }
}
