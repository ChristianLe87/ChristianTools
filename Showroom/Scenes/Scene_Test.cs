using System;
using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Showroom;

namespace Showroom.Scenes
{
    public class Scene_Test : IScene
    {
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public Map map { get; set; }
        public Camera camera { get; set; }
        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }
        
        
        public void Initialize()
        {
            //this.camera = new Camera(new Point(0,0));
            Rectangle _2B = new Rectangle(32, 32, 16, 16);
            this.entities = new List<IEntity>()
            {
                new Entity_WASD(new Point(100, 100), _2B, tag: "player"),
                new Entity_Numbers(new Point(100, 300), new Rectangle(0,0,16,16), tag:"Entity_Numbers")
            };
            this.map = new Map(mainTiles: new List<Tile>(){new Tile(new Rectangle(), new Rectangle(),1)} );


            this.camera = new Camera();
            
            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Scene.UpdateSystem(lastInputState: lastInputState, inputState: inputState);
            this.dxDrawSystem = (SpriteBatch spriteBatch) => ChristianTools.Systems.Draw.Scene.DrawSystem(spriteBatch);
        }
    }
}