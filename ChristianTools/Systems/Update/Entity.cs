using ChristianTools.Helpers;

namespace ChristianTools.Systems
{
    public partial class Systems
    {
        public partial class Update
        {
            public static void Entity(InputState lastInputState, InputState inputState, IEntity entity)
            {
                if (entity.dxEntityUpdateSystem != null)
                {
                    entity.dxEntityUpdateSystem(lastInputState, inputState);
                }

                entity.animation.Update();
                entity.rigidbody.Update();
            }
        }
    }
}