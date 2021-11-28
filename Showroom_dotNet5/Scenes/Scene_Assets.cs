using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using zAssets;
using zTools;
using ChristianTools.UI;
using ChristianTools.Helpers;
using ChristianTools.Components;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using System.Linq;

namespace Showroom_dotNet5
{
    public class Scene_Assets : IScene
    {
        public Camera camera { get; private set; }
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Map map { get; private set; }

        public Scene_Assets()
        {
            Initialize();
        }

        public void Initialize()
        {
            this.entities = new List<IEntity>()
            {
                new Line(
                    start: WK.Default.Center,
                    end: new Point(0, 0),
                    thickness: 20,
                    texture2D: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                    tag: "line_1"
                ),

                new Prefab(
                    texture2D: Tools.Texture.CreateCircleTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 20),
                    centerPosition: new Vector2(100, 100),
                    tag: "prefab_1"
                ),

                new Prefab(
                    texture2D:Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Image.Background),
                    centerPosition: Vector2.Zero
                ),
            };

            this.UIs = new List<IUI>()
            {
                new Button(
                    rectangle: new Rectangle(0, WK.Default.Height - 50, 100, 50),
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
            Line line_1 = Game1.GetScene.entities.OfType<Line>().Where(x => x.tag == "line_1").First();
            if (inputState.Mouse_LeftButton == ButtonState.Pressed)
                line_1.Update(end: inputState.Mouse_Position);
            

            Button goToMenu = Game1.GetScene.UIs.OfType<Button>().Where(x => x.tag == "goToMenu").First();
            goToMenu.Update(inputState, lastInputState, () => Game1.ChangeToScene(WK.Scene.Menu));
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
