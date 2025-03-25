namespace Showroom.Scenes
{
    public class House_1 : BaseScene
    {
        public override void Initialize()
        {
            int ts = ChristianGame.WK.TileSize;

            this.entities = new List<IEntity>()
            {
                //new ChristianTools.Entities.ZeroZeroPoint_Entity(),
                new Entity_WASD(rectangle: new Rectangle(1* ts, 1 * ts, ts, ts), tag: "player"),
            };

            this.triggers = new List<ITriggerPoint>()
            {
                new Trigger_Teleport("Scene_Zeldamon", new Rectangle(4 * ts, 4 * ts, ts, ts)),
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
            };

            TiledMap tiledMap = ChristianTools.Helpers.Tiled.Helpers.Read_Tiled_JsonSerialization<TiledMap>(ChristianGame.WK.Maps["House_1"]);
            this.map = new ChristianTools.Components.Map(tiledMap);

            this.camera = new Camera(entityToFollow: entities.Find(x => x.tag == "player"));
        }
    }
}