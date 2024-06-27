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
            int gravity = (int)entity.rigidbody.gravity;
            int jumpForce = gravity*3;
            
            uint steps = 1;


            MoveRL(entity, inputState, steps);
            
            
            
            // Jump
            if (inputState.Jump && !lastInputState.Jump && entity.rigidbody.CanMoveDown(steps) == false)
            { 
                isJumping = true;
                entity.rigidbody.force = new Vector2(0, -jumpForce);
            }


            if (entity.rigidbody.force.Y != 0)
            {
                entity.rigidbody.force += new Vector2(0, 1);
            }
            
            
            
            // Move jump
            if (isJumping == true)
            {
                entity.rigidbody.force += new Vector2(0, -1);
            }
            else
            {
                //isJumping = false;
            }
            
            

            // If touch up or right, stop jumping
            if (entity.rigidbody.CanMoveUp(steps) == false || entity.rigidbody.CanMoveDown(steps))
            {
                isJumping = false;
            }

            BaseUpdateSystem(lastInputState, inputState, entity);
        }

        private static void MoveRL(IEntity entity, InputState inputState, uint steps)
        {
             
            if (inputState.Right)
            {
                if (entity.rigidbody.CanMoveRight(steps))
                {
                    entity.rigidbody?.MoveRight(steps);

                    entity.animation.characterState = CharacterState.MoveRight;
                    entity.rigidbody.MoveRight(steps);
                }
                else
                {
                    entity.animation.characterState = CharacterState.IdleRight;
                }
            }
            else if (inputState.Left)
            {
                if (entity.rigidbody.CanMoveLeft(steps))
                {
                    entity.rigidbody?.MoveLeft(steps);
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
        }
    }
}