

namespace Showroom.Scenes
{
     public class Scene_Zeldamon : BaseScene
    {
        public override void Initialize()
        {
            this.entities = new List<IEntity>()
            {
                new Entity_WASD(rectangle: new Rectangle(10 * 16, 16 * 16, 16, 16), imageFromAtlas: WK.AtlasEntitiesReferences.Idel_Down, tag: "player"),
                new ChristianTools.Entities.ZeroZeroPoint_Entity()
            };

            this.UIs = new List<IUI>()
            {
                // Back to menu
                new Button(rectangle: new Rectangle(10, 460, 230, 30), text: "<-- Back to menu", defaultTexture: null, mouseOverTexture: null, tag: "", OnClickAction: () => Game1.ChangeToScene("Scene_Menu")),
            };

            TiledMap tiledMap = ChristianTools.Helpers.Tiled.Helpers.Read_Tiled_JsonSerialization<TiledMap>(ChristianGame.WK.Maps["Zeldamon_1"]);
            this.map = new ChristianTools.Components.Map(tiledMap);
            
            this.camera = new Camera(zoom: 1, entityToFollow: entities.Find(x => x.tag == "player"));
        }
    }
}