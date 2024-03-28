using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Prefabs;
using Microsoft.Xna.Framework;

namespace Showroom
{
    public class Entity_Platformer_Player : BaseEntity
    {
        public Entity_Platformer_Player(Rectangle rectangle, Rectangle imageFromAtlas, int steps, string tag = "", Vector2 force = new Vector2(), bool isActive = true) : base(rectangle, imageFromAtlas, tag, force, isActive)
        {
            this.rigidbody = new Rigidbody(rectangle, force, gravity: 3);
            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => Update(lastInputState, inputState, steps);
        }

        private void Update(InputState lastInputState, InputState inputState, int steps)
        {
            ChristianTools.Systems.Update.Entity.PlatformerPlayer(lastInputState, inputState, this, 2);
            //ChristianTools.Systems.Update.Entity.Move_WASD(lastInputState, inputState, this, 2);
            //ChristianTools.Systems.Update.Entity.SetForce(lastInputState, inputState, this, 1);
        }
    }
}
