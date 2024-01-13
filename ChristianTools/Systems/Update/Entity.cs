using ChristianTools.Helpers;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Systems
{
    public partial class Update
    {
        public static void Entity(InputState lastInputState, InputState inputState, IScene scene, IEntity entity)
        {
            if (entity.isActive != true)
                return;
			
            if (entity.dxUpdateSystem != null)
                entity.dxUpdateSystem(lastInputState, inputState, scene);

            entity.animation?.Update();
            entity.rigidbody?.Update();
        }
    }
}