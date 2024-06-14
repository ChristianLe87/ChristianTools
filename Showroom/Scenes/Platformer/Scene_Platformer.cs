namespace Showroom.Scenes
{
    public class Scene_Platformer : BaseScene
    {
        public override void Initialize()
        {
            this.entities = new List<IEntity>()
            {
                new Entity_Platformer_Player(rectangle: new Rectangle(4 * 16, 12 * 16, 16, 16), imageFromAtlas: WK.AtlasEntitiesReferences.Idel_Down, 1, tag: "player"),
                new ChristianTools.Entities.ZeroZeroPoint_Entity()
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
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    tag: "",
                    OnClickAction: () => Game1.ChangeToScene("Scene_Menu")
                ),
            };

            TiledMap tiledMap = ChristianTools.Helpers.Tiled.Helpers.Read_Tiled_JsonSerialization<TiledMap>(ChristianGame.WK.Maps["Platformer_1"]);
            this.map = new ChristianTools.Components.Map(tiledMap);

            this.camera = new Camera(zoom: 1, entityToFollow: entities.Find(x => x.tag == "player"));
        }
    }
}