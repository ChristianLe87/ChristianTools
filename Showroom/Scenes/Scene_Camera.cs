using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using ChristianTools.Prefabs;
using ChristianTools.UI;
using Microsoft.Xna.Framework;

namespace Showroom.Scenes
{
    public class Scene_Camera : BaseScene
    {
        public override void Initialize()
        {
            this.UIs = new List<IUI>()
            {
                new Label(
                    rectangle: new Rectangle(260, 10, 230, 30),
                    "Camera",
                    textAlignment: Label.TextAlignment.Midle_Center
                ),
                new Button(
                    rectangle: new Rectangle(10, 460, 230, 30),
                    text: "<-- Back to menu",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Game1.ChangeToScene("Scene_Menu")
                ),

                new ZeroZeroPoint_UI()
            };

            this.entities = new List<IEntity>()
            {
                new ZeroZeroPoint_Entity(),

                // TL
                new Entity_Numbers(new Rectangle(0, 0, 16, 16), WK.AtlasEntitiesReferences.Idle_Left),

                // TR
                new Entity_Numbers(new Rectangle(484, 0, 16, 16), WK.AtlasEntitiesReferences.Idl_Right),

                // Center
                new Entity_WASD(
                    rectangle:MyRectangle.CreateRectangle(new Point(250, 250), 16, 16),
                    imageFromAtlas: WK.AtlasEntitiesReferences.Idel_Down,
                    steps: 10,
                    tag: "player"
                ),

                // DL
                new Entity_Numbers(new Rectangle(0, 484, 16, 16), WK.AtlasEntitiesReferences.Idle_Left),

                // DR
                new Entity_Numbers(new Rectangle(484, 484, 16, 16), WK.AtlasEntitiesReferences.Idl_Right),
            };

            this.camera = new Camera(zoom: 1, entityToFollow: entities.Find(x => x.tag == "player"));
        }
    }
}
