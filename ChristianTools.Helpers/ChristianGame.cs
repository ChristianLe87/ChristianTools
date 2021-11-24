using System;
using System.Collections.Generic;
using System.IO;
using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Shared;

namespace ChristianTools.Helpers
{
    /*public class ChristianGame : Game
    {
        // a way to access the graphics devices (iPhone, Mac, Pc, PS4, etc)
        public static GraphicsDeviceManager graphicsDeviceManager;

        // Is used to draw sprites (a 2D or 3D images)
        SpriteBatch spriteBatch;

        public static ContentManager contentManager;

        public static KeyboardState lastKeyboardState;

        static Dictionary<string, IScene> scenes;
        static string actualScene = WK.Scene.Level1;
        public static IScene GetScene { get => scenes[actualScene]; }

        public static GameData data;

        TestThings testThings;

        public ChristianGame()
        {
            // Window
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.PreferredBackBufferWidth = WK.Default.CanvasWidth;
            graphicsDeviceManager.PreferredBackBufferHeight = WK.Default.CanvasHeight;
            graphicsDeviceManager.ApplyChanges();


            // FPS
            base.IsFixedTimeStep = true;
            base.TargetElapsedTime = TimeSpan.FromSeconds(1d / 60);
            //base.TargetElapsedTime = new TimeSpan(days: 0, hours: 0, minutes: 0, seconds: 0, milliseconds: 50); // Every frame is render each 50 milliseconds


            // Content
            string absolutePath = Path.Combine(Environment.CurrentDirectory, "Content");
            base.Content.RootDirectory = absolutePath;
            Game1.contentManager = base.Content;

            // Save data
            if (JsonSerialization.FileExist() == false)
                JsonSerialization.Create();
            else
                JsonSerialization.Read();


            // scenes
            scenes = new Dictionary<string, IScene>()
            {
                { WK.Scene.Menu, new Scene_Menu() },
                { WK.Scene.Setup, new Scene_Setup() },
                { WK.Scene.Level1, new Scene_Level1() },
            };

            // others
            base.Window.Title = WK.Default.WindowTitle;
            base.IsMouseVisible = true;

            Game1.lastKeyboardState = Keyboard.GetState();


            //testThings = new TestThings();


            // Initialize objects (scores, values, items, etc)
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

            KeyboardState keyboardState = Keyboard.GetState();


            Scene_Helper.Update(keyboardState, lastKeyboardState);


            testThings?.Update();

            Game1.lastKeyboardState = keyboardState;


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.GraphicsDevice.Clear(Color.CornflowerBlue);
            this.spriteBatch.Begin(sortMode: SpriteSortMode.Deferred, blendState: BlendState.AlphaBlend, transformMatrix: scenes[actualScene].camera?.transform);

            Scene_Helper.Draw(spriteBatch, scenes[actualScene]);
            testThings?.Draw(spriteBatch);

            this.spriteBatch.End();
            base.Draw(gameTime);
        }

        public static void ChangeToScene(string scene)
        {
            JsonSerialization.Update(Game1.data);
            actualScene = scene;
            scenes[actualScene].Initialize();
        }
    }*/
}