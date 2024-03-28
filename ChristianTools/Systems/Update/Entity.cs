using ChristianTools.Helpers;
using Microsoft.Xna.Framework;

namespace ChristianTools.Systems.Update
{
    public class Entity
    {
        public static void UpdateSystem(InputState lastInputState, InputState inputState, IEntity entity)
        {
            if (entity.isActive != true)
                return;

            //entity.animation?.Update();
            entity.rigidbody?.Update();
        }


        public static void PlatformerPlayer(InputState lastInputState, InputState inputState, IEntity entity, int steps)
        {
            if (entity.isActive != true)
                return;

            if (inputState.Right)
                entity.rigidbody?.Move_X(steps);
            else if (inputState.Left)
                entity.rigidbody?.Move_X(-steps);


            if (inputState.Jump == true && lastInputState.Jump == false && entity.rigidbody.isGrounded)
            {
                entity.rigidbody.force = new Vector2(0, -7);
            }

            if (-entity.rigidbody.force.Y > entity.rigidbody.gravity)
            {
                entity.rigidbody.force -= new Vector2(0, -0.1f);
            }
            else
            {
                entity.rigidbody.force = new Vector2(0, 0);
            }

            if (!entity.rigidbody.CanMoveUp(steps))
            {
                entity.rigidbody.force = new Vector2(0, 0);
            }


            entity.rigidbody?.Update();
        }


        public static void Move_WASD(InputState lastInputState, InputState inputState, IEntity entity, int steps)
        {
            if (entity.isActive != true)
                return;

            if (inputState.Up)
                entity.rigidbody?.Move_Y(-steps);
            else if (inputState.Down)
                entity.rigidbody?.Move_Y(steps);

            if (inputState.Right)
                entity.rigidbody?.Move_X(steps);
            else if (inputState.Left)
                entity.rigidbody?.Move_X(-steps);
            
            //entity.animation?.Update();
            entity.rigidbody?.Update();
        }

        public static void SetForce(InputState lastInputState, InputState inputState, IEntity entity, int steps = 1)
        {
            if (entity.isActive != true)
                return;

            if (inputState.Up)
                entity.rigidbody.force = new Vector2(entity.rigidbody.force.X, -steps);
            else if (inputState.Down)
                entity.rigidbody.force = new Vector2(entity.rigidbody.force.X, steps);

            if (inputState.Right)
                entity.rigidbody.force = new Vector2(steps, entity.rigidbody.force.Y);
            else if (inputState.Left)
                entity.rigidbody.force = new Vector2(-steps, entity.rigidbody.force.Y);

            //entity.animation?.Update();
            entity.rigidbody?.Update();
        }
    }
}