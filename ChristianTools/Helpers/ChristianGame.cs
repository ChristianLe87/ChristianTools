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
        // a way to access the graphics devices (iPhone, Mac, Pc, PS4, etc)
        public static GraphicsDeviceManager graphicsDeviceManager;

        // Is used to draw sprites (a 2D or 3D images)
        public static SpriteBatch spriteBatch;

        public static ContentManager contentManager;

        // Input
        private static InputState lastInputState;

        // Scenes
        static Dictionary<string, IScene> scenes;
        static string actualScene;
        public static IScene GetScene { get => scenes[actualScene]; }

        // GameData
        static string gameDataFileName;
        public static GameData gameData;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameDataFileName">File name of the GameData -> without the extension</param>
        public ChristianGame(string gameDataFileName, int canvasWidth = 500, int canvasHeight = 500, string windowTitle = "Game", bool isMouseVisible = true, bool IsFullScreen = false, bool AllowUserResizing = false)
        {
            ChristianGame.gameDataFileName = gameDataFileName;

            // Window
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.PreferredBackBufferWidth = canvasWidth;
            graphicsDeviceManager.PreferredBackBufferHeight = canvasHeight;
            graphicsDeviceManager.IsFullScreen = IsFullScreen;
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
            base.Window.Title = windowTitle;
            base.IsMouseVisible = isMouseVisible;
            game = this;



            if (AllowUserResizing == true)
            {
                Window.AllowUserResizing = AllowUserResizing;
                Window.ClientSizeChanged += GameWindowSizeChangeEvent;
            }


            ChristianGame.lastInputState = new InputState();

            // Initialize objects (scores, values, items, etc)
            base.Initialize();
        }




        public void SetupScenes(Dictionary<string, IScene> scenes, string startScene)
        {
            ChristianGame.scenes = scenes;
            ChristianGame.actualScene = startScene;
            scenes[actualScene].Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
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
            //scenes[actualScene].Update(lastInputState, inputState);   


            ChristianGame.lastInputState = inputState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(sortMode: SpriteSortMode.Deferred, blendState: BlendState.AlphaBlend, transformMatrix: scenes[actualScene].camera?.transform);

            Systems.Systems.Draw.Scene(spriteBatch, scenes[actualScene]);

            spriteBatch.End();
            base.Draw(gameTime);
        }




        private void GameWindowSizeChangeEvent(object sender, System.EventArgs e)
        {
            // thanks to: https://stackoverflow.com/questions/45396416/how-can-i-detect-window-clientsizechanged-end#45403843


            // Unsubscribe
            Window.ClientSizeChanged -= GameWindowSizeChangeEvent;

            {
                // Good to know
                DisplayMode myDisplay = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;
                float aspectRatio = myDisplay.AspectRatio;
                int displayWidth = myDisplay.Width;
                int displayHeight = myDisplay.Height;

                GameWindow gameWindow = Window;
                var gameWindowWidth = gameWindow.ClientBounds.Width;
                var gameWindowHeight = gameWindow.ClientBounds.Height;


                //ChristianGame.graphicsDeviceManager.PreferredBackBufferWidth = 700;
                //ChristianGame.graphicsDeviceManager.PreferredBackBufferHeight = 700;
                //ChristianGame.graphicsDeviceManager.ApplyChanges();

                int bla = 0;
            }

            // Subscribe
            Window.ClientSizeChanged += GameWindowSizeChangeEvent;
        }


        public static void ToggleFullScreen()
        {
            graphicsDeviceManager.ToggleFullScreen();
        }


        public static void ChangeToScene(string scene)
        {
            JsonSerialization.Update(ChristianGame.gameData, ChristianGame.gameDataFileName);
            actualScene = scene;
            scenes[actualScene].Initialize();
        }

        private static ChristianGame game;
        public static void MouseVisible(bool IsMouseVisible)
        {
            game.IsMouseVisible = IsMouseVisible;
        }
    }
}