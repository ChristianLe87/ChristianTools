using System;
using System.Collections.Generic;
using System.Linq;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


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

        public BaseEntity(Rectangle rectangle, Rectangle imageFromAtlas, string tag = "", bool isActive = true)
        {
            this.rigidbody = new Rigidbody(rectangle);
            this.animation = new Animation(imageFromAtlas);
            this.isActive = isActive;
            this.tag = tag;
            this.guid = Guid.NewGuid();
        }
    }
}