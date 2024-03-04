using ChristianTools.Helpers;

namespace ChristianTools.Systems.Update
{
    public class Entity
    {
        public static void UpdateSystem(IEntity entity)
        {
            if (entity.isActive != true)
                return;

            //entity.animation?.Update();
            entity.rigidbody?.Update();
        }

        public static void UpdateSystem_WASD(InputState inputState, IEntity entity, int steps = 1)
        {
            if (entity.isActive != true)
                return;

            if (inputState.Up)
                entity.rigidbody?.Move_Y(-steps);

            if (inputState.Down)
                entity.rigidbody?.Move_Y(steps);

            if (inputState.Right)
                entity.rigidbody?.Move_X(steps);

            if (inputState.Left)
                entity.rigidbody?.Move_X(-steps);

            //entity.animation?.Update();
            entity.rigidbody?.Update();
        }
    }
}