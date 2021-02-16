using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using zTools;
using zUI;

namespace Showroom_dotNet5
{
    public class Scene_Lines : IScene
    {
        Line line_1;
        Button goToMenu;

        public Scene_Lines()
        {
            Initialize();
            goToMenu = new Button(
                            rectangle: new Rectangle(0, WK.Default.Height - 50, 100, 50),
                            text: "Menu",
                            defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                            mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                            spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                            fontColor: Color.Black,
                            ButtonID: "goToMenu"
            );
        }

        public void Initialize()
        {
            Texture2D texture2D = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red);
            line_1 = new Line(new Point(WK.Default.Width / 2, WK.Default.Height / 2), new Point(0, 0), 5, texture2D);
        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                line_1.Update(end: new Point(mouseState.X, mouseState.Y));
            }

            goToMenu.Update(() => Game1.ChangeToScene(WK.Scene.Scene_Menu));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            line_1.Draw(spriteBatch);
            goToMenu.Draw(spriteBatch);
        }
    }
}
