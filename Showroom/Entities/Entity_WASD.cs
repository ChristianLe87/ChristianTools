using System;
using ChristianTools;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Prefabs;
using Microsoft.Xna.Framework;


namespace Showroom
{
    public class Entity_WASD : IEntity
    {
        public IRigidbody rigidbody { get; set; }
        public Animation animation { get; }
        public bool isActive { get; set; }
        public string tag { get; }
        public Guid guid { get; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }

        public Entity_WASD()
        {
            rigidbody = new Rigidbody(new Rectangle(0,0,16,16));
            animation = new Animation(WK.AtlasReferences._4);
            isActive = true;
            tag = "";
            guid = Guid.NewGuid();
            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Entity.Move_WASD(lastInputState, inputState, this, 3);
            //dxCustomDrawSystem = null;
        }
    }
}
