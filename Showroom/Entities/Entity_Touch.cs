using ChristianTools.Helpers;
using ChristianTools.Prefabs;
using Microsoft.Xna.Framework;

namespace Showroom
{
    public class Entity_Touch : BaseEntity
    {
        public Entity_Touch(Rectangle rectangle, Rectangle imageFromAtlas, string tag = "", Vector2 force = new Vector2(), bool isActive = true) : base(rectangle, imageFromAtlas, tag, force, isActive)
        {
            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => Update(lastInputState, inputState);
        }

        private void Update(InputState lastInputState, InputState inputState)
        {
            if (inputState.IsTouchDown())
            {
                rigidbody.rectangle = ChristianTools.Helpers.MyRectangle.CreateRectangle(inputState.GetTouch(), 16, 16);
            }
        }
    }
}
