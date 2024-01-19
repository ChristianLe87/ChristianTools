using System.Collections.Generic;
using ChristianTools;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Entities
{
    public class Entity : IEntity
    {
        public Rigidbody rigidbody { get; }
        public Animation animation { get; }
        public bool isActive { get; set; } = true;
        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }
        public string tag { get; }

        public Entity(Point position, Rectangle rectangleStripeFromAtlas, string tag= "", bool isActive= true)
        {
            this.animation = new Animation(rectangleStripeFromAtlas);
            this.rigidbody = new Rigidbody(rectangle: new Rectangle(position.X, position.Y, rectangleStripeFromAtlas.Width, rectangleStripeFromAtlas.Height));
            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Entity.UpdateSystem(this);
            this.dxDrawSystem = (SpriteBatch spriteBatch) => ChristianTools.Systems.Draw.Entity.DrawSystem(spriteBatch, this);
            this.tag = tag;
            this.isActive = isActive;
        }
    }
}