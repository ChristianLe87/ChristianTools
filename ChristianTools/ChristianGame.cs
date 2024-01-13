using System.Collections.Generic;
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
            ChristianGame.WK = WK;
            ChristianGame.scenes = scenes;
            ChristianGame.actualScene = startScene;
            
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
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

            spriteBatch.Begin(
                sortMode: SpriteSortMode.Immediate,
                blendState: BlendState.AlphaBlend,
                transformMatrix: scenes[actualScene].camera?.transform,
                effect: null
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