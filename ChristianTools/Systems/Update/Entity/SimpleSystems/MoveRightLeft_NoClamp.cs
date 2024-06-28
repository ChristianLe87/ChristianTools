namespace ChristianTools.Systems.Update
{
    public partial class Entity
    {
        public partial class SimpleSystems
        {
            public static void MoveRightLeft_NoClamp(IEntity entity, InputState inputState, uint steps = 1)
            {

                if (inputState.Right)
                {
                    if (entity.rigidbody.CanMoveRight(steps))
                    {
                        entity.rigidbody?.MoveRight(steps);
                        entity.animation.characterState = CharacterState.MoveRight;
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
}