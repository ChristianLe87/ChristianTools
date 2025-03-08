
namespace Showroom.Scenes
{
    public class MyTestUI : IUI
    {
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
        public bool isActive { get; set; }
        public string tag { get; }


        Texture2D texture;
        private Alignment UI_Position = Alignment.Null;
        private Rectangle rectangle;

        public MyTestUI()
        {
            this.isActive = true;
            this.UI_Position = Alignment.Down_Right;
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => MyDraw(spriteBatch);


            // Texture
            this.texture = GetTexture(Color.Red);

            // Position
            int margin = 0;
            this.rectangle = GetRectangle(margin);
        }

        private Rectangle GetRectangle(int margin)
        {
            Rectangle rectangle = new Rectangle(0, 0, 100, 100);
            rectangle.X = ChristianGame.WK.Viewport.Width - rectangle.Width - margin;
            rectangle.Y = ChristianGame.WK.Viewport.Height - rectangle.Height - margin;

            return rectangle;
        }

        private Texture2D GetTexture(Color color)
        {
            // Crear una textura de 1x1 píxel (blanca)
            Texture2D texture = new Texture2D(ChristianGame.graphicsDeviceManager.GraphicsDevice, 1, 1);
            texture.SetData(new[] { color }); // Rellenar la textura con color blanco
            return texture;
        }

        public void UpdateOnGameWindowSizeChangeEvent()
        {
            int bla = ChristianGame.WK.CanvasWidth;
            this.rectangle = GetRectangle(0);

        }

        private void MyDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }

    public class Scene_Test : BaseScene
    {
        public override void Initialize()
        {
            this.UIs = new List<IUI>()
            {
                new MyTestUI(),

                new Button(
                    UI_Position: Alignment.Down_Left,
                    width: 230,
                    height: 30,
                    margin: 10,
                    text: "<-- Back to menu",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    tag: "",
                    OnClickAction: () => Game1.ChangeToScene("Scene_Menu")
                ),

                new ZeroZeroPoint_UI()
            };

            this.entities = new List<IEntity>()
            {
                new ZeroZeroPoint_Entity(),

                // TL
                new Entity_Numbers(MyRectangle.GetRectangleBaseOnCanvasPosition(Alignment.Top_Left, 16, 16)),

                // TR
                new Entity_Numbers(MyRectangle.GetRectangleBaseOnCanvasPosition(Alignment.Top_Right, 16, 16)),

                // Center
                new Entity_WASD(
                    rectangle: MyRectangle.GetRectangleBaseOnCanvasPosition(Alignment.Midle_Center, 16, 16),
                    tag: "player"
                ),

                // DL
                new Entity_Numbers(MyRectangle.GetRectangleBaseOnCanvasPosition(Alignment.Down_Left, 16, 16)),

                // DR
                new Entity_Numbers(MyRectangle.GetRectangleBaseOnCanvasPosition(Alignment.Down_Right, 16, 16)),
            };

            this.camera = new Camera(entityToFollow: entities.Find(x => x.tag == "player"));
        }
    }
}
