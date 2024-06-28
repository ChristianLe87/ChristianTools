namespace ChristianTools.Systems.Update
{
    public partial class Entity
    {
        // Always a number factor by the tile width (16: 2,4,8)
        //private static uint gravity = entity.rigidbody.gravity; // 4
        private static uint steps = 1;
        private static uint jumpForce = 12;// gravity * 3;

        public static void PlatformerPlayer(InputState lastInputState, InputState inputState, IEntity entity)
        {
            if (entity.isActive != true)
                return;

            MyDebugThing(inputState, lastInputState);

            MoveRL(entity, inputState, steps);
            JumpSystem(entity, inputState, lastInputState, steps, jumpForce);
            
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


        private static void JumpSystem(IEntity entity, InputState inputState, InputState lastInputState, uint steps, uint jumpForce)
        {
            if (inputState.Jump && !lastInputState.Jump && entity.rigidbody.CanMoveDown(steps) == false)
            {
                entity.rigidbody.force = new Vector2(0, -jumpForce);
            }

            if (entity.rigidbody.force.Y <= 0)
            {
                entity.rigidbody.force += new Vector2(0, 0.65f);
            }
        }

        private static void MyDebugThing(InputState inputState, InputState lastInputState)
        {
            if (inputState.keyboard.IsKeyboardKeyDown(Keys.O)&& !lastInputState.keyboard.IsKeyboardKeyDown(Keys.O))
            {
                jumpForce = Math.Clamp(++jumpForce, 0, 30);
                Console.WriteLine($"=== {jumpForce} ===");
            }
            
            if (inputState.keyboard.IsKeyboardKeyDown(Keys.P)&& !lastInputState.keyboard.IsKeyboardKeyDown(Keys.P))
            {
                jumpForce = Math.Clamp(--jumpForce, 0, 30);
                Console.WriteLine($"=== {jumpForce} ===");
            }
            
            if (inputState.keyboard.IsKeyboardKeyDown(Keys.L)&& !lastInputState.keyboard.IsKeyboardKeyDown(Keys.L))
            {
                Console.WriteLine($"=== {jumpForce} ===");
            }
        }
    }
}