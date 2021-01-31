using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using zTools;
using zUI;


namespace Showroom_dotNet5
{
    public class Scene_UI : IScene
    {
        List<object> UIs;
        Texture2D subAtlas_1;
        Texture2D subAtlas_2;
        Texture2D subAtlas_3;
        Texture2D subAtlas_4;

        Texture2D circle_1;
        Texture2D circle_2;
        Texture2D circle_3;
        Texture2D circle_4;

        SoundEffect soundEffect;

        Button goToMenu;

        public Scene_UI()
        {
            Initialize();
        }

        public void Initialize()
        {
            UIs = new List<object>()
            {
                new Button(new Rectangle(360, 10, 100, 50), "Hello World", Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green), Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red), Tools.Font.GetFont(Game1.contentManager, "Arial_10", "Fonts"), Color.Black, "TestButton"),

                // Left
                new Label(new Rectangle(10, 10, 100, 30),Tools.Font.GetFont(Game1.contentManager, "Arial_10", "Fonts"), "My Text", Label.TextAlignment.Top_Left, Color.Black, Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),
                new Label(new Rectangle(10, 50, 100, 30),Tools.Font.GetFont(Game1.contentManager, "Arial_10", "Fonts"), "My Text", Label.TextAlignment.Midle_Left, Color.Black, Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),
                new Label(new Rectangle(10, 90, 100, 30),Tools.Font.GetFont(Game1.contentManager, "Arial_10", "Fonts"), "My Text", Label.TextAlignment.Down_Left, Color.Black, Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),

                // Center
                new Label(new Rectangle(120, 10, 100, 30),Tools.Font.GetFont(Game1.contentManager, "Arial_10", "Fonts"), "My Text", Label.TextAlignment.Top_Center, Color.Black, Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),
                new Label(new Rectangle(120, 50, 100, 30),Tools.Font.GetFont(Game1.contentManager, "Arial_10", "Fonts"), "My Text", Label.TextAlignment.Midle_Center, Color.Black, Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),
                new Label(new Rectangle(120, 90, 100, 30),Tools.Font.GetFont(Game1.contentManager, "Arial_10", "Fonts"), "My Text", Label.TextAlignment.Down_Center, Color.Black, Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),

                // Right
                new Label(new Rectangle(230, 10, 100, 30),Tools.Font.GetFont(Game1.contentManager, "Arial_10", "Fonts"), "My Text", Label.TextAlignment.Top_Right, Color.Black, Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),
                new Label(new Rectangle(230, 50, 100, 30),Tools.Font.GetFont(Game1.contentManager, "Arial_10", "Fonts"), "My Text", Label.TextAlignment.Midle_Right, Color.Black, Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),
                new Label(new Rectangle(230, 90, 100, 30),Tools.Font.GetFont(Game1.contentManager, "Arial_10", "Fonts"), "My Text", Label.TextAlignment.Down_Right, Color.Black, Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),

                new HealthBar(Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green), Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red), new Rectangle(10, 130, 50, 10), HealthBar.Direction.Right),
                new HealthBar(Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green), Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red), new Rectangle(10, 150, 50, 10), HealthBar.Direction.Left),

                new HealthBar(Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green), Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red), new Rectangle(10, 175, 10, 50), HealthBar.Direction.Up),
                new HealthBar(Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green), Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red), new Rectangle(30, 175, 10, 50), HealthBar.Direction.Down),


                new Label(
                    rectangle: new Rectangle(100, 150, 100, 30),
                    spriteFont:Tools.Font.GenerateFont(
                            texture2D: Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager,"MyFont_PNG_130x28"),
                            chars: new char[,]
                            {
                                { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
                                { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },
                                { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0' },
                                { ',', ':', ';', '?', '.', '!', ' ','\'','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0' }
                            }
                    ),
                    text: "A 'B' CDEFGHIJKLMNÑOPQRSTUVWXYZ\nabcdefghijklmnñopqrstuvwxyz\n1234567890\n,:;?.!",
                    textAlignment: Label.TextAlignment.Top_Left, Color.Black, lineSpacing: 7+2
                ),

                new Label(
                    rectangle: new Rectangle(50, 350, 450, 60),
                    spriteFont:Tools.Font.GenerateFont(
                            texture2D: Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager,"MyFont_PNG_260x56"),
                            chars: new char[,]
                            {
                                { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
                                { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },
                                { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0' },
                                { ',', ':', ';', '?', '.', '!', ' ','\'','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0' }
                            }
                    ),
                    text: "A 'B' CDEFGHIJKLMNÑOPQRSTUVWXYZ\nabcdefghijklmnñopqrstuvwxyz\n1234567890\n,:;?.!",
                    textAlignment: Label.TextAlignment.Top_Left, Color.Black,lineSpacing: 14+2
                ),


                new Button(
                        rectangle: new Rectangle(360, 100, 100, 50),
                        text: "Play sound",
                        defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                        mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                        spriteFont: Tools.Font.GetFont(Game1.contentManager, "Arial_10", "Fonts"),
                        fontColor: Color.Black,
                        ButtonID: "SoundButton"
                    )
            };

            goToMenu = new Button(
                            rectangle: new Rectangle(50, 400, 100, 50),
                            text: "Menu",
                            defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                            mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                            spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                            fontColor: Color.Black,
                            ButtonID: "goToMenu"
            );

            subAtlas_1 = Tools.Texture.CropTexture(
                            graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                            originalTexture2D: Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, "MyAtlasTexture"),
                            extractRectangle: new Rectangle(0, 0, 50, 50)
                         );
            subAtlas_2 = Tools.Texture.CropTexture(
                            graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                            originalTexture2D: Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, "MyAtlasTexture"),
                            extractRectangle: new Rectangle(50, 0, 50, 50)
                         );
            subAtlas_3 = Tools.Texture.CropTexture(
                            graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                            originalTexture2D: Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, "MyAtlasTexture"),
                            extractRectangle: new Rectangle(0, 50, 50, 50)
                         );
            subAtlas_4 = Tools.Texture.CropTexture(
                            graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                            originalTexture2D: Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, "MyAtlasTexture"),
                            extractRectangle: new Rectangle(50, 50, 50, 50)
                         );

            circle_1 = Tools.Texture.CreateCircleTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 3);
            circle_2 = Tools.Texture.CreateCircleTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 4);
            circle_3 = Tools.Texture.CreateCircleTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 25);
            circle_4 = Tools.Texture.CreateCircleTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 26);

            soundEffect = Tools.Sound.GetSoundEffect(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, "EatingSound_WAV", "Sounds");

        }

        public void Update()
        {
            // ===== Implementation =====
            {
                Button testButton = UIs.OfType<Button>().Where(x => x.ButtonID == "TestButton").First();
                testButton.Update(TestButtonDelegate);

                Button soundButton = UIs.OfType<Button>().Where(x => x.ButtonID == "SoundButton").First();
                soundButton.Update(SoundButtonDelegate);

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

                goToMenu.Update(goToMenu_Delegate);
            }

            // ===== Helpers =====
            void TestButtonDelegate()
            {
                Console.WriteLine("User click button!");
            }

            void SoundButtonDelegate()
            {
                soundEffect.Play();
            }

            void goToMenu_Delegate()
            {
                Game1.ChangeToScene(WK.Scene.Scene_Menu);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            List<Button> buttons = UIs.OfType<Button>().ToList();
            foreach (var button in buttons) button.Draw(spriteBatch);

            List<Label> labels = UIs.OfType<Label>().ToList();
            foreach (var label in labels) label.Draw(spriteBatch);

            List<HealthBar> healthBars = UIs.OfType<HealthBar>().ToList();
            foreach (var healthBar in healthBars) healthBar.Draw(spriteBatch);

            spriteBatch.Draw(subAtlas_1, new Vector2(200, 200), Color.White);
            spriteBatch.Draw(subAtlas_2, new Vector2(275, 200), Color.White);
            spriteBatch.Draw(subAtlas_3, new Vector2(200, 275), Color.White);
            spriteBatch.Draw(subAtlas_4, new Vector2(275, 275), Color.White);

            spriteBatch.Draw(circle_1, new Vector2(25, 250), Color.White);
            spriteBatch.Draw(circle_2, new Vector2(35, 250), Color.White);
            spriteBatch.Draw(circle_3, new Vector2(45, 250), Color.White);
            spriteBatch.Draw(circle_4, new Vector2(100, 250), Color.White);

            goToMenu.Draw(spriteBatch);
        }
    }
}
