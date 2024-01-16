using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools
{
    public class ChristianGame : Game
    {
        public static Texture2D atlasTexture2D;
        public static SpriteFont spriteFont;

        public static GraphicsDeviceManager graphicsDeviceManager;
    
        private SpriteBatch spriteBatch;

        public static IDefault WK;

        public static Dictionary<string, IScene> scenes { get; set; }
        public static string actualScene { get; private set; }

        private InputState lastInputState;

        public ChristianGame(Dictionary<string, IScene> scenes, string startScene, IDefault WK)
        {
            // WK
            ChristianGame.WK = WK;
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
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            scenes[actualScene].Initialize(spriteBatch.GraphicsDevice.Viewport);

            // TODO: use this.Content to load your game content here
            atlasTexture2D = ChristianTools.Helpers.Texture.GetTextureFromFile(graphicsDeviceManager.GraphicsDevice, ChristianGame.WK.AtlasTextureFileName);

            spriteFont = ChristianTools.Helpers.Font.GenerateFont(texture2D: ChristianTools.Helpers.Texture.GetTextureFromFile(graphicsDeviceManager.GraphicsDevice, WK.FontFileName/*MyFont_130x28_PNG*/));
        }

        protected override void Update(GameTime gameTime)
        {
            InputState inputState = new InputState();

            ChristianTools.Systems.Update.Scene(graphicsDeviceManager.GraphicsDevice.Viewport, lastInputState, inputState, scenes[actualScene]);
            
            lastInputState = new InputState();
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            //_spriteBatch.Begin();

            
            // Original
            //spriteBatch.Begin(sortMode: SpriteSortMode.Immediate, blendState: BlendState.AlphaBlend, transformMatrix: scenes[actualScene].camera?.transform, effect: null);

            
            //https://community.monogame.net/t/fitting-pixel-art-game-to-screen/17043
            spriteBatch.Begin(
                sortMode: SpriteSortMode.Immediate,
                samplerState: SamplerState.PointClamp,
                transformMatrix: scenes[actualScene].camera?.transform,
                blendState: BlendState.AlphaBlend
            );

            // Scene
            if (scenes[actualScene].dxDrawSystem != null)
            {
                scenes[actualScene].dxDrawSystem(spriteBatch, scenes[actualScene]);
            }

            // Entity
            if (scenes[actualScene].entities != null)
            {
                foreach (var entity in scenes[actualScene].entities)
                {
                    ChristianTools.Systems.Draw.Entity(spriteBatch, scenes[actualScene], entity);
                }
            }


            // UIs
            if (scenes[actualScene].UIs != null)
            {
                foreach (IUI ui in scenes[actualScene].UIs)
                {
                    if (ui.dxDrawSystem != null)
                    {
                        ui.dxDrawSystem(spriteBatch, scenes[actualScene]);
                    }
                }
            }


            spriteBatch.End();

            base.Draw(gameTime);
        }
        
        
        public static void ChangeToScene(string scene, Vector2? playerPosition = null)
        {
            //JsonSerialization.Update(ChristianGame.gameData, ChristianGame.gameDataFileName);
            actualScene = scene;

            scenes[actualScene].Initialize(graphicsDeviceManager.GraphicsDevice.Viewport);

            /*
            if (playerPosition != null)
                scenes[actualScene].Initialize(playerPosition);
            else
                scenes[actualScene].Initialize(graphicsDeviceManager.GraphicsDevice.Viewport);
            */
        }
    }
}