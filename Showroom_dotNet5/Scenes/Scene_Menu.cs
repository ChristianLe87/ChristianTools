using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using zTools;
using zUI;

namespace Showroom_dotNet5
{
    public class Scene_Menu : IScene
    {
        Button goToUI;
        Button goToShoot;
        Button goToTools;

        Button goToAssets;

        public Scene_Menu()
        {
            Initialize();
        }

        public void Initialize()
        {
            goToUI = new Button(
                            rectangle: new Rectangle(50, 50, 100, 50),
                            text: "UI",
                            defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                            mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                            spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14),WK.Font.chars),
                            fontColor: Color.Black,
                            ButtonID: "goToUI"
            );

            goToShoot = new Button(
                            rectangle: new Rectangle(50, 150, 100, 50),
                            text: "Shoot",
                            defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                            mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                            spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                            fontColor: Color.Black,
                            ButtonID: "goToShoot"
            );

            goToTools = new Button(
                            rectangle: new Rectangle(50, 250, 100, 50),
                            text: "Tools",
                            defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                            mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                            spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                            fontColor: Color.Black,
                            ButtonID: "goToTools"
            );

            goToAssets = new Button(
                            rectangle: new Rectangle(250, 50, 100, 50),
                            text: "Assets",
                            defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                            mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                            spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                            fontColor: Color.Black,
                            ButtonID: "goToAssets"
            );
        }

        public void Update()
        {
            goToUI.Update(() => Game1.ChangeToScene(WK.Scene.Scene_UI));
            goToShoot.Update(() => Game1.ChangeToScene(WK.Scene.Scene_Shoot));
            goToTools.Update(() => Game1.ChangeToScene(WK.Scene.Scene_Tools));
            goToAssets.Update(() => Game1.ChangeToScene(WK.Scene.Scene_Assets));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            goToUI.Draw(spriteBatch);
            goToShoot.Draw(spriteBatch);
            goToTools.Draw(spriteBatch);
            goToAssets.Draw(spriteBatch);
        }
    }
}
