namespace ChristianTools.Systems.Update
{
    public class Entity
    {
        public static void UpdateSystem(InputState lastInputState, InputState inputState, IEntity entity)
        {
            if (entity.isActive != true)
                return;

            entity.animation?.Update();
            entity.rigidbody?.Update();
        }


        private static int jumpCount = 0;
        private static bool isJumping = false;
        public static void PlatformerPlayer(InputState lastInputState, InputState inputState, IEntity entity)
        {
            // Always a number factor by the tile width (16: 2,4,8)
            int moveForce = 2;
            int jumpForce = 2;
            int gravity = 2;
            
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
            entity.animation?.Update();
        }


        public static void Move_WASD(InputState lastInputState, InputState inputState, IEntity entity, int steps = 1)
        {
            if (entity.isActive != true)
                return;


            CharacterState lastCharacterState = entity.animation.characterState;



            if (inputState.Up)
            {
                entity.rigidbody?.Move_Y(-steps);
                entity.animation.characterState = CharacterState.MoveUp;
            }
            else if (inputState.Down)
            {
                entity.rigidbody?.Move_Y(steps);
                entity.animation.characterState = CharacterState.MoveDown;

            }
            else if (inputState.Right)
            {
                entity.rigidbody?.Move_X(steps);
                entity.animation.characterState = CharacterState.MoveRight;
            }
            else if (inputState.Left)
            {
                entity.rigidbody?.Move_X(-steps);
                entity.animation.characterState = CharacterState.MoveLeft;
            }
            else
            {
                if (lastCharacterState == CharacterState.MoveUp)
                    entity.animation.characterState = CharacterState.IdleUp;
                else if (lastCharacterState == CharacterState.MoveDown)
                    entity.animation.characterState = CharacterState.IdleDown;
                else if (lastCharacterState == CharacterState.MoveRight)
                    entity.animation.characterState = CharacterState.IdleRight;
                else if (lastCharacterState == CharacterState.MoveLeft)
                    entity.animation.characterState = CharacterState.IdleLeft;
            }

            entity.rigidbody?.Update();
            entity.animation?.Update();
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
            
            
            entity.rigidbody?.Update();
            entity.animation?.Update();
        }
    }
}