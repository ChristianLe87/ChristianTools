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

namespace Showroom_dotNet5
{
    public class Scene_UI : IScene
    {
        public Camera camera { get; private set; }
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Map map { get; private set; }

        public Scene_UI()
        {
            Initialize();
        }

        public void Initialize()
        {
            UIs = new List<IUI>()
            {
                new Button(new Rectangle(360, 10, 100, 50), "Hello World", Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green), Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red), Tools.Font.GetFont(Game1.contentManager, Path.Combine("Fonts", "Arial_10")), Color.Black, "TestButton"),

                // Left
                new Label(new Rectangle(10, 10, 100, 30),Tools.Font.GetFont(Game1.contentManager, Path.Combine("Fonts", "Arial_10")), "My Text", Label.TextAlignment.Top_Left, Color.Black, tag: "", Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),
                new Label(new Rectangle(10, 50, 100, 30),Tools.Font.GetFont(Game1.contentManager, Path.Combine("Fonts", "Arial_10")), "My Text", Label.TextAlignment.Midle_Left, Color.Black, tag: "", Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),
                new Label(new Rectangle(10, 90, 100, 30),Tools.Font.GetFont(Game1.contentManager, Path.Combine("Fonts", "Arial_10")), "My Text", Label.TextAlignment.Down_Left, Color.Black, tag: "", Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),

                // Center
                new Label(new Rectangle(120, 10, 100, 30),Tools.Font.GetFont(Game1.contentManager, Path.Combine("Fonts", "Arial_10")), "My Text", Label.TextAlignment.Top_Center, Color.Black, tag: "", Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),
                new Label(new Rectangle(120, 50, 100, 30),Tools.Font.GetFont(Game1.contentManager, Path.Combine("Fonts", "Arial_10")), "My Text", Label.TextAlignment.Midle_Center, Color.Black, tag: "", Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),
                new Label(new Rectangle(120, 90, 100, 30),Tools.Font.GetFont(Game1.contentManager, Path.Combine("Fonts", "Arial_10")), "My Text", Label.TextAlignment.Down_Center, Color.Black, tag: "", Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),

                // Right
                new Label(new Rectangle(230, 10, 100, 30),Tools.Font.GetFont(Game1.contentManager, Path.Combine("Fonts", "Arial_10")), "My Text", Label.TextAlignment.Top_Right, Color.Black, tag: "", Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),
                new Label(new Rectangle(230, 50, 100, 30),Tools.Font.GetFont(Game1.contentManager, Path.Combine("Fonts", "Arial_10")), "My Text", Label.TextAlignment.Midle_Right, Color.Black, tag: "", Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),
                new Label(new Rectangle(230, 90, 100, 30),Tools.Font.GetFont(Game1.contentManager, Path.Combine("Fonts", "Arial_10")), "My Text", Label.TextAlignment.Down_Right, Color.Black, tag: "", Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),

                new HealthBar(Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green), Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red), new Rectangle(10, 130, 50, 10), HealthBar.Direction.Right),
                new HealthBar(Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green), Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red), new Rectangle(10, 150, 50, 10), HealthBar.Direction.Left),

                new HealthBar(Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green), Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red), new Rectangle(10, 175, 10, 50), HealthBar.Direction.Up),
                new HealthBar(Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green), Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red), new Rectangle(30, 175, 10, 50), HealthBar.Direction.Down),


                new Label(
                    rectangle: new Rectangle(100, 150, 100, 30),
                    spriteFont:Tools.Font.GenerateFont(
                            texture2D: Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager,"MyFont_PNG_130x28"),
                            chars: WK.Font.chars
                    ),
                    text: "A 'B' CDEFGHIJKLMNÑOPQRSTUVWXYZ\nabcdefghijklmnñopqrstuvwxyz\n1234567890\n,:;?.!()",
                    textAlignment: Label.TextAlignment.Top_Left, Color.Black, lineSpacing: 7+2,
                    tag: ""
                ),

                new Label(
                    rectangle: new Rectangle(50, 350, 450, 60),
                    spriteFont:Tools.Font.GenerateFont(
                            texture2D: Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager,"MyFont_PNG_260x56"),
                            chars: WK.Font.chars
                    ),
                    text: "A 'B' CDEFGHIJKLMNÑOPQRSTUVWXYZ\nabcdefghijklmnñopqrstuvwxyz\n1234567890\n,:;?.!()",
                    textAlignment: Label.TextAlignment.Top_Left, Color.Black,lineSpacing: 14+2,
                    tag: ""
                ),


                new Button(
                        rectangle: new Rectangle(360, 100, 100, 50),
                        text: "Play sound",
                        defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                        mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                        spriteFont: Tools.Font.GetFont(Game1.contentManager, Path.Combine("Fonts", "Arial_10")),
                        fontColor: Color.Black,
                        tag: "SoundButton"
                ),

                new Button(
                            rectangle: new Rectangle(0, WK.Default.Height - 50, 100, 50),
                            text: "Menu",
                            defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                            mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                            spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                            fontColor: Color.Black,
                            tag: "goToMenu"
                )
            };

            soundEffects = new List<SoundEffect>()
            {
                Tools.Sound.GetSoundEffect(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, Path.Combine("Sounds", "EatingSound_WAV"))
            };
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            Button testButton = UIs.OfType<Button>().Where(x => x.tag == "TestButton").First();
            testButton.Update(inputState, lastInputState, () => Console.WriteLine("User click button!"));

            Button soundButton = UIs.OfType<Button>().Where(x => x.tag == "SoundButton").First();
            soundButton.Update(inputState, lastInputState, () => soundEffects.First().Play());

            List<Label> labels = UIs.OfType<Label>().ToList();
            foreach (var label in labels) label.Update();

            List<HealthBar> healthBars = UIs.OfType<HealthBar>().ToList();
            foreach (var healthBar in healthBars)
            {
                if (healthBar.value > 0)
                    healthBar.value--;
                else
                    healthBar.value = 100;
            }

            Button goToMenu = UIs.OfType<Button>().Where(x => x.tag == "goToMenu").First();
            goToMenu.Update(inputState, lastInputState, () => Game1.ChangeToScene(WK.Scene.Menu));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var ui in UIs)
                ui.Draw(spriteBatch);
        }
    }
}
