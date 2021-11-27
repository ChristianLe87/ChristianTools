using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using zTools;
using zTopView_RPG;
using ChristianTools.UI;
using ChristianTools.Helpers;
using ChristianTools.Components;
using System.Collections.Generic;

namespace Showroom_dotNet5
{
    public class Scene_Camera : IScene
    {
        Button goToMenu;
        Label label;
        Player player;
        public Camera camera { get; private set; }

        public GameState gameState => throw new System.NotImplementedException();

        public List<IEntity> entities { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public List<IUI> UIs { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Map map => throw new System.NotImplementedException();

        public Scene_Camera()
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


            label = new Label(
                rectangle: new Rectangle(50, 50, 100, 30),
                spriteFont: Tools.Font.GenerateFont(
                        texture2D: Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, "MyFont_PNG_130x28"),
                        chars: WK.Font.chars
                ),
                text: "Test camera (Rotate with 'q')",
                textAlignment: Label.TextAlignment.Midle_Center, Color.Black, lineSpacing: 7 + 2
            );

            player = new Player(Tools.Texture.CreateColorTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, color: Color.Pink));

            camera = new Camera(Game1.spriteBatch.GraphicsDevice.Viewport);
        }

        public void Update()
        {
            goToMenu.Update(() => Game1.ChangeToScene(WK.Scene.Scene_Menu));
            player.Update();
            camera.Update(player.CenterPosition.ToVector2());

            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Q))
            {
                //camera.Rotate();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            label.Draw(spriteBatch);
            player.Draw(spriteBatch);
            goToMenu.Draw(spriteBatch);
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            throw new System.NotImplementedException();
        }
    }
}