using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using zTools;
using zUI;

namespace Showroom_dotNet5
{
    public class Scene_Menu : IScene
    {
        Button goToUI;

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
        }

        public void Update()
        {
            // === Implementation ===
            {
                goToUI.Update(goToUI_Delegate);
            }

            // === Helpers ===
            void goToUI_Delegate()
            {
                Game1.ChangeToScene(WK.Scene.Scene_UI);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            goToUI.Draw(spriteBatch);
        }
    }
}
