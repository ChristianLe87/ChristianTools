using System;
using System.Collections.Generic;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Showroom;

namespace ChristianTools
{
    public class ChristianGame : Game
    {
        private Texture2D texture2D_X;
        private Texture2D texture2D_Y;

     
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
            graphicsDeviceManager.PreferredBackBufferWidth = WK.canvasWidth;
            graphicsDeviceManager.PreferredBackBufferHeight = WK.canvasHeight;
            graphicsDeviceManager.IsFullScreen = WK.IsFullScreen;
            //graphicsDeviceManager.ToggleFullScreen();
            //graphicsDeviceManager.ApplyChanges();
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

            // test
            texture2D_X = ChristianTools.Helpers.Texture.CreateColorTexture(Color.Red, 2, 200);
            texture2D_Y = ChristianTools.Helpers.Texture.CreateColorTexture(Color.Green, 200, 2);
        }

        private int yeahCount = 0;
        protected override void Update(GameTime gameTime)
        {
            InputState inputState = new InputState();
            
            if (inputState.IsKeyboardKeyDown(Keys.Escape)) Exit();
            
            
            // Scene
            {
                ChristianTools.Systems.Update.Scene.UpdateSystem(lastInputState: lastInputState, inputState: inputState);
                scenes[actualScene].dxUpdateSystem?.Invoke(lastInputState: lastInputState, inputState: inputState);
            }
            
            lastInputState = new InputState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            //https://community.monogame.net/t/fitting-pixel-art-game-to-screen/17043
            spriteBatch.Begin(
                sortMode: SpriteSortMode.Immediate,
                samplerState: SamplerState.PointClamp,
                transformMatrix: scenes[actualScene].camera?.transform,
                blendState: BlendState.AlphaBlend
            );

            {
                // Debug X Y
                spriteBatch.Draw(texture2D_X, new Rectangle(-texture2D_X.Width / 2, -texture2D_X.Height / 2, texture2D_X.Width, texture2D_X.Height), Color.White);
                spriteBatch.Draw(texture2D_Y, new Rectangle(-texture2D_Y.Width / 2, -texture2D_Y.Height / 2, texture2D_Y.Width, texture2D_Y.Height), Color.White);
            }
            
            // Scene
            {
                ChristianTools.Systems.Draw.Scene.DrawSystem(spriteBatch: spriteBatch);
                scenes[actualScene].dxDrawSystem?.Invoke(spriteBatch: spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }


        public static void ChangeToScene(string scene, Vector2? playerPosition = null)
        {
            //JsonSerialization.Update(ChristianGame.gameData, ChristianGame.gameDataFileName);
            actualScene = scene;

            scenes[actualScene].Initialize();

            /*
            if (playerPosition != null)
                scenes[actualScene].Initialize(playerPosition);
            else
                scenes[actualScene].Initialize(graphicsDeviceManager.GraphicsDevice.Viewport);
            */
        }
    }
}