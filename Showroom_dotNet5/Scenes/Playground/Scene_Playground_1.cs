using System.Collections.Generic;
using System.Linq;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Tools;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using zTools;

namespace Showroom_dotNet5
{
    // Based on: https://www.moddb.com/games/monochroma/tutorials/road-to-monochroma-platformer-design-elements
    public class Scene_Playground_1 : IScene
    {
        public Camera camera { get; private set; }
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Map map { get; private set; }

        public Scene_Playground_1()
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
            };
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            Button goToMenu = UIs.OfType<Button>().Where(x => x.tag == "goToMenu").First();
            goToMenu.Update(inputState, lastInputState, () => Game1.ChangeToScene(WK.Scene.Scene_Menu));
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            Button goToMenu = UIs.OfType<Button>().Where(x => x.tag == "goToMenu").First();
            goToMenu.Draw(spriteBatch);
        }
    }
}