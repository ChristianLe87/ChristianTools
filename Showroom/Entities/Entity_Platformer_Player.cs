using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Showroom
{
    public class Entity_Platformer_Player : IEntity
    {
        public IRigidbody rigidbody { get; }
        public Animation animation { get; }
        public bool isActive { get; set; }
        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }
        public string tag { get; }

        public Entity_Platformer_Player(Point centerPosition, Rectangle rectangleStripeFromAtlas, string tag = "")
        {
            this.rigidbody = new Rigidbody(new Rectangle(centerPosition.X, centerPosition.Y, rectangleStripeFromAtlas.Width, rectangleStripeFromAtlas.Height), new Vector2(0, 1));
            this.animation = new Animation(rectangleStripeFromAtlas);
            this.isActive = true;
            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Entity.UpdateSystem(this);
            this.dxDrawSystem = (SpriteBatch spriteBatch) => ChristianTools.Systems.Draw.Entity.DrawSystem(spriteBatch, this);
            this.tag = tag;
        }
    }
}
