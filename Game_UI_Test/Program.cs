using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monogame_Tools;
using Monogame_UI;

namespace Game_UI_Test
{
    public static class Program
    {
        static void Main()
        {
            using (var game = new Game1())
            {
                game.Run();
            }
        }
    }

    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphicsDeviceManager;
        SpriteBatch spriteBatch;
        public static ContentManager contentManager;

        List<object> UIs;
        Texture2D subAtlas_1;
        Texture2D subAtlas_2;
        Texture2D subAtlas_3;
        Texture2D subAtlas_4;

        public Game1()
        {
            // Window
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.PreferredBackBufferWidth = 500;
            graphicsDeviceManager.PreferredBackBufferHeight = 500;
            graphicsDeviceManager.ApplyChanges();

            // FPS
            base.IsFixedTimeStep = true;
            base.TargetElapsedTime = TimeSpan.FromSeconds(1d / 60);

            // Content
            string absolutePath = Path.Combine(Environment.CurrentDirectory, "Content");
            base.Content.RootDirectory = absolutePath;
            Game1.contentManager = base.Content;

            UIs = new List<object>()
            {
                new Button(new Rectangle(360, 10, 100, 50), "Hello World", Tools.CreateColorTexture(graphicsDeviceManager.GraphicsDevice, Color.Green), Tools.CreateColorTexture(graphicsDeviceManager.GraphicsDevice, Color.Red), Tools.GetFont(contentManager, "Arial_10", "Fonts"), Color.Black),

                // Left
                new Label(new Rectangle(10, 10, 100, 30),Tools.GetFont(contentManager, "Arial_10", "Fonts"), "My Text", Label.TextAlignment.Top_Left, Color.Black, Tools.CreateColorTexture(graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),
                new Label(new Rectangle(10, 50, 100, 30),Tools.GetFont(contentManager, "Arial_10", "Fonts"), "My Text", Label.TextAlignment.Midle_Left, Color.Black, Tools.CreateColorTexture(graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),
                new Label(new Rectangle(10, 90, 100, 30),Tools.GetFont(contentManager, "Arial_10", "Fonts"), "My Text", Label.TextAlignment.Down_Left, Color.Black, Tools.CreateColorTexture(graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),

                // Center
                new Label(new Rectangle(120, 10, 100, 30),Tools.GetFont(contentManager, "Arial_10", "Fonts"), "My Text", Label.TextAlignment.Top_Center, Color.Black, Tools.CreateColorTexture(graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),
                new Label(new Rectangle(120, 50, 100, 30),Tools.GetFont(contentManager, "Arial_10", "Fonts"), "My Text", Label.TextAlignment.Midle_Center, Color.Black, Tools.CreateColorTexture(graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),
                new Label(new Rectangle(120, 90, 100, 30),Tools.GetFont(contentManager, "Arial_10", "Fonts"), "My Text", Label.TextAlignment.Down_Center, Color.Black, Tools.CreateColorTexture(graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),

                // Right
                new Label(new Rectangle(230, 10, 100, 30),Tools.GetFont(contentManager, "Arial_10", "Fonts"), "My Text", Label.TextAlignment.Top_Right, Color.Black, Tools.CreateColorTexture(graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),
                new Label(new Rectangle(230, 50, 100, 30),Tools.GetFont(contentManager, "Arial_10", "Fonts"), "My Text", Label.TextAlignment.Midle_Right, Color.Black, Tools.CreateColorTexture(graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),
                new Label(new Rectangle(230, 90, 100, 30),Tools.GetFont(contentManager, "Arial_10", "Fonts"), "My Text", Label.TextAlignment.Down_Right, Color.Black, Tools.CreateColorTexture(graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30), 11),

                new HealthBar(Tools.CreateColorTexture(graphicsDeviceManager.GraphicsDevice, Color.Green), Tools.CreateColorTexture(graphicsDeviceManager.GraphicsDevice, Color.Red), new Rectangle(10, 130, 50, 10), Direction.Right),
                new HealthBar(Tools.CreateColorTexture(graphicsDeviceManager.GraphicsDevice, Color.Green), Tools.CreateColorTexture(graphicsDeviceManager.GraphicsDevice, Color.Red), new Rectangle(10, 150, 50, 10), Direction.Left),

                new HealthBar(Tools.CreateColorTexture(graphicsDeviceManager.GraphicsDevice, Color.Green), Tools.CreateColorTexture(graphicsDeviceManager.GraphicsDevice, Color.Red), new Rectangle(10, 175, 10, 50), Direction.Up),
                new HealthBar(Tools.CreateColorTexture(graphicsDeviceManager.GraphicsDevice, Color.Green), Tools.CreateColorTexture(graphicsDeviceManager.GraphicsDevice, Color.Red), new Rectangle(30, 175, 10, 50), Direction.Down),


                new Label(
                    rectangle: new Rectangle(100, 150, 100, 30),
                    spriteFont:Tools.GenerateFont(
                            texture2D: Tools.GetTexture(graphicsDeviceManager.GraphicsDevice, contentManager,"MyFont_PNG_130x28"),
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
                    spriteFont:Tools.GenerateFont(
                            texture2D: Tools.GetTexture(graphicsDeviceManager.GraphicsDevice, contentManager,"MyFont_PNG_260x56"),
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
            };

            subAtlas_1 = Tools.CropTexture(
                            graphicsDevice: graphicsDeviceManager.GraphicsDevice,
                            originalTexture2D: Tools.GetTexture(graphicsDeviceManager.GraphicsDevice, contentManager, "MyAtlasTexture"),
                            extractRectangle: new Rectangle(0, 0, 50, 50)
                         );
            subAtlas_2 = Tools.CropTexture(
                            graphicsDevice: graphicsDeviceManager.GraphicsDevice,
                            originalTexture2D: Tools.GetTexture(graphicsDeviceManager.GraphicsDevice, contentManager, "MyAtlasTexture"),
                            extractRectangle: new Rectangle(50, 0, 50, 50)
                         );
            subAtlas_3 = Tools.CropTexture(
                            graphicsDevice: graphicsDeviceManager.GraphicsDevice,
                            originalTexture2D: Tools.GetTexture(graphicsDeviceManager.GraphicsDevice, contentManager, "MyAtlasTexture"),
                            extractRectangle: new Rectangle(0, 50, 50, 50)
                         );
            subAtlas_4 = Tools.CropTexture(
                            graphicsDevice: graphicsDeviceManager.GraphicsDevice,
                            originalTexture2D: Tools.GetTexture(graphicsDeviceManager.GraphicsDevice, contentManager, "MyAtlasTexture"),
                            extractRectangle: new Rectangle(50, 50, 50, 50)
                         );

            base.IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: Code
        }

        protected override void UnloadContent()
        {
            // TODO: Code
        }

        protected override void Update(GameTime gameTime)
        {
            // ===== Implementation =====
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

                List<Button> buttons = UIs.OfType<Button>().ToList();
                foreach (var button in buttons) button.Update(ButtonDelegate);

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

                base.Update(gameTime);
            }

            // ===== Helpers =====
            void ButtonDelegate()
            {
                Console.WriteLine("User click button!");
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            base.GraphicsDevice.Clear(Color.CornflowerBlue);

            this.spriteBatch.Begin();


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

            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}