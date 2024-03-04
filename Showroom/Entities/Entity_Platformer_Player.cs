using System;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Prefabs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Showroom
{
    public class Entity_Platformer_Player : BaseEntity
    {
        public Entity_Platformer_Player(Rectangle rigidbodyRectangle, Rectangle imageFromAtlas, string tag = "", bool isActive = true) : base(rigidbodyRectangle, imageFromAtlas, tag, isActive)
        {
            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => Update(lastInputState, inputState);
        }

        private void Update(InputState lastInputState, InputState inputState)
        {
            // Code
        }
    }
}
