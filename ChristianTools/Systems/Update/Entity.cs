using ChristianTools.Helpers;

namespace ChristianTools.Systems.Update
{
    public class Entity
    {
        public static void UpdateSystem(IEntity entity)
        {
            if (entity.isActive != true)
                return;
            
            entity.animation?.Update();
            entity.rigidbody?.Update();
        }
        
        public static void UpdateSystem_WASD(InputState inputState, IEntity entity)
        {
            if (entity.isActive != true)
                return;
            
            if (inputState.Up)
                entity.rigidbody.Move_Y(-5);
			
            if (inputState.Down)
                entity.rigidbody.Move_Y(5);
			
			
            if (inputState.Right)
                entity.rigidbody.Move_X(5);
			
            if (inputState.Left)
                entity.rigidbody.Move_X(-5);
            
            entity.animation?.Update();
            entity.rigidbody?.Update();
        }
    }
}