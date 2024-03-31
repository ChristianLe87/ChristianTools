using ChristianTools.Helpers;
using ChristianTools.Prefabs;
using Microsoft.Xna.Framework;

namespace Showroom
{
    public class Entity_WASD : BaseEntity
    {
        public Entity_WASD(Rectangle rectangle, Rectangle imageFromAtlas, int steps, string tag = "", bool isActive = true) : base(rectangle, imageFromAtlas, tag, isActive)
        {
            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Entity.Move_WASD(lastInputState, inputState, this, steps);
        }
    }
}