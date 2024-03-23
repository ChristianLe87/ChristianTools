using ChristianTools.Helpers;
using ChristianTools.Prefabs;
using Microsoft.Xna.Framework;

namespace Showroom
{
    public class Entity_WASD : BaseEntity
    {
        public Entity_WASD(Rectangle rectangle, Rectangle imageFromAtlas, string tag = "", Vector2 force = new Vector2(), bool isActive = true) : base(rectangle, imageFromAtlas, tag, force, isActive)
        {
            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Entity.Move_WASD(lastInputState, inputState, this, 10);
        }
    }
}