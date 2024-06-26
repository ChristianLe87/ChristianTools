
namespace ChristianTools.Systems.Update
{ 
    public partial class Entity
    {
        public static void BaseUpdateSystem(InputState lastInputState, InputState inputState, IEntity entity)
        {
            if (entity.isActive != true)
                return;

            entity.animation?.Update();
            entity.rigidbody?.Update();
        }
    }
}