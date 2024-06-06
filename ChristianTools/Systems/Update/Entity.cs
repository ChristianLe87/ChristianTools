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
            uint moveForce = 2;
            int jumpForce = 2;
            int gravity = 2;
            
            if (inputState.Right)
                entity.rigidbody?.Move_X((int)moveForce);
            else if (inputState.Left)
                entity.rigidbody?.Move_X(-(int)moveForce);


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


        public static void Move_WASD(InputState lastInputState, InputState inputState, IEntity entity)
        {
            if (entity.isActive != true)
                return;



            // --- Up ---
            if (inputState.Up || entity.animation.characterState == CharacterState.MoveUp)
            {
                entity.rigidbody.MoveUp(1);

                // move until player until alligne with tile
                if (entity.rigidbody.rectangle.Y % ChristianGame.WK.TileSize != 0)
                {
                    entity.animation.characterState = CharacterState.MoveUp;
                }
                else
                {
                    if (inputState.Up == false || entity.rigidbody.CanMoveUp(1) == false)
                    {
                        entity.animation.characterState = CharacterState.IdleUp;
                    }
                }
            }

            // --- Down ---
            else if (inputState.Down || entity.animation.characterState == CharacterState.MoveDown)
            {
                entity.rigidbody.MoveDown(1);

                // move until player until alligne with tile
                if (entity.rigidbody.rectangle.Y % ChristianGame.WK.TileSize != 0)
                {
                    entity.animation.characterState = CharacterState.MoveDown;
                }
                else
                {
                    if (inputState.Down == false || entity.rigidbody.CanMoveDown(1) == false)
                    {
                        entity.animation.characterState = CharacterState.IdleDown;
                    }
                }

            }

            // --- Right ---
            else if (inputState.Right || entity.animation.characterState == CharacterState.MoveRight)
            {
                entity.rigidbody.MoveRight(1);

                // move until player until alligne with tile
                if (entity.rigidbody.rectangle.X % ChristianGame.WK.TileSize != 0)
                {
                    entity.animation.characterState = CharacterState.MoveRight;
                }
                else
                {
                    if (inputState.Right == false || entity.rigidbody.CanMoveRight(1) == false)
                    {
                        entity.animation.characterState = CharacterState.IdleRight;
                    }
                }

            }

            // --- Left ---
            else if (inputState.Left || entity.animation.characterState == CharacterState.MoveLeft)
            {
                entity.rigidbody.MoveLeft(1);

                // move until player until alligne with tile
                if (entity.rigidbody.rectangle.X % ChristianGame.WK.TileSize != 0)
                {
                    entity.animation.characterState = CharacterState.MoveLeft;
                }
                else
                {
                    if (inputState.Left == false || entity.rigidbody.CanMoveLeft(1) == false)
                    {
                        entity.animation.characterState = CharacterState.IdleLeft;
                    }
                }
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