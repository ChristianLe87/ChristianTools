using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ChristianTools;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Systems;
using ChristianTools.Tools;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace My_Template
{
    /*
    === Pasos ===
    1) Crear "Aplicacion de consola .Net 5"
    2) Agregar NuGet: "MonoGame.Framework.DesktopGL"
    3) Agregar NuGet: "Newtonsoft.Json"
    4) Agregar carpeta "Content"
    5) En carpeta "Content" agregar imagen "Tree.png"
    6) En carpeta "Content" agregar imagen "MyFont_130x28_PNG.png"
    7) Para usar imagen hacer click de opciones en el proyecto y "Agregar carpeta existentes" -> Agregar como vinculo "Tree.png" y "MyFont_130x28_PNG.png"
    8) En el proyecto, seleccionar el archivo "Tree.png" que esta dentro de "Content" y click en propiedades, seleccionar "Copiar en directorio de salida: Copiar siempre"
    9) En el proyecto, seleccionar el archivo "MyFont_130x28_PNG.png" que esta dentro de "Content" y click en propiedades, seleccionar "Copiar en directorio de salida: Copiar siempre"
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

    public class WK
    {
        public class Default
        {
            public static string WindowTitle => "Template Game";

            public static int CanvasWidth => 500;
            public static int CanvasHeight => 500;

            public static string GameDataFileName => "MyTemplate_GameData";
            public static readonly int ScaleFactor = 3;
        }

        public class Scene
        {
            public static string Intro => "SceneIntro";
            public static string Menu => "SceneMenu";
            public static string About => "SceneAbout";
            public static string Game => "SceneGame";
        }

        public class Font
        {
            static Texture2D texture2D = Tools.Texture.GetTexture("MyFont_130x28_PNG", WK.Default.ScaleFactor);
            static char[,] chars = new char[,]
            {
                { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
                { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },
                { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ñ', 'ñ', 'ß','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0' },
                { ',', ':', ';', '?', '.', '!', ' ','\'','(',')','_','\"','<','>','-','+','\\','\0','\0','\0','\0','\0','\0','\0','\0','\0' }
            };

            public static SpriteFont MyFont_130x28 => Tools.Font.GenerateFont(texture2D, chars);
        }

        public class Texture
        {
            public class PixelColor
            {
                public static Texture2D Gray = Tools.Texture.CreateColorTexture(Color.Gray);
                public static Texture2D LightGray = Tools.Texture.CreateColorTexture(Color.LightGray);

                public static Texture2D Red = Tools.Texture.CreateColorTexture(Color.Red);
            }

            public static Texture2D Tree => Tools.Texture.GetTexture("Tree");
        }
    }

    public class Game1 : ChristianGame
    {
        public Game1() : base(
            gameDataFileName: WK.Default.GameDataFileName,
            canvasHeight: WK.Default.CanvasHeight,
            canvasWidth: WK.Default.CanvasWidth,
            windowTitle: WK.Default.WindowTitle
            )
        {

            Dictionary<string, IScene> scenes = new Dictionary<string, IScene>()
            {
                { WK.Scene.Intro, new SceneIntro() },
                { WK.Scene.Menu,  new Factory.SceneMenu(WK.Font.MyFont_130x28, WK.Scene.Game)},
                { WK.Scene.About, new SceneAbout() },
                { WK.Scene.Game, new SceneGame() }
            };

            base.SetupScenes(scenes, WK.Scene.Menu);
        }
    }

    public class SceneIntro : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Camera camera { get; private set; }
        public Map map { get; private set; }

        public DxSceneInitializeSystem dxSceneInitializeSystem { get; private set; }
        public DxSceneUpdateSystem dxSceneUpdateSystem { get; private set; }
        public DxSceneDrawSystem dxSceneDrawSystem { get; private set; }

        public void Initialize(Vector2? playerPosition = null)
        {
        }
    }

    public class SceneAbout : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Camera camera { get; private set; }
        public Map map { get; private set; }

        public DxSceneInitializeSystem dxSceneInitializeSystem { get; private set; }
        public DxSceneUpdateSystem dxSceneUpdateSystem { get; private set; }
        public DxSceneDrawSystem dxSceneDrawSystem { get; private set; }

        public void Initialize(Vector2? playerPosition = null)
        {
        }
    }

    public class SceneGame : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Camera camera { get; private set; }
        public Map map { get; private set; }

        public DxSceneInitializeSystem dxSceneInitializeSystem { get; private set; }
        public DxSceneUpdateSystem dxSceneUpdateSystem { get; private set; }
        public DxSceneDrawSystem dxSceneDrawSystem { get; private set; }

        public void Initialize(Vector2? playerPosition = null)
        {
            this.UIs = new List<IUI>()
            {
                new Label(new Rectangle(), WK.Font.MyFont_130x28, "SceneGame", Label.TextAlignment.Top_Left, "", camera)
            };

            this.entities = new List<IEntity>()
            {
                new Tree(),
                new Player(),
            };
        }
    }

    public class Player : IEntity
    {
        public Animation animation { get; private set; }
        public Rigidbody rigidbody { get; private set; }
        public CharacterState characterState { get; set; }
        public bool isActive { get; set; }
        public string tag { get; private set; }
        public int health { get; private set; }
        public ExtraComponents extraComponents { get; set; }

        public DxEntityInitializeSystem dxEntityInitializeSystem { get; private set; }
        public DxEntityUpdateSystem dxEntityUpdateSystem { get; private set; }
        public DxEntityDrawSystem dxEntityDrawSystem { get; private set; }

        public Player()
        {
            Texture2D texture2D = Tools.Texture.CreateColorTexture(Color.Pink, 10 * WK.Default.ScaleFactor, 10 * WK.Default.ScaleFactor);
            this.animation = new Animation(texture2D);
            this.rigidbody = new Rigidbody(new Vector2(200, 200), this);
            this.isActive = true;
            this.dxEntityUpdateSystem = (InputState lastInputState, InputState inputState, IEntity entity) => Systems.Update.Player.Basic_XY_Movement(inputState, this, WK.Default.ScaleFactor);
        }
    }

    public class Tree : IEntity
    {
        public Animation animation { get; private set; }
        public Rigidbody rigidbody { get; private set; }
        public CharacterState characterState { get; set; }
        public bool isActive { get; set; }
        public string tag { get; private set; }
        public int health { get; private set; }
        public ExtraComponents extraComponents { get; set; }

        public DxEntityInitializeSystem dxEntityInitializeSystem { get; private set; }
        public DxEntityUpdateSystem dxEntityUpdateSystem { get; private set; }
        public DxEntityDrawSystem dxEntityDrawSystem { get; private set; }

        public Tree()
        {
            this.animation = new Animation(WK.Texture.Tree);

            this.rigidbody = new Rigidbody(new Vector2(200, 200), this);

            this.isActive = true;
        }
    }
}