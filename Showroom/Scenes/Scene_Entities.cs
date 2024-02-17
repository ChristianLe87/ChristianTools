using System;
using System.Collections.Generic;
using System.Linq;
using ChristianTools;
using ChristianTools.Components;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Showroom.Scenes
{
    public class Scene_Entities : IScene
    {
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public Camera camera { get; set; }
        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }

        public void Initialize()
        {
            this.UIs = new List<IUI>()
            {
                // Back to menu
                new Button(rectangle: new Rectangle(10, 400, 100, 50), text: "<-- Back to menu", defaultTexture: null, mouseOverTexture: null, tag: "", OnClickAction: () => Game1.ChangeToScene("Scene_Menu")),
            };

 

            
            
            Rectangle _1R = new Rectangle(16, 16, 16, 16);
            Rectangle _2R = new Rectangle(32, 16, 16, 16);
            Rectangle _3R = new Rectangle(48, 16, 16, 16);

            Rectangle _1B = new Rectangle(16, 32, 16, 16);
            Rectangle _2B = new Rectangle(32, 32, 16, 16);
            Rectangle _3B = new Rectangle(48, 32, 16, 16);

            Rectangle _1G = new Rectangle(16, 48, 16, 16);
            Rectangle _2G = new Rectangle(32, 48, 16, 16);
            Rectangle _3G = new Rectangle(48, 48, 16, 16);

            this.entities = new List<IEntity>()
            {
                new Line(new Point(100, 100), new Point(500, 500), Color.Red, tag:"RedLine"),

                
                // TL
                new Entity_Numbers(centerPosition: new Point(8, 8), rectangleStripeFromAtlas: _1R, tag: "TL"),
                // TR
                new Entity_Numbers(centerPosition: new Point(ChristianGame.WK.canvasWidth - 8, 8), rectangleStripeFromAtlas: _3R),
                // DL
                new Entity_Numbers(centerPosition: new Point(8, ChristianGame.WK.canvasHeight - 8), rectangleStripeFromAtlas: _1G),
                // DR
                new Entity_Numbers(centerPosition: new Point(ChristianGame.WK.canvasWidth - 8, ChristianGame.WK.canvasHeight - 8), rectangleStripeFromAtlas: _3G),
                // center
                new Entity_Numbers(centerPosition: new Point(ChristianGame.WK.canvasWidth / 2, ChristianGame.WK.canvasHeight / 2), rectangleStripeFromAtlas: new Rectangle(32, 32, 16, 16))
            };


            // ToDo: Si hay camara, no hay update, si hay update no hay camara, (Averiguar por que no funciona con camara)
            //this.camera = new Camera();
            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateLine(lastInputState: lastInputState);
        }


        private void UpdateLine(InputState lastInputState)
        {
            if (lastInputState.Mouse_LeftButton_Click)
            {
                Line line = entities.Where(x => x.tag == "RedLine").FirstOrDefault() as Line;
            
                Point? point = lastInputState.Mouse_OnWindowPosition();
                line.UpdatePoints(end: point);    
            }
            
            if (lastInputState.Mouse_RightButton_Click)
            {
                Line line = entities.Where(x => x.tag == "RedLine").FirstOrDefault() as Line;
            
                Point? point = lastInputState.Mouse_OnWindowPosition();
                line.UpdatePoints(start: point);    
            }
            
            Console.WriteLine(lastInputState.Mouse_OnWorldPosition());
        }

    }
}