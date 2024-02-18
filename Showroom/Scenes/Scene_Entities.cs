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
using Microsoft.Xna.Framework.Input;

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
                new ChristianTools.Entities.Line(new Point(100, 100), new Point(500, 500), Color.Red, tag:"RedLine"),
                new Entity_WASD(centerPosition: new Point(250, 250), rectangleStripeFromAtlas: _2B, tag: "player"),
                
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


            this.camera = new Camera();
            
            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateLine(lastInputState: lastInputState, inputState: inputState);
            this.dxDrawSystem = (SpriteBatch spriteBatch) => ChristianTools.Systems.Draw.Scene.DrawSystem(spriteBatch);
        }


        private void UpdateLine(InputState lastInputState, InputState inputState)
        {
            ChristianTools.Entities.Line line = entities.Where(x => x.tag == "RedLine").FirstOrDefault() as ChristianTools.Entities.Line;
            
            if (lastInputState.Mouse_LeftButton_Click)
            {
                Point? point = lastInputState.Mouse_OnWorldPosition();
                line.UpdatePoints(end: point); 
                Console.WriteLine(lastInputState.Mouse_OnWorldPosition());
            }
            
            if (lastInputState.Mouse_RightButton_Click)
            {
                Point? point = lastInputState.Mouse_OnWorldPosition();
                line.UpdatePoints(start: point);    
            }
            
            ChristianTools.Systems.Update.Scene.UpdateSystem(lastInputState: lastInputState, inputState: inputState);
        }

    }
}