using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Showroom_dotNet5
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

        static Dictionary<string, IScene> scenes;
        static string actualScene = WK.Scene.Scene_Animations;

        public Game1()
        {
            // Window
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.PreferredBackBufferWidth = WK.Default.Window.Pixels.Width;
            graphicsDeviceManager.PreferredBackBufferHeight = WK.Default.Window.Pixels.Height;
            graphicsDeviceManager.ApplyChanges();

            // FPS
            base.IsFixedTimeStep = true;
            base.TargetElapsedTime = TimeSpan.FromSeconds(1d / WK.Default.FPS);

            // Content
            string absolutePath = Path.Combine(Environment.CurrentDirectory, "Content");
            base.Content.RootDirectory = absolutePath;
            Game1.contentManager = base.Content;

            scenes = new Dictionary<string, IScene>()
            {
                { WK.Scene.Scene_Menu, new Scene_Menu() },
                { WK.Scene.Scene_UI, new Scene_UI() },
                { WK.Scene.Scene_Physics, new Scene_Physics() },
                { WK.Scene.Scene_Shoot, new Scene_Shoot() },
                { WK.Scene.Scene_Tools, new Scene_Tools() },
                { WK.Scene.Scene_Assets, new Scene_Assets() },
                { WK.Scene.Scene_Dialogue, new Scene_Dialogue() },
                { WK.Scene.Scene_Playground_1, new Scene_Playground_1() },
                { WK.Scene.Scene_Playground_2, new Scene_Playground_2() },
                { WK.Scene.Scene_Animations, new Scene_Animations() },
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            scenes[actualScene].Update();

            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            base.GraphicsDevice.Clear(Color.CornflowerBlue);

            this.spriteBatch.Begin();

            // code
            scenes[actualScene].Draw(spriteBatch);
            this.spriteBatch.End();

            base.Draw(gameTime);
        }

        public static void ChangeToScene(string scene)
        {
            actualScene = scene;
            scenes[actualScene].Initialize();
        }
    }
}