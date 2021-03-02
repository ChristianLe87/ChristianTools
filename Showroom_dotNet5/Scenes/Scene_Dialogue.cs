using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using zTools;
using zUI;

namespace Showroom_dotNet5
{
    public class Scene_Dialogue : IScene
    {
        Dialogue dialogue;
        Button goToMenu;
        Label instructionsLabel;

        public Scene_Dialogue()
        {
            Initialize();
        }

        public void Initialize()
        {
            string[] text = { "text 1", "text 2", "text 3" };
            dialogue = new Dialogue(
                texts: text,
                centerPosition: new Point(200, 200),
                background: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30),
                spriteFont: Tools.Font.GetFont(Game1.contentManager, "Arial_10", "Fonts")
            );

            goToMenu = new Button(
                rectangle: new Rectangle(0, WK.Default.Height - 50, 100, 50),
                text: "Menu",
                defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                fontColor: Color.Black,
                ButtonID: "goToMenu"
            );

            this.instructionsLabel = new Label(new Rectangle(200, 100, 100, 50),
                                spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                "'p' for next text\n'o' to reactivate", Label.TextAlignment.Midle_Left, Color.Pink, lineSpacing: 20);
        }

        public void Update()
        {
            dialogue.Update();

            if (Keyboard.GetState().IsKeyDown(Keys.O))
                dialogue.SetActiveState(true);

            goToMenu.Update(() => Game1.ChangeToScene(WK.Scene.Scene_Menu));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            dialogue.Draw(spriteBatch);
            goToMenu.Draw(spriteBatch);
            instructionsLabel.Draw(spriteBatch);
        }
    }
}
