namespace ChristianTools.Systems.Update
{

    public partial class Entity
    {

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

            BaseUpdateSystem(lastInputState, inputState, entity);
        }
    }
}