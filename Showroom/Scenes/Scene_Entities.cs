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
        public Map map { get; set; }
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

            this.entities = new List<IEntity>()
            {
                new ChristianTools.Entities.Line(new Point(100, 100), new Point(500, 500), Color.Red, tag: "RedLine"),
                new Entity_WASD(rectangle: new Rectangle(250, 250, 16, 16), imageFromAtlas: WK.AtlasReferences._2, tag: "player"),

                // TL
                new Entity_Numbers(MyRectangle.CreateRectangle(centerPosition: new Point(8, 8), 16, 16), animationRectangle: WK.AtlasReferences._1, tag: "TL"),
                // TR
                new Entity_Numbers(MyRectangle.CreateRectangle(centerPosition: new Point(ChristianGame.WK.canvasWidth - 8, 8), 16, 16), animationRectangle: WK.AtlasReferences._3),
                // DL
                new Entity_Numbers(MyRectangle.CreateRectangle(centerPosition: new Point(8, ChristianGame.WK.canvasHeight - 8), 16, 16), animationRectangle: WK.AtlasReferences._7),
                // DR
                new Entity_Numbers(MyRectangle.CreateRectangle(centerPosition: new Point(ChristianGame.WK.canvasWidth - 8, ChristianGame.WK.canvasHeight - 8), 16, 16), animationRectangle: WK.AtlasReferences._9),
                // center
                new Entity_Numbers(MyRectangle.CreateRectangle(centerPosition: new Point(ChristianGame.WK.canvasWidth / 2, ChristianGame.WK.canvasHeight / 2), 16, 16), animationRectangle: WK.AtlasReferences._5)
            };
            
            this.camera = new Camera();
            
            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateLine(lastInputState: lastInputState, inputState: inputState);
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
            
            //ChristianTools.Systems.Update.Scene.UpdateSystem(lastInputState: lastInputState, inputState: inputState);
            
            IScene scene = ChristianGame.GetScene;
            if (scene.entities != null)
            {
                if (scene.entities.Where(x => x.tag == "player").Count() > 0)
                {
                    IEntity player = scene.entities.Where(x => x.tag == "player").FirstOrDefault();
                    scene.camera.UpdateCamera(player.rigidbody?.rectangle.Center ?? new Point(0, 0));
                }
            }
            
        }

    }
}