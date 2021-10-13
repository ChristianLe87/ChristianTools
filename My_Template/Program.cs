using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace My_Template
{
    /*
    === Pasos ===
    1) Crear "Aplicacion de consola .Net 5"
    2) Agregar NuGet "MonoGame.Framework.DesktopGL"
    3) Agregar carpeta "Content" y agregar una imagen "Tree.png"
    4) Para usar imagen hacer click de opciones en el proyecto y "Agregar carpeta existentes" -> Agregar como vinculo "Tree.png"
    5) En el proyecto, seleccionar el archivo "Tree.png" que esta dentro de "Content" y click en propiedades, seleccionar "Copiar en directorio de salida: Copiar siempre"
    */

    class Program
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
        // a way to access the graphics devices (iPhone, Mac, Pc, PS4, etc)
        public static GraphicsDeviceManager graphicsDeviceManager;

        // Is used to draw sprites (a 2D or 3D images)
        SpriteBatch spriteBatch;

        public static ContentManager contentManager;

        Dictionary<string, IScene> scenes;
        string actualScene = "Scene_1";

        public Game1()
        {
            // Window
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.PreferredBackBufferWidth = 500;
            graphicsDeviceManager.PreferredBackBufferHeight = 500;
            graphicsDeviceManager.ApplyChanges();

            // FPS
            base.IsFixedTimeStep = true;
            base.TargetElapsedTime = TimeSpan.FromSeconds(1d / 60);
            //base.TargetElapsedTime = new TimeSpan(days: 0, hours: 0, minutes: 0, seconds: 0, milliseconds: 50); // Every frame is render each 50 milliseconds


            // Content
            string absolutePath = Path.Combine(Environment.CurrentDirectory, "Content");
            base.Content.RootDirectory = absolutePath;
            Game1.contentManager = base.Content;

            //base.Window.ClientBounds
            scenes = new Dictionary<string, IScene>()
            {
                {"Scene_1", new Scene_1() }
            };

            // others
            if (false)
            {
                base.Window.IsBorderless = true;
                Rectangle gameWindow = base.Window.ClientBounds;
                base.Window.Title = "Hello Window";
                base.IsMouseVisible = true;
            }

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // TODO: Code
            scenes[actualScene].Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // is graphicsDeviceManager
            //Game1.graphicsDeviceManager.GraphicsDevice.Clear(Color.CornflowerBlue);
            base.GraphicsDevice.Clear(Color.CornflowerBlue);


            this.spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            //this.spriteBatch.Begin();

            // TODO: Code
            this.scenes[actualScene].Draw(spriteBatch);

            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }

    public interface IScene
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }

    public class Scene_1 : IScene
    {
        Plyaer plyaer;
        Tree tree;

        public Scene_1()
        {
            this.plyaer = new Plyaer();
            this.tree = new Tree();
        }

        public void Update()
        {
            plyaer.Update();
            tree.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            plyaer.Draw(spriteBatch);
            tree.Draw(spriteBatch);
        }
    }

    public class Plyaer
    {
        Texture2D texture2D;
        Rectangle rectangle;
        float layer = 0.1f;


        public Plyaer()
        {
            texture2D = Tools.CreateColorTexture(
                graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                color:Color.Pink);

            rectangle = new Rectangle(250, 250, 20, 20);
        }

        public void Update()
        {
            // ===== Implementation =====
            {
                Vector2 oldPosition = new Vector2(rectangle.X, rectangle.Y);
                Vector2 newPosition = MovePlayer(oldPosition, 100, 100, 2);
                rectangle = new Rectangle((int)newPosition.X, (int)newPosition.Y, rectangle.Width, rectangle.Height);
            }

            // ===== Helpers =====
            Vector2 MovePlayer(Vector2 position, int minPosition, int maxPosition, int moveSpeed)
            {
                KeyboardState keyboardState = Keyboard.GetState();

                if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
                {
                    position.X -= moveSpeed;
                }
                else if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
                {
                    position.X += moveSpeed;
                }
                else if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
                {
                    position.Y -= moveSpeed;
                }
                else if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
                {
                    position.Y += moveSpeed;
                }

                return position;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture2D, rectangle, Color.White);
            spriteBatch.Draw(texture2D, new Vector2(rectangle.X, rectangle.Y), rectangle, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, layer);
        }
    }

    public class Tree
    {
        Texture2D texture2D;
        Rectangle rectangle { get => new Rectangle(10, 100, texture2D.Width, texture2D.Height); }
        float layer = 0.2f;

        public Tree()
        {
            texture2D = Tools.GetTexture(
                graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                contentManager: Game1.contentManager,
                imageName: "Tree");
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, new Vector2(rectangle.X, rectangle.Y), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, layer);
        }
    }

    public class Tools
    {
        /// <summary>
        /// Generate a new texture from a PNG file
        /// </summary>
        public static Texture2D GetTexture(GraphicsDevice graphicsDevice, ContentManager contentManager, string imageName, string folder = "")
        {
            string absolutePath = new DirectoryInfo(Path.Combine(Path.Combine(contentManager.RootDirectory, folder), $"{imageName}.png")).ToString();

            FileStream fileStream = new FileStream(absolutePath, FileMode.Open);

            var result = Texture2D.FromStream(graphicsDevice, fileStream);
            fileStream.Dispose();

            return result;
        }

        /// <summary>
        /// Create a new Texture2D from a Color
        /// </summary>
        public static Texture2D CreateColorTexture(GraphicsDevice graphicsDevice, Color color, int Width = 1, int Height = 1)
        {
            Texture2D texture2D = new Texture2D(graphicsDevice, Width, Height, false, SurfaceFormat.Color);
            Color[] colors = new Color[Width * Height];

            // Set each pixel to color
            colors = colors
                        .Select(x => x = color)
                        .ToArray();

            texture2D.SetData(colors);

            return texture2D;
        }
    }

}
