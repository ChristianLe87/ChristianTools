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
        public Camera camera { get; set; }
        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }
        
        
        public void Initialize()
        {
            //this.camera = new Camera(new Point(0,0));
            Rectangle _2B = new Rectangle(32, 32, 16, 16);
            this.entities = new List<IEntity>()
            {
                new MyBlaEntity(new Point(100, 100), _2B)
            };

            this.UIs = new List<IUI>()
            {
                new Label(new Rectangle(0, 0, 100, 50), "Hello")
            };
            
            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Scene.UpdateSystem(lastInputState: lastInputState, inputState: inputState);
            this.dxDrawSystem = (SpriteBatch spriteBatch) => ChristianTools.Systems.Draw.Scene.DrawSystem(spriteBatch);
        }
    }

    public class MyBlaEntity : IEntity
    {
        public Rigidbody rigidbody { get; }
        public Animation animation { get; }
        public bool isActive { get; set; }
        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }
        public string tag { get; }
     

        public MyBlaEntity(Point centerPosition, Rectangle rectangleStripeFromAtlas, string tag = "")
        {
            this.rigidbody = new Rigidbody(new Rectangle(centerPosition.X, centerPosition.Y, rectangleStripeFromAtlas.Width, rectangleStripeFromAtlas.Height));
            this.animation = new Animation(rectangleStripeFromAtlas);
            this.isActive = true;
            //this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Entity.UpdateSystem(this);
            //this.dxDrawSystem = (SpriteBatch spriteBatch) => ChristianTools.Systems.Draw.Entity.DrawSystem(spriteBatch, this);
            this.tag = tag;
        }
    }
}