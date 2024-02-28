using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Showroom
{
    public class Entity_WASD : IEntity
    {
        public IRigidbody rigidbody { get; }
        public Animation animation { get; }
        public bool isActive { get; set; }
        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }
        public string tag { get; }

        public Entity_WASD(Point centerPosition, Rectangle rectangleStripeFromAtlas, string tag = "")
        {
            this.rigidbody = new Rigidbody_Test(new Rectangle(centerPosition.X, centerPosition.Y, rectangleStripeFromAtlas.Width, rectangleStripeFromAtlas.Height));
            this.animation = new Animation(rectangleStripeFromAtlas);
            this.isActive = true;
            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Entity.UpdateSystem_WASD(inputState: inputState, this);
            this.dxDrawSystem = (SpriteBatch spriteBatch) => ChristianTools.Systems.Draw.Entity.DrawSystem(spriteBatch, this);
            this.tag = tag;
        }
    }
}