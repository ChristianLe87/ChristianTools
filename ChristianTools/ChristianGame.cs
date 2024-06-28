namespace ChristianTools
{
    public class ChristianGame : Game
    {
        public static Texture2D atlasTileset;
        public static Texture2D atlasEntities;
        public static SpriteFont spriteFont;

        public static GraphicsDeviceManager graphicsDeviceManager;

        private SpriteBatch spriteBatch;

        public static IDefault WK;

        private static Dictionary<string, IScene> scenes { get; set; }
        private static string actualScene { get; set; }

        public static IScene GetScene => scenes[actualScene];

        private InputState lastInputState;


        public static Dictionary<string, object> gameData;

        
        
        public ChristianGame(IDefault _WK)
        {
            if (_WK.IsFullScreen == true)
            {
                _WK.ScaleFactor = (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / _WK.CanvasHeight);

                _WK.CanvasWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                _WK.CanvasHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            }

            // WK
            ChristianGame.WK = _WK;

            // Scene
            ChristianGame.scenes = WK.Scenes;
            ChristianGame.actualScene = WK.Scenes.FirstOrDefault().Key;


            // Window
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.PreferredBackBufferWidth = WK.CanvasWidth; // GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2;
            graphicsDeviceManager.PreferredBackBufferHeight = WK.CanvasHeight; // GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2;
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
            base.IsMouseVisible = WK.IsMouseVisible;
            //Window.AllowUserResizing = WK.AllowUserResizing;
            //game = this;


            // Content
            Content.RootDirectory = "Content";
            //string absolutePath = Path.Combine(Environment.CurrentDirectory, "Content");
            //base.Content.RootDirectory = absolutePath;
            //ChristianGame.contentManager = base.Content;

            
            // GameData File
            {
                // new
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    if (GameDataHelpers._Folder.Exist() == true)
                    {
                        if (GameDataHelpers._File.Exist(WK.GameDataFileName) == false)
                        {
                            GameDataHelpers._File.Create(new Dictionary<string, object>(), "MyTestData");
                        }
                    }
                    else
                    {
                        GameDataHelpers._Folder.Create();
                        GameDataHelpers._File.Create(new Dictionary<string, object>(), WK.GameDataFileName);
                    }
                    
                    gameData = GameDataHelpers._File.Read(WK.GameDataFileName);
                }
                else
                {
                    gameData = new Dictionary<string, object>();
                }
            }


            
            




            // use with GameWindowSizeChangeEvent()
            if (WK.AllowUserResizing == true)
            {
                Window.AllowUserResizing = WK.AllowUserResizing;
                Window.ClientSizeChanged += GameWindowSizeChangeEvent;
            }


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

            // Code
            atlasEntities = ChristianTools.Helpers.Texture.GetTextureFromFile(graphicsDeviceManager.GraphicsDevice, ChristianGame.WK.Atlas_Entities);
            atlasTileset = ChristianTools.Helpers.Texture.GetTextureFromFile(graphicsDeviceManager.GraphicsDevice, ChristianGame.WK.Atlas_Tileset);
            spriteFont = ChristianTools.Helpers.Font.GenerateFont(texture2D: ChristianTools.Helpers.Texture.GetTextureFromFile(graphicsDeviceManager.GraphicsDevice, WK.FontFileName));

            scenes[actualScene].Initialize();


            // Setup Viewport
            if (false)
            {
                Viewport viewport = ChristianGame.graphicsDeviceManager.GraphicsDevice.Viewport;
                viewport.Bounds = new Rectangle(WK.CanvasWidth / 2, WK.CanvasHeight / 2, 100, 100);
                ChristianGame.graphicsDeviceManager.GraphicsDevice.Viewport = viewport;
            }

        }


        private int count = 0;

        protected override void Update(GameTime gameTime)
        {
            InputState inputState = new InputState();

            if (inputState.Escape)
                Exit();


            // FPS
            if (false)
            {
                count++;
                if (count > WK.FPS / 5)
                {
                    System.Console.WriteLine($"=== FPS: {(int)(1 / gameTime.ElapsedGameTime.TotalSeconds)} ===");
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
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack /*.Immediate*/, blendState: BlendState.AlphaBlend, samplerState: SamplerState.PointClamp, transformMatrix: scenes[actualScene].camera?.transform);
            {
                Systems.Draw.Scene.DrawWorld(spriteBatch, GetScene);
            }
            spriteBatch.End();
        }


        public static void ChangeToScene(string sceneName)
        {
            actualScene = sceneName;
            scenes[actualScene].Initialize();
        }





        private void GameWindowSizeChangeEvent(object sender, System.EventArgs e)
        {
            // thanks to: https://stackoverflow.com/questions/45396416/how-can-i-detect-window-clientsizechanged-end#45403843

 

            // Unsubscribe
            Window.ClientSizeChanged -= GameWindowSizeChangeEvent;

            // Update WK
            WK.CanvasWidth = Window.ClientBounds.Width;
            WK.CanvasHeight = Window.ClientBounds.Height;
            
            // Update UIs
            foreach (var ui in scenes[actualScene].UIs)
            {
                ui.UpdateOnGameWindowSizeChangeEvent();
            }
            
            // ToDo: code
            {
                // Good to know:
                //GameWindow gameWindow = Window;
                //DisplayMode myDisplay = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;
                
                //float aspectRatio = myDisplay.AspectRatio;
                //int displayWidth = myDisplay.Width;
                //int displayHeight = myDisplay.Height;

                //int gameWindowWidth = gameWindow.ClientBounds.Width;
                //int gameWindowHeight = gameWindow.ClientBounds.Height;
            }

            // Subscribe
            Window.ClientSizeChanged += GameWindowSizeChangeEvent;
        }

        private void SetupViewport()
        {
            // Play with Viewport

            // This will crate a rec
            if (false)
            {
                Viewport viewport = ChristianGame.graphicsDeviceManager.GraphicsDevice.Viewport;


                if (false)
                {
                    viewport.Width = 100;
                    viewport.Height = 100;
                    viewport.X = WK.CanvasWidth / 2;
                    viewport.Y = WK.CanvasHeight / 2;
                }
                else
                {
                    viewport.Bounds = new Rectangle(WK.CanvasWidth / 2, WK.CanvasHeight / 2, 100, 100);
                }

                ChristianGame.graphicsDeviceManager.GraphicsDevice.Viewport = viewport;
            }
        }
    }
}