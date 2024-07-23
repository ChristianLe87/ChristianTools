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


        public IGameDataSystem GameDataSystem;
        public static GameData gameData;


        // Order: 1
        public ChristianGame(IDefault _WK, IGameDataSystem _GameDataSystem)
        {
            this.GameDataSystem = _GameDataSystem;

            // WK
            ChristianGame.WK = _WK;


            // Scene
            ChristianGame.scenes = WK.Scenes;
            ChristianGame.actualScene = WK.Scenes.FirstOrDefault().Key;


            // Window
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            if (WK.IsFullScreen == true)
            {
                WK.ScaleFactor = (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / WK.CanvasHeight);

                WK.CanvasWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                WK.CanvasHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            }
            else
            {
                graphicsDeviceManager.PreferredBackBufferWidth = WK.CanvasWidth;
                graphicsDeviceManager.PreferredBackBufferHeight = WK.CanvasHeight;
            }

            graphicsDeviceManager.IsFullScreen = WK.IsFullScreen;
            //graphicsDeviceManager.ToggleFullScreen();

            // Set up multisampling and take off VSync to help with the camera efficiency
            graphicsDeviceManager.PreferMultiSampling = true;
            graphicsDeviceManager.SynchronizeWithVerticalRetrace = false;

            graphicsDeviceManager.ApplyChanges();


            // FPS
            base.IsFixedTimeStep = true;
            base.TargetElapsedTime = TimeSpan.FromSeconds(1d / WK.FPS);
            //base.TargetElapsedTime = new TimeSpan(days: 0, hours: 0, minutes: 0, seconds: 0, milliseconds: 50); // Every frame is render each 50 milliseconds


            // others
            base.Window.Title = WK.WindowTitle;
            base.IsMouseVisible = WK.IsMouseVisible;
            //game = this;


            // Content
            Content.RootDirectory = "Content";
            //string absolutePath = Path.Combine(Environment.CurrentDirectory, "Content");
            //base.Content.RootDirectory = absolutePath;
            //ChristianGame.contentManager = base.Content;

            // Game data
            gameData = GameDataSystem.GetFromDevice();


            // use with GameWindowSizeChangeEvent()
            if (WK.AllowUserResizing == true)
            {
                Window.AllowUserResizing = WK.AllowUserResizing;
                Window.ClientSizeChanged += GameWindowSizeChangeEvent;
            }

            lastInputState = new InputState();



            ChristianTools.Helpers.GraphicTools.ChangeGameWindow(WK.CanvasWidth, WK.CanvasHeight);
            ChristianTools.Helpers.GraphicTools.ChangeViewport(new Rectangle(0, 0, WK.CanvasWidth, WK.CanvasHeight));
        }

        // Order: 2
        protected override void Initialize()
        {
            // Code
            base.Initialize();
        }

        // Order: 3
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Code
            atlasEntities = ChristianTools.Helpers.Texture.GetTextureFromFile(graphicsDeviceManager.GraphicsDevice, ChristianGame.WK.Atlas_Entities);
            atlasTileset = ChristianTools.Helpers.Texture.GetTextureFromFile(graphicsDeviceManager.GraphicsDevice, ChristianGame.WK.Atlas_Tileset);
            spriteFont = ChristianTools.Helpers.Font.GenerateFont(texture2D: ChristianTools.Helpers.Texture.GetTextureFromFile(graphicsDeviceManager.GraphicsDevice, WK.FontFileName));

            scenes[actualScene].Initialize();
        }


        private int count = 0;
        private TimeSpan lastAutosavedTime = new TimeSpan();

        // Order: 4
        protected override void Update(GameTime gameTime)
        {
            InputState inputState = new InputState();

#if !__MOBILE__
            if (inputState.Escape)
                Exit();
#endif

            // Autosave
            lastAutosavedTime += gameTime.ElapsedGameTime;

            if (lastAutosavedTime.Seconds > 10)
            {
                GameDataSystem.SaveInDevice(gameData);
                lastAutosavedTime = new TimeSpan();
            }


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

        // Order: 5
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


            // ToDo: code
            {
                // --Good to know--
                //DisplayMode displayMode = graphicsDeviceManager.GraphicsDevice.Adapter.CurrentDisplayMode; // Detalles sobre la pantalla donde esta gameWindow
                // displayMode.TitleSafeArea -> Rectangle of W,H,X,Y

                //GameWindow gameWindow = Window; // representa la ventana del juego en la que se presenta el contenido renderizado.
                // gameWindow.ClientBounds -> Rectangle of W,H,X,Y

                //Viewport viewport = ChristianGame.graphicsDeviceManager.GraphicsDevice.Viewport; // el área dentro de gameWindow donde se renderiza una escena
                // viewport.Bounds -> Rectangle of W,H,X,Y





                ChristianTools.Helpers.GraphicTools.ChangeGameWindow(WK.CanvasWidth, WK.CanvasHeight);
                ChristianTools.Helpers.GraphicTools.ChangeViewport(new Rectangle(0, 0, WK.CanvasWidth, WK.CanvasHeight));

                // update vp
                /*Viewport newViewport = new Viewport();
                newViewport.Bounds = new Rectangle(50, 50, 500, 500);
                ChristianGame.graphicsDeviceManager.GraphicsDevice.Viewport = newViewport;*/

                // Update WK
                //ChristianGame.WK.Viewport = newViewport.Bounds;


                // Update all my UIs
                foreach (var ui in scenes[actualScene].UIs)
                {
                    ui.UpdateOnGameWindowSizeChangeEvent();
                }
            }


            // Subscribe
            Window.ClientSizeChanged += GameWindowSizeChangeEvent;
        }
    }
}