using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Helpers.Tiled;
using ChristianTools.Prefabs;
using ChristianTools.UI;
using Microsoft.Xna.Framework;

namespace Showroom.Scenes
{
    public class Scene_Tiles : BaseScene
    {
        public override void Initialize()
        {
            this.entities = new List<IEntity>()
            {
                //new Entity_Platformer_Player(rectangle: new Rectangle(4 * 16, 2 * 16 + 1, 16, 16), imageFromAtlas: WK.AtlasReferences._2, steps: 1, tag: "player"),
                new Entity_WASD(rectangle: new Rectangle(4 * 16, 2 * 16 + 1, 16, 16), imageFromAtlas: WK.AtlasEntitiesReferences._2, steps: 4, tag: "player"),
                new ChristianTools.Entities.ZeroZeroPoint_Entity()
            };

            this.UIs = new List<IUI>()
            {
                // Back to menu
                new Button(rectangle: new Rectangle(10, 460, 230, 30), text: "<-- Back to menu", defaultTexture: null, mouseOverTexture: null, tag: "", OnClickAction: () => Game1.ChangeToScene("Scene_Menu")),
            };
            

            TiledMap tiledMap = ChristianTools.Helpers.Tiled.Helpers.Read_Tiled_JsonSerialization<TiledMap>("MyMap/MyMap_1");
            this.map = new ChristianTools.Components.Map(tiledMap);

            
            this.camera = new Camera(zoom: 1, entityToFollow: entities.Find(x => x.tag == "player"));
        }
    }
}