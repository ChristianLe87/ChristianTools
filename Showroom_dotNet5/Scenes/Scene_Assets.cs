using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using zAssets;
using zTools;
using zUI;

namespace Showroom_dotNet5
{
    public class Scene_Assets : IScene
    {
        public Camera camera { get; }

        Line line_1;
        Prefab prefab_1;
        Button goToMenu;
        Texture2D background;

        public Scene_Assets()
        {
            Initialize();
        }

        public void Initialize()
        {
            Texture2D texture2D = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red);
            this.line_1 = new Line(WK.Default.Window.Pixels.Center, new Point(0, 0), 20, texture2D);
            this.goToMenu = new Button(
                rectangle: new Rectangle(0, WK.Default.Window.Pixels.Height - 50, 100, 50),
                text: "Menu",
                defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                fontColor: Color.Black,
                ButtonID: "goToMenu"
            );
            this.prefab_1 = new Prefab(
                texture2D: Tools.Texture.CreateCircleTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 20),
                position: new Point(100, 100)
            );
            this.background = Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Image.Background);
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
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            line_1.Draw(spriteBatch);
            prefab_1.Draw(spriteBatch);
            goToMenu.Draw(spriteBatch);
        }
    }
}
