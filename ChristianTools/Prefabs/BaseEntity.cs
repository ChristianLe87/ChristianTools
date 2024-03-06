using System;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;

namespace ChristianTools.Prefabs
{
    public abstract class BaseEntity : IEntity
    {
        public IRigidbody rigidbody { get; set; }
        public Animation animation { get; }
        public bool isActive { get; set; }
        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }
        public string tag { get; }
        public Guid guid { get; }

        public BaseEntity(Rectangle rectangle, Rectangle imageFromAtlas, string tag = "", Vector2 force = new Vector2(), bool isActive = true)
        {
            this.rigidbody = new Rigidbody(rectangle, force);
            this.animation = new Animation(imageFromAtlas);
            this.isActive = isActive;
            this.tag = tag;
            this.guid = Guid.NewGuid();
        }
    }
}