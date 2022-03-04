using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Helpers
{
    public class ChristianGame : Game
    {
        Effect effect;

        // a way to access the graphics devices (iPhone, Mac, Pc, PS4, etc)
        static GraphicsDeviceManager graphicsDeviceManager;
        public static GraphicsDevice graphicsDevice => graphicsDeviceManager.GraphicsDevice;

        // Is used to draw sprites (a 2D or 3D images)
        static SpriteBatch spriteBatch;
        public static Viewport viewport => spriteBatch.GraphicsDevice.Viewport;

        public static ContentManager contentManager;

        // Input
        static InputState lastInputState;

        // Scenes
        static Dictionary<string, IScene> scenes;
        static string actualScene;
        public static IScene GetScene { get => scenes[actualScene]; }

        // GameData
        static string gameDataFileName;
        public static GameData gameData;

        public static IDefault Default { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameDataFileName">File name of the GameData -> without the extension</param>
        public ChristianGame(IDefault Default)
        {
            ChristianGame.Default = Default;

            // Window
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.PreferredBackBufferWidth = Default.canvasWidth;
            graphicsDeviceManager.PreferredBackBufferHeight = Default.canvasHeight;
            graphicsDeviceManager.IsFullScreen = Default.IsFullScreen;
            //graphicsDeviceManager.ToggleFullScreen();
            graphicsDeviceManager.ApplyChanges();
            //Actual monitor size: GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;


            // FPS
            base.IsFixedTimeStep = true;
            base.TargetElapsedTime = TimeSpan.FromSeconds(1d / 60);
            //base.TargetElapsedTime = new TimeSpan(days: 0, hours: 0, minutes: 0, seconds: 0, milliseconds: 50); // Every frame is render each 50 milliseconds


            // Content
            string absolutePath = Path.Combine(Environment.CurrentDirectory, "Content");
            base.Content.RootDirectory = absolutePath;
            ChristianGame.contentManager = base.Content;


            // GameData
            ChristianGame.gameDataFileName = Default.GameDataFileName;

            // Create folder
            if(JsonSerialization.FolderExist() == false)
            {
                JsonSerialization.CreateFolder();
            }


            if (JsonSerialization.FileExist(gameDataFileName) == false)
            {
                ChristianGame.gameData = new GameData();
                JsonSerialization.Create<GameData>(gameData, gameDataFileName);
            }
            else
            {
                GameData gameData = JsonSerialization.Read<GameData>(gameDataFileName);
                ChristianGame.gameData = gameData;
            }


            // others
            base.Window.Title = Default.WindowTitle;
            base.IsMouseVisible = Default.isMouseVisible;
            Window.AllowUserResizing = Default.AllowUserResizing;
            game = this;


            // use with GameWindowSizeChangeEvent()
            if (Default.AllowUserResizing == true)
            {
                Window.AllowUserResizing = Default.AllowUserResizing;
                Window.ClientSizeChanged += GameWindowSizeChangeEvent;

                gameWindow = Window;
                myDisplay = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;
            }


            ChristianGame.lastInputState = new InputState();

            // Initialize objects (scores, values, items, etc)
            base.Initialize();
        }

        public void SetupScenes(Dictionary<string, IScene> scenes, string startScene, Vector2? playerPosition = null)
        {
            ChristianGame.scenes = scenes;
            ChristianGame.actualScene = startScene;

            if(playerPosition != null)
                scenes[actualScene].Initialize(playerPosition.Value);
            else
                scenes[actualScene].Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //effect = Tools.Tools.Other.GetMGFX("lighteffect2");
            // TODO: Code
        }

        protected override void UnloadContent()
        {
            // TODO: Code
        }

        protected override void Update(GameTime gameTime)
        {
            InputState inputState = new InputState();

            Systems.Systems.Update.Scene(lastInputState, inputState, scenes[actualScene]);

            ChristianGame.lastInputState = inputState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(
                sortMode: SpriteSortMode.FrontToBack,
                blendState: BlendState.AlphaBlend,
                transformMatrix: scenes[actualScene].camera?.transform,
                effect: effect
            );

            Systems.Systems.Draw.Scene(spriteBatch, scenes[actualScene]);

            spriteBatch.End();
            base.Draw(gameTime);
        }


        GameWindow gameWindow;
        DisplayMode myDisplay;
        private void GameWindowSizeChangeEvent(object sender, System.EventArgs e)
        {
            // thanks to: https://stackoverflow.com/questions/45396416/how-can-i-detect-window-clientsizechanged-end#45403843


            // Unsubscribe
            Window.ClientSizeChanged -= GameWindowSizeChangeEvent;

            {
                // Good to know
                float aspectRatio = myDisplay.AspectRatio;
                int displayWidth = myDisplay.Width;
                int displayHeight = myDisplay.Height;

                var gameWindowWidth = gameWindow.ClientBounds.Width;
                var gameWindowHeight = gameWindow.ClientBounds.Height;

                // Code

                //ChristianGame.graphicsDeviceManager.PreferredBackBufferWidth = 700;
                //ChristianGame.graphicsDeviceManager.PreferredBackBufferHeight = 700;
                //ChristianGame.graphicsDeviceManager.ApplyChanges();

                gameWindow = Window;
            }

            // Subscribe
            Window.ClientSizeChanged += GameWindowSizeChangeEvent;
        }


        public static void ToggleFullScreen()
        {
            graphicsDeviceManager.ToggleFullScreen();
        }

        public static void ChangeToScene(string scene, Vector2? playerPosition = null)
        {
            JsonSerialization.Update(ChristianGame.gameData, ChristianGame.gameDataFileName);
            actualScene = scene;

            if (playerPosition != null)
                scenes[actualScene].Initialize(playerPosition);
            else
                scenes[actualScene].Initialize();
        }

        private static ChristianGame game;
        public static void MouseVisible(bool IsMouseVisible)
        {
            game.IsMouseVisible = IsMouseVisible;
        }
    }
}