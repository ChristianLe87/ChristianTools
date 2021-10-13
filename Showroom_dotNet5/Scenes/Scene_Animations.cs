using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using zTools;
using zUI;

namespace Showroom_dotNet5
{
    public class Scene_Animations : IScene
    {
        Button goToMenu;

        public Scene_Animations()
        {
            Initialize();
        }

        public void Initialize()
        {
            goToMenu = new Button(
                rectangle: new Rectangle(0, WK.Default.Window.Pixels.Height - 50, 100, 50),
                text: "Menu",
                defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                fontColor: Color.Black,
                ButtonID: "goToMenu");
        }

        public void Update()
        {
            goToMenu.Update(() => Game1.ChangeToScene(WK.Scene.Scene_Menu));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            goToMenu.Draw(spriteBatch);
        }
    }
}
