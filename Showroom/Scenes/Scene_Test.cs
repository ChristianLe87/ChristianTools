
namespace Showroom.Scenes
{
    public class Scene_Test : BaseScene
    {
        public override void Initialize()
        {
            int ts = ChristianGame.WK.TileSize;

            this.UIs = new List<IUI>()
            {
                new Button(
                    UI_Position: Alignment.Down_Left,
                    width: 300,
                    height: 50,
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
                /*new Entity_WASD(
                    rectangle: new Rectangle(100,100, 16,16),
                    tag: "player"
                ),*/
                new Entity_WASD(rectangle: new Rectangle(7 * ts, 7 * ts, ts, ts), tag: "player"),
                new LabelEntity("Hello ", new Rectangle(11 * ts,11 * ts, 2 * ts, 1 * ts))

            };

            this.camera = new Camera(entityToFollow: entities.Find(x => x.tag == "player"));
        }
    }
}
