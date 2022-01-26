using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace My_EasyTests_Core
{
    public class SceneGame : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Camera camera { get; private set; }
        public Map map { get; private set; }

        public DxSceneUpdateSystem dxSceneUpdateSystem { get; private set; }
        public DxSceneDrawSystem dxSceneDrawSystem { get; private set; }

        Texture2D tree;

        Texture2D texture_1;
        Texture2D texture_3;

        public void Initialize(Vector2? playerPosition = null)
        {
            this.tree = WK.Texture.Tree;

            Color bl = Color.Black;
            bl.A = (byte)200;

            this.texture_1 = ChristianTools.Tools.Tools.Texture.CreateColorTexture(bl, 100, 100);

            this.texture_3 = Tools.Texture.PunchHole(texture_1, new Point(20, 10), 20, 10);

            this.texture_3 = Tools.Texture.PunchHole(texture_1, new Point[] { new Point(20, 20), new Point(20, 30) }, 20, 10);



            this.texture_3 = ChristianTools.Tools.Tools.Texture.ScaleTexture(texture_3, 3);
            this.dxSceneDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
        }

        private void DrawSystem(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tree, new Vector2(0, 0), Color.White);

            spriteBatch.Draw(texture_3, new Vector2(0, 0), Color.White);
        }



    }
}