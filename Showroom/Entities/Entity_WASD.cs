using System;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Prefabs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Showroom
{
    public class Entity_WASD : BaseEntity
    {
        public Entity_WASD(Rectangle rectangle, Rectangle imageFromAtlas, string tag = "", bool isActive = true) : base(rectangle, imageFromAtlas, tag, isActive)
        {
            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Entity.UpdateSystem_WASD(inputState: inputState, this);
        }
    }
}