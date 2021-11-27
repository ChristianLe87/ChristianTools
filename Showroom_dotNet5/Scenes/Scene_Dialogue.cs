using System.IO;
using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using zTools;
using ChristianTools.UI;
using ChristianTools.Helpers;
using ChristianTools.Components;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using System.Linq;

namespace Showroom_dotNet5
{
    public class Scene_Dialogue : IScene
    {
        public Camera camera { get; private set; }
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Map map { get; private set; }

        public Scene_Dialogue()
        {
            Initialize();
        }

        public void Initialize()
        {
            string[] text = { "text 1", "text 2", "text 3" };

            UIs = new List<IUI>()
            {
                new Dialogue(
                    texts: text,
                    centerPosition: new Point(200, 200),
                    background: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30),
                    spriteFont: Tools.Font.GetFont(Game1.contentManager, Path.Combine("Fonts", "Arial_10"))
                ),

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
                    new Rectangle(200, 100, 100, 50),
                    spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                    "'p' for next text\n'o' to reactivate",
                    Label.TextAlignment.Midle_Left,
                    Color.Pink,
                    lineSpacing: 20,
                    tag: ""
                )
            };
        }

        public void Update(InputState lastInputState, InputState inputState)
        {

            foreach (Dialogue dialogue in UIs.OfType<Dialogue>())
            {
                dialogue.Update();

                if (inputState.IsKeyboardKeyDown(Keys.O))
                    dialogue.SetActiveState(true);
            }

            Button goToMenu = Game1.GetScene.UIs.OfType<Button>().Where(x => x.tag == "goToMenu").First();
            goToMenu.Update(inputState, lastInputState, () => Game1.ChangeToScene(WK.Scene.Scene_Menu));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var ui in UIs)
                ui.Draw(spriteBatch);
        }
    }
}