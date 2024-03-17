using ChristianTools.Helpers;
using ChristianTools.Prefabs;
using Microsoft.Xna.Framework;
using Vector2 = System.Numerics.Vector2;

namespace Showroom
{
    public class Entity_WASD : BaseEntity
    {
        public Entity_WASD(Rectangle rectangle, Rectangle imageFromAtlas, string tag = "", Vector2 force = new Vector2(), bool isActive = true) : base(rectangle, imageFromAtlas, tag, force, isActive)
        {
            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Entity.Move_WASD(inputState: inputState, this, steps: 5);
        }
    }
}