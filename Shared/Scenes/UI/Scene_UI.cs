using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Tools;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Scene_UI : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Camera camera { get; }
        public Map map { get; }

        public DxSceneInitializeSystem dxSceneInitializeSystem { get; }
        public DxSceneUpdateSystem dxSceneUpdateSystem { get; private set; }
        public DxSceneDrawSystem dxSceneDrawSystem { get; }

        string textOfChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ\nabcdefghijklmnopqrstuvwxyz\n0123456789Ññß\n,:;?.! \'()_\"<>-+\\";

        public Scene_UI()
        {
            Initialize();
        }

        public void Initialize()
        {
            UIs = new List<IUI>()
            {
                new Button(
                    rectangle: new Rectangle(360, 10, 100, 50),
                    text: "Hello World",
                    defaultTexture: WK.Texture.Green,
                    mouseOverTexture: WK.Texture.Red,
                    spriteFont: WK.Font.font_7,
                    tag: "",
                    OnClickAction: () => Console.WriteLine("User click button!"),
                    camera: camera
                ),

                // Left
                new Label(new Rectangle(10, 10, 100, 30), WK.Font.font_7, "My Text", Label.TextAlignment.Top_Left, tag: "",camera: camera, WK.Texture.Green),
                new Label(new Rectangle(10, 50, 100, 30), WK.Font.font_7, "My Text", Label.TextAlignment.Midle_Left, tag: "",camera: camera, WK.Texture.Green),
                new Label(new Rectangle(10, 90, 100, 30), WK.Font.font_7, "My Text", Label.TextAlignment.Down_Left, tag: "",camera: camera, WK.Texture.Green),

                // Center
                new Label(new Rectangle(120, 10, 100, 30), WK.Font.font_7, "My Text", Label.TextAlignment.Top_Center, tag: "",camera: camera, WK.Texture.Green),
                new Label(new Rectangle(120, 50, 100, 30), WK.Font.font_7, "My Text", Label.TextAlignment.Midle_Center, tag: "",camera: camera, WK.Texture.Green),
                new Label(new Rectangle(120, 90, 100, 30), WK.Font.font_7, "My Text", Label.TextAlignment.Down_Center, tag: "",camera: camera, WK.Texture.Green),

                // Right
                new Label(new Rectangle(230, 10, 100, 30), WK.Font.font_7, "My Text", Label.TextAlignment.Top_Right, tag: "",camera: camera, WK.Texture.Green),
                new Label(new Rectangle(230, 50, 100, 30), WK.Font.font_7, "My Text", Label.TextAlignment.Midle_Right, tag: "",camera: camera, WK.Texture.Green),
                new Label(new Rectangle(230, 90, 100, 30), WK.Font.font_7, "My Text", Label.TextAlignment.Down_Right, tag: "",camera: camera, WK.Texture.Green),


                new HealthBar(Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green), Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red), new Rectangle(10, 130, 50, 10), HealthBar.Direction.Right),
                new HealthBar(Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green), Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red), new Rectangle(10, 150, 50, 10), HealthBar.Direction.Left),

                new HealthBar(Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green), Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red), new Rectangle(10, 175, 10, 50), HealthBar.Direction.Up),
                new HealthBar(Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green), Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red), new Rectangle(30, 175, 10, 50), HealthBar.Direction.Down),

                new Label(
                    rectangle: new Rectangle(100, 150, 100, 30),
                    spriteFont:WK.Font.font_7,
                    text: textOfChars,
                    textAlignment: Label.TextAlignment.Top_Left,
                    tag: "",
                    camera: camera,
                    lineSpacing: 7+2
                ),

                new Label(
                    rectangle: new Rectangle(50, 350, 450, 60),
                    spriteFont:WK.Font.font_7,
                    text: textOfChars,
                    textAlignment: Label.TextAlignment.Top_Left,
                    tag: "",
                    camera: camera,
                    lineSpacing: 14+2
                ),


                new Button(
                    rectangle: new Rectangle(360, 100, 100, 50),
                    text: "Play sound",
                    defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                    mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                    spriteFont:WK.Font.font_7,
                    tag: "SoundButton",
                    OnClickAction: () => soundEffects.First().Play(),
                    camera: camera
                ),

                new Button(
                    rectangle: new Rectangle(0, 470, 230, 30),
                    text: "<- Menu",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "goToMenu",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Menu),
                    camera: camera
                )
            };

            this.soundEffects = new List<SoundEffect>()
            {
                Tools.Sound.GetSoundEffect(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, Path.Combine("Sounds", "EatingSound_WAV"))
            };
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            foreach (var ui in UIs)
                ui.Update(lastInputState, inputState);

            List<HealthBar> healthBars = UIs.OfType<HealthBar>().ToList();
            foreach (var healthBar in healthBars)
            {
                if (healthBar.value > 0)
                    healthBar.value--;
                else
                    healthBar.value = 100;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var ui in UIs)
                ui.Draw(spriteBatch);
        }
    }
}


// Todo add Dialogue
/*
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
                    rectangle: new Rectangle(0, WK.Default.Height - 50, 100, 50),
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
        goToMenu.Update(inputState, lastInputState, () => Game1.ChangeToScene(WK.Scene.Menu));
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (var ui in UIs)
            ui.Draw(spriteBatch);
    }
}*/