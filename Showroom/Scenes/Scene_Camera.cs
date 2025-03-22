namespace Showroom.Scenes
{
    public class Scene_Camera : BaseScene
    {
        public override void Initialize()
        {
            int ts = ChristianGame.WK.TileSize;

            this.UIs = new List<IUI>()
            {
                /*new Label(
                    rectangle: new Rectangle(260, 10, 230, 30),
                    "Camera",
                    textAlignment: Alignment.Midle_Center
                ),*/
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
                new Entity_Numbers(MyRectangle.GetRectangleBaseOnCanvasPosition(Alignment.Top_Left, ts, ts)),

                // TR
                new Entity_Numbers(MyRectangle.GetRectangleBaseOnCanvasPosition(Alignment.Top_Right, ts, ts)),

                // Center
                new Entity_WASD(
                    rectangle: MyRectangle.GetRectangleBaseOnCanvasPosition(Alignment.Midle_Center, ts, ts),
                    tag: "player"
                ),

                // DL
                new Entity_Numbers(MyRectangle.GetRectangleBaseOnCanvasPosition(Alignment.Down_Left, ts, ts)),

                // DR
                new Entity_Numbers(MyRectangle.GetRectangleBaseOnCanvasPosition(Alignment.Down_Right, ts, ts)),
            };

            this.camera = new Camera(entityToFollow: entities.Find(x => x.tag == "player"));
        }
    }
}
