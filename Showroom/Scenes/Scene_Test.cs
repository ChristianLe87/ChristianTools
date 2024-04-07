using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using ChristianTools.Prefabs;
using ChristianTools.UI;
using Microsoft.Xna.Framework;

namespace Showroom.Scenes
{
    public class Scene_Test : BaseScene
    {
        public override void Initialize()
        {
            // entities
            {
                this.entities = new List<IEntity>()
                {
                    new Entity_Touch(MyRectangle.CreateRectangle(new Point(250, 250), 16, 16), WK.AtlasEntitiesReferences.Idel_Down, "player"),
                    new ZeroZeroPoint_Entity(),
                };
            }

            // UI
            {
                this.UIs = new List<IUI>()
                {
                    new Button(
                        rectangle: new Rectangle(10, 460, 230, 30),
                        text: "<-- Back to menu",
                        defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                        mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                        OnClickAction: () => Game1.ChangeToScene("Scene_Menu")
                    ),
                    new ZeroZeroPoint_UI(),
                    new Button(rectangle: new Rectangle(10, 460, 230, 30), text: "<-- Back to menu", defaultTexture: null, mouseOverTexture: null, tag: "", OnClickAction: () => Game1.ChangeToScene("Scene_Menu")),
                };
            }
            
            this.camera = new Camera(zoom: 1, entityToFollow: entities.Find(x => x.tag == "player"));
        }
    }
}
