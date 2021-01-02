using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monogame_UI;
using System.Linq;

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

    public class WK
    {
        public class UI
        {
            public const string Button = "button";
            public const string Label = "label";
        }
    }

    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphicsDeviceManager;
        SpriteBatch spriteBatch;
        public static ContentManager contentManager;

        List<object> UIs;

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
                new Button(new Rectangle(360, 10, 100, 50), "Hello World", Tools.CreateColorTexture(Color.Green), Tools.CreateColorTexture(Color.Red), Tools.GetFont("Arial_10", "Fonts"), Color.Black),

                // Left
                new Label(new Rectangle(10, 10, 100, 30),Tools.GetFont("Arial_10", "Fonts"), "My Text", Label.TextAlignment.Top_Left, Color.Black, Tools.CreateColorTexture(Color.Green, 100, 30), 11),
                new Label(new Rectangle(10, 50, 100, 30),Tools.GetFont("Arial_10", "Fonts"), "My Text", Label.TextAlignment.Midle_Left, Color.Black, Tools.CreateColorTexture(Color.Green, 100, 30), 11),
                new Label(new Rectangle(10, 90, 100, 30),Tools.GetFont("Arial_10", "Fonts"), "My Text", Label.TextAlignment.Down_Left, Color.Black, Tools.CreateColorTexture(Color.Green, 100, 30), 11),

                // Center
                new Label(new Rectangle(120, 10, 100, 30),Tools.GetFont("Arial_10", "Fonts"), "My Text", Label.TextAlignment.Top_Center, Color.Black, Tools.CreateColorTexture(Color.Green, 100, 30), 11),
                new Label(new Rectangle(120, 50, 100, 30),Tools.GetFont("Arial_10", "Fonts"), "My Text", Label.TextAlignment.Midle_Center, Color.Black, Tools.CreateColorTexture(Color.Green, 100, 30), 11),
                new Label(new Rectangle(120, 90, 100, 30),Tools.GetFont("Arial_10", "Fonts"), "My Text", Label.TextAlignment.Down_Center, Color.Black, Tools.CreateColorTexture(Color.Green, 100, 30), 11),

                // Right
                new Label(new Rectangle(230, 10, 100, 30),Tools.GetFont("Arial_10", "Fonts"), "My Text", Label.TextAlignment.Top_Right, Color.Black, Tools.CreateColorTexture(Color.Green, 100, 30), 11),
                new Label(new Rectangle(230, 50, 100, 30),Tools.GetFont("Arial_10", "Fonts"), "My Text", Label.TextAlignment.Midle_Right, Color.Black, Tools.CreateColorTexture(Color.Green, 100, 30), 11),
                new Label(new Rectangle(230, 90, 100, 30),Tools.GetFont("Arial_10", "Fonts"), "My Text", Label.TextAlignment.Down_Right, Color.Black, Tools.CreateColorTexture(Color.Green, 100, 30), 11),
            };
            
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


            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
