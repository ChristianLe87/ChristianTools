using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace My_EasyTests
{
    class Program
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

        Dictionary<string, IScene> scenes;
        string actualScene = "Scene_1";

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

            scenes = new Dictionary<string, IScene>()
            {
                {"Scene_1", new Scene_1() }
            };

            // others
            if (false)
            {
                base.Window.IsBorderless = true;
                Rectangle gameWindow = base.Window.ClientBounds;
                base.Window.Title = "Hello Window";
                base.IsMouseVisible = true;
            }
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // TODO: Code
            scenes[actualScene].Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // is graphicsDeviceManager
            //Game1.graphicsDeviceManager.GraphicsDevice.Clear(Color.CornflowerBlue);
            base.GraphicsDevice.Clear(Color.CornflowerBlue);


            this.spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            //this.spriteBatch.Begin();

            // TODO: Code
            this.scenes[actualScene].Draw(spriteBatch);

            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
