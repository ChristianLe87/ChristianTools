using System.Collections.Generic;
using System.Linq;
using ChristianTools;
using ChristianTools.Components;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using ChristianTools.Prefabs;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Showroom.Scenes
{
    public class Scene_Camera : IScene
    {
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public Map map { get; set; }
        public Camera camera { get; set; }

        public void Initialize()
        {
            this.UIs = new List<IUI>()
            {
                new Label(
                    rectangle: new Rectangle(260, 10, 230, 30),
                    "Camera",
                    textAlignment: Label.TextAlignment.Midle_Center
                ),
                new Button(
                    rectangle: new Rectangle(10, 10, 230, 30),
                    text: "Go to menu",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Game1.ChangeToScene("Scene_Menu")
                ),

                new LineUI(start: new Point(0, 0), end: new Point(500, 500), color: Color.Red),
                
                //new ZeroZeroPoint_UI()
            };
            
            this.entities = new List<IEntity>()
            {
                new Entity_WASD(new Rectangle(0, 0, 16, 16), new Rectangle(32, 32, 16, 16)),

                // TL
                new Entity_Numbers(MyRectangle.CreateRectangle(centerPosition: new Point(8, 8), 16, 16), imageFromAtlas: WK.AtlasReferences._1, tag: "TL"),
                // TR
                new Entity_Numbers(MyRectangle.CreateRectangle(centerPosition: new Point(ChristianGame.WK.canvasWidth - 8, 8), 16, 16), imageFromAtlas: WK.AtlasReferences._3),
                // DL
                new Entity_Numbers(MyRectangle.CreateRectangle(centerPosition: new Point(8, ChristianGame.WK.canvasHeight - 8), 16, 16), imageFromAtlas: WK.AtlasReferences._7),
                // DR
                new Entity_Numbers(MyRectangle.CreateRectangle(centerPosition: new Point(ChristianGame.WK.canvasWidth - 8, ChristianGame.WK.canvasHeight - 8), 16, 16), imageFromAtlas: WK.AtlasReferences._9),
                // center
                new Entity_Numbers(MyRectangle.CreateRectangle(centerPosition: new Point(ChristianGame.WK.canvasWidth / 2, ChristianGame.WK.canvasHeight / 2), 16, 16), imageFromAtlas: WK.AtlasReferences._5),
                
                new ZeroZeroPoint_Entity(),
            };

            //this.camera = new Camera(entities.Find(x => x.tag == "player"));
        }
    }
}
