

namespace Showroom.Scenes
{
     public class Scene_Zeldamon : BaseScene
    {
        public override void Initialize()
        {
            int ts = ChristianGame.WK.TileSize;

            this.entities = new List<IEntity>()
            {
                new ChristianTools.Entities.ZeroZeroPoint_Entity(),
                new Entity_WASD(rectangle: new Rectangle(10 * ts, 16 * ts, ts, ts), tag: "player"),
                new NPC_1(rectangle: new Rectangle(10 * ts, 20 * ts, ts, ts), tag: "npc1"),
            };

            this.triggers = new List<ITrigger>()
            {
                new Trigger_Teleport(new Rectangle(10 * ts, 14 * ts, ts, ts)),
            };

            this.UIs = new List<IUI>()
            {
                // Back to menu
                new Button(
                    UI_Position: Alignment.Down_Left,
                    width: 230,
                    height: 30,
                    margin: 10,
                    text: "<-- Back to menu",
                    //defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    //mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    tag: "",
                    OnClickAction: () => Game1.ChangeToScene("Scene_Menu")
                ),

                //new Label("askfjlskfjsdjalafs\njasfkldjsakfjsdl", Alignment.Midle_Center, Alignment.Down_Center, 100, 100, 0, tag: "npc1"),
                //new Label(text: "Down_Center", textAlignment: Alignment.Down_Center, UI_Position: Alignment.Down_Center, Width: 100, Height: 20, margin: 0, texture: lightSlateGray),

                new Dialogue(
                    title: "Dialogue1:",
                    text: "askfjlskfjsdjalafs\njasfkldjsakfjsdl\njasfkldjsakfjsdl\nfskfjlsajfjsdl\njasfkldjsakfjsdl",
                    Width: 200,
                    Height: 100,
                    //textAlignment: Alignment.Midle_Left,
                    UI_Position: Alignment.Down_Center,
                    margin: 10,
                    tag: "npc2"
                ),

            };

            TiledMap tiledMap = ChristianTools.Helpers.Tiled.Helpers.Read_Tiled_JsonSerialization<TiledMap>(ChristianGame.WK.Maps["Zeldamon_1"]);
            this.map = new ChristianTools.Components.Map(tiledMap);
            
            this.camera = new Camera(entityToFollow: entities.Find(x => x.tag == "player"));
        }
    }
}