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
using Microsoft.Xna.Framework.Audio;
using System.Linq;

namespace Showroom_dotNet5
{
    public class Scene_Camera : IScene
    {
        public Camera camera { get; private set; }
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Map map { get; private set; }

        public Scene_Camera()
        {
            Initialize();
        }

        public void Initialize()
        {
            this.UIs = new List<IUI>()
            {
                new Button(
                    rectangle: new Rectangle(0, WK.Default.Window.Pixels.Height - 50, 100, 50),
                    text: "Menu",
                    defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                    mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                    spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                    fontColor: Color.Black,
                    tag: "goToMenu"
                ),

                new Label(
                    rectangle: new Rectangle(50, 50, 100, 30),
                    spriteFont: Tools.Font.GenerateFont(
                        texture2D: Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, "MyFont_PNG_130x28"),
                        chars: WK.Font.chars
                    ),
                    text: "Test camera (Rotate with 'q')",
                    textAlignment: Label.TextAlignment.Midle_Center, Color.Black, lineSpacing: 7 + 2,
                    tag: ""
                )
            };

            this.entities = new List<IEntity>()
            {
                new Player(Tools.Texture.CreateColorTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, color: Color.Pink)),
            };

            this.camera = new Camera(Game1.spriteBatch.GraphicsDevice.Viewport);
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            Button goToMenu = Game1.GetScene.UIs.OfType<Button>().Where(x => x.tag == "goToMenu").First();
            goToMenu.Update(inputState, lastInputState, () => Game1.ChangeToScene(WK.Scene.Scene_Menu));

            Player player = Game1.GetScene.UIs.OfType<Player>().First();
            player.Update(lastInputState, inputState);

            camera.Update(player.rigidbody.centerPosition);

            // ToDo: rotate camera
            /*KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Q))
            {
                camera.Rotate();
            }*/
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var entity in entities)
                entity.Draw(spriteBatch);

            foreach (var ui in UIs)
                ui.Draw(spriteBatch);
        }
    }
}