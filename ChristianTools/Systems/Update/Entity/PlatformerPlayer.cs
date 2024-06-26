namespace ChristianTools.Systems.Update
{
    public partial class Entity
    {
        private static int jumpCount = 0;
        private static bool isJumping = false;

        public static void PlatformerPlayer(InputState lastInputState, InputState inputState, IEntity entity)
        {
            if (entity.isActive != true)
                return;
            
            
            // Always a number factor by the tile width (16: 2,4,8)
            uint moveForce = 1;
            int jumpForce = 1;
            int gravity = 1;
            
            if (inputState.Right)
            {
                if (entity.rigidbody.CanMoveRight(moveForce))
                {
                    entity.animation.characterState = CharacterState.MoveRight;
                    entity.rigidbody?.Move_X((int)moveForce);
                }
                else
                {
                    entity.animation.characterState = CharacterState.IdleRight;
                }
            }
            else if (inputState.Left)
            {
                if (entity.rigidbody.CanMoveLeft(moveForce))
                {
                    entity.rigidbody?.Move_X(-(int)moveForce);
                    entity.animation.characterState = CharacterState.MoveLeft;
                }
                else
                {
                    entity.animation.characterState = CharacterState.IdleLeft;
                }
            }
            else
            {
                entity.animation.characterState = CharacterState.IdleDown;
            }


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
            else
            {
                /*if (inputState.Right)
                    entity.animation.characterState = CharacterState.IdleRight;
                else if (inputState.Left)
                    entity.animation.characterState = CharacterState.IdleLeft;
                else
                    entity.animation.characterState = CharacterState.IdleDown;*/
            }

            if (entity.rigidbody.CanMoveUp(moveForce) == false)
            {
                isJumping = false;
            }

            BaseUpdateSystem(lastInputState, inputState, entity);
        }
    }
}