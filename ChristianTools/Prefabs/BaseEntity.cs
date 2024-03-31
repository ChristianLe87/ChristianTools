using System;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Prefabs
{
    public abstract class BaseEntity : IEntity
    {
        public Rigidbody rigidbody { get; set; }
        public Animation animation { get; }
        public bool isActive { get; set; }
        public string tag { get; }
        public Guid guid { get; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }

        public BaseEntity(Rectangle rectangle, Rectangle imageFromAtlas, string tag = "", bool isActive = true)
        {
            this.rigidbody = new Rigidbody(rectangle);
            this.animation = new Animation(imageFromAtlas);
            this.isActive = isActive;
            this.tag = tag;
            this.guid = Guid.NewGuid();
            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => Systems.Update.Entity.UpdateSystem(lastInputState, inputState, this);
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => Systems.Draw.Entity.Draw(spriteBatch, this);
        }
    }
}
