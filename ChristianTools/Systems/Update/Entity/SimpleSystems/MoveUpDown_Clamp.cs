namespace ChristianTools.Systems.Update
{
    public partial class Entity
    {
        public partial class SimpleSystems
        {
            public static void MoveUpDown_Clamp(IEntity entity, InputState inputState, uint steps = 1)
            {

                // --- Up ---
                if (inputState.Up || entity.animation.characterState == CharacterState.MoveUp)
                {
                    entity.rigidbody.MoveUp(steps);

                    // move until player until alligne with tile
                    if (entity.rigidbody.rectangle.Y % ChristianGame.WK.TileSize != 0)
                    {
                        entity.animation.characterState = CharacterState.MoveUp;
                    }
                    else
                    {
                        if (inputState.Up == false || entity.rigidbody.CanMoveUp(steps) == false)
                        {
                            entity.animation.characterState = CharacterState.IdleUp;
                        }
                    }
                }

                // --- Down ---
                else if (inputState.Down || entity.animation.characterState == CharacterState.MoveDown)
                {
                    entity.rigidbody.MoveDown(steps);

                    // move until player until alligne with tile
                    if (entity.rigidbody.rectangle.Y % ChristianGame.WK.TileSize != 0)
                    {
                        entity.animation.characterState = CharacterState.MoveDown;
                    }
                    else
                    {
                        if (inputState.Down == false || entity.rigidbody.CanMoveDown(steps) == false)
                        {
                            entity.animation.characterState = CharacterState.IdleDown;
                        }
                    }

                }
            }
        }
    }
}