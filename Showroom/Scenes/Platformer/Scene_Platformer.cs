namespace Showroom.Scenes
{
    public class Scene_Platformer : BaseScene
    {
        public override void Initialize()
        {
            this.entities = new List<IEntity>()
            {
                new Entity_Platformer_Player( new Vector2(4 * 16, 11 * 16)),
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

            this.camera = new Camera();// new Camera(entityToFollow: entities.Find(x => x.tag == "player"));
        }
    }
}