using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Tools;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using zTools;

namespace Showroom_dotNet5
{
    // Based on: https://www.moddb.com/games/monochroma/tutorials/road-to-monochroma-platformer-design-elements
    public class Scene_Playground_1 : IScene
    {
        public Camera camera { get; private set; }

        public GameState gameState => throw new System.NotImplementedException();

        public List<IEntity> entities { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public List<IUI> UIs { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Map map => throw new System.NotImplementedException();

        Button goToMenu;

        public Scene_Playground_1()
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

        public void Update(InputState lastInputState, InputState inputState)
        {
            throw new System.NotImplementedException();
        }
    }
}