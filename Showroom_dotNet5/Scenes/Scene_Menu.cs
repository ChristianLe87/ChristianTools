using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using zAssets;
using zTools;
using ChristianTools.UI;
using ChristianTools.Helpers;
using ChristianTools.Components;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using System.Linq;
using ChristianTools.Entities;

namespace Showroom_dotNet5
{
    public class Scene_Menu : IScene
    {
        public Camera camera { get; private set; }
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Map map { get; private set; }

        public Scene_Menu()
        {
            Initialize();
        }

        public void Initialize()
        {
            this.UIs = new List<IUI>()
            {
                // Column 1
                new Button(
                    rectangle: new Rectangle(50, 50, 100, 50),
                    text: "UI",
                    defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                    mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                    spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                    fontColor: Color.Black,
                    tag: "goToUI"
                ),

                new Button(
                    rectangle: new Rectangle(50, 150, 100, 50),
                    text: "Shoot",
                    defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                    mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                    spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                    fontColor: Color.Black,
                    tag: "goToShoot"
                ),

                new Button(
                    rectangle: new Rectangle(50, 250, 100, 50),
                    text: "Tools",
                    defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                    mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                    spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                    fontColor: Color.Black,
                    tag: "goToTools"
                ),

                new Button(
                    rectangle: new Rectangle(50, 350, 100, 50),
                    text: "Animations",
                    defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                    mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                    spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                    fontColor: Color.Black,
                    tag: "goToAnimations"
                ),

                // Column 2
                new Button(
                    rectangle: new Rectangle(200, 50, 100, 50),
                    text: "Assets",
                    defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                    mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                    spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                    fontColor: Color.Black,
                    tag: "goToAssets"
                ),

                new Button(
                    rectangle: new Rectangle(200, 150, 100, 50),
                    text: "Dialogue",
                    defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                    mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                    spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                    fontColor: Color.Black,
                    tag: "goToDialogue"
                ),

                new Button(
                    rectangle: new Rectangle(200, 250, 100, 50),
                    text: "Physics",
                    defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                    mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                    spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                    fontColor: Color.Black,
                    tag: "goToPhysics"
                ),

                new Button(
                    rectangle: new Rectangle(200, 350, 100, 50),
                    text: "Camera",
                    defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                    mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                    spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                    fontColor: Color.Black,
                    tag: "goToCamera"
                ),

                // Column 3
                new Button(
                    rectangle: new Rectangle(350, 50, 100, 50),
                    text: "Playground1",
                    defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                    mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                    spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                    fontColor: Color.Black,
                    tag: "GoToPlayground1"
                ),

                new Button(
                    rectangle: new Rectangle(350, 150, 100, 50),
                    text: "Playground2",
                    defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                    mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                    spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                    fontColor: Color.Black,
                    tag: "GoToPlayground2"
                ),
            };

            this.entities = new List<IEntity>()
            {
                // Lines
                new Line(
                    start: new Point(175, 0),
                    end: new Point(175, 500),
                    thickness: 2,
                    texture2D: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Black),
                    tag: ""
                ),


                new Line(
                    start: new Point(325, 0),
                    end: new Point(325, 500),
                    thickness: 2,
                    texture2D: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Black),
                    tag: ""
                )
            };
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            List<Button> buttons = UIs.OfType<Button>().ToList();

            buttons.Where(x => x.tag == "goToUI").First().Update(inputState, lastInputState, () => Game1.ChangeToScene(WK.Scene.UI));
            buttons.Where(x => x.tag == "goToShoot").First().Update(inputState, lastInputState, () => Game1.ChangeToScene(WK.Scene.Shoot));
            buttons.Where(x => x.tag == "goToTools").First().Update(inputState, lastInputState, () => Game1.ChangeToScene(WK.Scene.Tools));
            buttons.Where(x => x.tag == "goToAnimations").First().Update(inputState, lastInputState, () => Game1.ChangeToScene(WK.Scene.Animations));

            buttons.Where(x => x.tag == "goToAssets").First().Update(inputState, lastInputState, () => Game1.ChangeToScene(WK.Scene.Assets));
            buttons.Where(x => x.tag == "goToDialogue").First().Update(inputState, lastInputState, () => Game1.ChangeToScene(WK.Scene.Dialogue));
            buttons.Where(x => x.tag == "goToPhysics").First().Update(inputState, lastInputState, () => Game1.ChangeToScene(WK.Scene.Physics));
            buttons.Where(x => x.tag == "goToCamera").First().Update(inputState, lastInputState, () => Game1.ChangeToScene(WK.Scene.Camera));

            buttons.Where(x => x.tag == "GoToPlayground1").First().Update(inputState, lastInputState, () => Game1.ChangeToScene(WK.Scene.Playground_1));
            buttons.Where(x => x.tag == "GoToPlayground2").First().Update(inputState, lastInputState, () => Game1.ChangeToScene(WK.Scene.Playground_2));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var ui in UIs)
                ui.Draw(spriteBatch);

            foreach (var entity in entities)
                entity.Draw(spriteBatch);
        }
    }
}