using System.Collections.Generic;
using ChristianTools;
using ChristianTools.Components;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Showroom
{
    public class MyEntity : Entity
    {

        public MyEntity(Point position, Rectangle rectangleStripeFromAtlas, string tag= "", bool isActive= true) : base(position, rectangleStripeFromAtlas, tag, isActive)
        {
            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Entity.UpdateSystem_WASD(inputState: inputState, this);
            this.dxDrawSystem = (SpriteBatch spriteBatch) => ChristianTools.Systems.Draw.Entity.DrawSystem(spriteBatch, this);
        }
    }
}