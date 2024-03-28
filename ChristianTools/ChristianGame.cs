using System;
using System.Collections.Generic;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChristianTools
{
    public class ChristianGame : Game
    {
        public static Texture2D atlasTiles;
        public static Texture2D atlasEntities;
        public static SpriteFont spriteFont;

        public static GraphicsDeviceManager graphicsDeviceManager;

        private SpriteBatch spriteBatch;

        public static IDefault WK;

        private static Dictionary<string, IScene> scenes { get; set; }
        private static string actualScene { get; set; }

        public static IScene GetScene => scenes[actualScene];

        private InputState lastInputState;

        public ChristianGame(Dictionary<string, IScene> scenes, string startScene, IDefault WK)
        {
            // WK
            ChristianGame.WK = WK;

            // Scene
            ChristianGame.scenes = scenes;
            ChristianGame.actualScene = startScene;


            // Window
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2;
            graphicsDeviceManager.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2;
            graphicsDeviceManager.IsFullScreen = WK.IsFullScreen;
            
            // Set up multisampling and take off VSync to help with the camera efficiency
            graphicsDeviceManager.PreferMultiSampling = true;
            graphicsDeviceManager.SynchronizeWithVerticalRetrace = false;

            
            //graphicsDeviceManager.ToggleFullScreen();
            graphicsDeviceManager.ApplyChanges();
            //Actual monitor size: GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;
            //var bla = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;

            
            // FPS
            base.IsFixedTimeStep = true;
            base.TargetElapsedTime = TimeSpan.FromSeconds(1d / WK.FPS);
            //base.TargetElapsedTime = new TimeSpan(days: 0, hours: 0, minutes: 0, seconds: 0, milliseconds: 50); // Every frame is render each 50 milliseconds


            // others
            base.Window.Title = WK.WindowTitle;
            base.IsMouseVisible = WK.isMouseVisible;
            //Window.AllowUserResizing = WK.AllowUserResizing;
            //game = this;
            

            // Content
            Content.RootDirectory = "Content";
            //string absolutePath = Path.Combine(Environment.CurrentDirectory, "Content");
            //base.Content.RootDirectory = absolutePath;
            //ChristianGame.contentManager = base.Content;

            lastInputState = new InputState();
        }

        protected override void Initialize()
        {
            // Code
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            scenes[actualScene].Initialize();

            // Code
            atlasTiles = ChristianTools.Helpers.Texture.GetTextureFromFile(graphicsDeviceManager.GraphicsDevice, ChristianGame.WK.Atlas_Tileset);
            atlasEntities = ChristianTools.Helpers.Texture.GetTextureFromFile(graphicsDeviceManager.GraphicsDevice, ChristianGame.WK.Atlas_Entities);
            spriteFont = ChristianTools.Helpers.Font.GenerateFont(texture2D: ChristianTools.Helpers.Texture.GetTextureFromFile(graphicsDeviceManager.GraphicsDevice, WK.FontFileName));
        }


        private int count = 0;
        protected override void Update(GameTime gameTime)
        {
            InputState inputState = new InputState();

            if (inputState.Escape)
                Exit();


            // FPS
            if(false)
            {
                count++;
                if (count > WK.FPS/5)
                {
                    System.Console.WriteLine($"=== FPS: {(int)(1/gameTime.ElapsedGameTime.TotalSeconds)} ===");
                    count = 0;
                }
            }

            Systems.Update.Scene.Update(lastInputState: lastInputState, inputState: inputState);

            lastInputState = new InputState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            DrawWorld();
            DrawUI();

            base.Draw(gameTime);
        }

        private void DrawUI()
        {
            spriteBatch.Begin();
            {
                Systems.Draw.Scene.DrawUI(spriteBatch, GetScene);
            }
            spriteBatch.End();
        }

        private void DrawWorld()
        {
            //https://community.monogame.net/t/fitting-pixel-art-game-to-screen/17043
            spriteBatch.Begin(sortMode: SpriteSortMode.Immediate, blendState: BlendState.AlphaBlend, samplerState: SamplerState.PointClamp, transformMatrix: scenes[actualScene].camera?.transform);
            {
                Systems.Draw.Scene.DrawWorld(spriteBatch,GetScene);
            }
            spriteBatch.End();
        }


        public static void ChangeToScene(string sceneName)
        {
            actualScene = sceneName;
            scenes[actualScene].Initialize();
        }
    }
}