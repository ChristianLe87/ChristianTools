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


        private static int jumpCount = 0;
        private static bool isJumping = false;
        public static void PlatformerPlayer(InputState lastInputState, InputState inputState, IEntity entity)
        {
            // Always a number factor by the tile width (16: 2,4,8)
            int moveForce = 4;
            int jumpForce = 4;
            int gravity = 4;
            
            if (inputState.Right)
                entity.rigidbody?.Move_X(moveForce);
            else if (inputState.Left)
                entity.rigidbody?.Move_X(-moveForce);
            

            // Jump
            if (inputState.Jump && !lastInputState.Jump && entity.rigidbody.CanMoveDown(moveForce) == false)
            {
                isJumping = true;
            }


            // Move jump
            if (isJumping == true && jumpCount < (ChristianGame.WK.FPS / 4))
            {
                entity.rigidbody.force = new Vector2(0, -jumpForce);
                jumpCount++;
            }
            else
            {
                jumpCount = 0;
                isJumping = false;
            }


            if (isJumping == false)
            {
                entity.rigidbody.force = new Vector2(entity.rigidbody.force.X, gravity);
            }

            if (entity.rigidbody.CanMoveUp(moveForce) == false)
            {
                isJumping = false;
            }

            
            entity.rigidbody.Update();
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