using System;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.UI;
using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Scene_Others_PunchHole : IScene
    {

        public GameState gameState { get; }

        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }

        public List<SoundEffect> soundEffects { get; set; }

        public Camera camera { get; }

        public Map map { get; }

        public DxSceneUpdateSystem dxSceneUpdateSystem { get; }

        public DxSceneDrawSystem dxSceneDrawSystem { get; }

        public Scene_Others_PunchHole()
        {
            Initialize();
        }

        public void Initialize(Vector2? playerPosition = null)
        {
            this.UIs = new List<IUI>()
            {
                new Label(
                    rectangle: new Rectangle(260, 10, 230, 30),
                    spriteFont: WK.Font.font_7,
                    "PunchHole",
                    Label.TextAlignment.Midle_Center,
                    ""
                ),
                new Button(
                    rectangle: new Rectangle (0, 470, 230, 30),
                    text: "<- Others",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "goToOthers",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Others)
                ),
            };

            this.entities = new List<IEntity>()
            {
                new Light(new Point(30, 30)),
                new Player(new Point(100,100))
            };



            Point[] points = entities.Select(x => x.rigidbody.centerPosition.ToPoint()).ToArray();
            UIs.Add(new Shadow(points));
        }

        private class Player : IEntity
        {

            public Animation animation { get; }
            public Rigidbody rigidbody { get; }
            public CharacterState characterState { get; set; }
            public bool isActive { get; set; }
            public string tag { get; }
            public int health { get; }

            public DxEntityUpdateSystem dxEntityUpdateSystem { get; }
            public DxEntityDrawSystem dxEntityDrawSystem { get; }

            public Player(Point point)
            {
                this.isActive = true;
                this.rigidbody = new Rigidbody(point.ToVector2(), this);
                this.animation = new Animation(Tools.Texture.ScaleTexture(WK.Texture.Red, 50));
                this.dxEntityUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem(lastInputState, inputState);
            }

            private void UpdateSystem(InputState lastInputState, InputState inputState)
            {
                Point mousePosition = inputState.Mouse_Position();
                rigidbody.SetCenterPosition = mousePosition.ToVector2();
            }
        }

        private class Light : IEntity
        {
            public Animation animation { get; }
            public Rigidbody rigidbody { get; }
            public CharacterState characterState { get; set; }
            public bool isActive { get; set; }
            public string tag { get; }
            public int health { get; }

            public DxEntityUpdateSystem dxEntityUpdateSystem { get; }
            public DxEntityDrawSystem dxEntityDrawSystem { get; }

            public Light(Point point)
            {
                this.isActive = true;
                this.animation = new Animation(WK.Texture.Blue);
                this.rigidbody = new Rigidbody(point.ToVector2(), this);
            }
        }

        private class Shadow : IUI
        {
            public Rectangle rectangle { get; }

            public Texture2D texture { get; private set; }
            public Texture2D originalTexture { get; private set; }

            public string tag { get; }

            public bool isActive { get; set; }

            public DxUiUpdateSystem dxUiUpdateSystem { get; }

            public DxUiDrawSystem dxUiDrawSystem { get; }

            public Shadow(Point[] lights)
            {
                this.isActive = true;
                this.rectangle = new Rectangle(0, 0, ChristianGame.Default.canvasWidth, ChristianGame.Default.canvasHeight);

                Color color = Color.Black;
                color.A = 150;
                this.originalTexture = Tools.Texture.CreateColorTexture(color, rectangle.Width, rectangle.Height);

                this.texture = Tools.Texture.PunchHole(originalTexture, lights, 40, 20);
            }
        }
    }
}