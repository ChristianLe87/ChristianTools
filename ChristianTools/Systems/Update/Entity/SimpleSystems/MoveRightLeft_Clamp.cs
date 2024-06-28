namespace ChristianTools.Systems.Update
{
    public partial class Entity
    {
        public partial class SimpleSystems
        {
            public static void MoveRightLeft_Clamp(IEntity entity, InputState inputState, uint steps= 1)
            {
                
                // --- Right ---
                if (inputState.Right || entity.animation.characterState == CharacterState.MoveRight)
                {
                    entity.rigidbody.MoveRight(steps);

                    // move until player until alligne with tile
                    if (entity.rigidbody.rectangle.X % ChristianGame.WK.TileSize != 0)
                    {
                        entity.animation.characterState = CharacterState.MoveRight;
                    }
                    else
                    {
                        if (inputState.Right == false || entity.rigidbody.CanMoveRight(steps) == false)
                        {
                            entity.animation.characterState = CharacterState.IdleRight;
                        }
                    }

                }

                // --- Left ---
                else if (inputState.Left || entity.animation.characterState == CharacterState.MoveLeft)
                {
                    entity.rigidbody.MoveLeft(steps);

                    // move until player until alligne with tile
                    if (entity.rigidbody.rectangle.X % ChristianGame.WK.TileSize != 0)
                    {
                        entity.animation.characterState = CharacterState.MoveLeft;
                    }
                    else
                    {
                        if (inputState.Left == false || entity.rigidbody.CanMoveLeft(steps) == false)
                        {
                            entity.animation.characterState = CharacterState.IdleLeft;
                        }
                    }
                }
            }
        }
    }
}