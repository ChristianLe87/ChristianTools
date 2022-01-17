using ChristianTools.Helpers;

namespace ChristianTools.Systems
{
    public partial class Systems
    {
        public partial class Update
        {
            public class Player
            {
                /// <summary>
                /// -> This already update Rigidbody to check colisions with map
                /// </summary>
                /// <param name="inputState"></param>
                /// <param name="entity"></param>
                /// <param name="scaleFactor"></param>
                public static void Basic_XY_Movement(InputState inputState, IEntity entity, int scaleFactor)
                {
                    if (inputState.Up)
                        entity.rigidbody.Move_Y(-scaleFactor);
                    else if (inputState.Down)
                        entity.rigidbody.Move_Y(+scaleFactor);

                    if (inputState.Right)
                        entity.rigidbody.Move_X(+scaleFactor);
                    else if (inputState.Left)
                        entity.rigidbody.Move_X(-scaleFactor);

                    entity.rigidbody.Update();
                }

                public static void Zeldamon_Movement(InputState inputState, IEntity entity, int scaleFactor, int assetSize)
                {
                    // Implementation
                    {
                        Move();
                        //entity.animation.Update();
                    }


                    // Helpers
                    void Move()
                    {
                        if (inputState.Up || entity.characterState == CharacterState.MoveUp)
                        {
                            entity.rigidbody.Move_Y(-scaleFactor);

                            // move until player until alligne with tile
                            if (entity.rigidbody.rectangle.Y % (assetSize * scaleFactor) != 0)
                            {
                                entity.characterState = CharacterState.MoveUp;
                            }
                            else
                            {
                                if (inputState.Up == false || entity.rigidbody.CanMoveUp(scaleFactor) == false)
                                {
                                    entity.characterState = CharacterState.IdleUp;
                                }
                            }
                        }
                        else if (inputState.Down || entity.characterState == CharacterState.MoveDown)
                        {
                            entity.rigidbody.Move_Y(scaleFactor);

                            // move until player until alligne with tile
                            if (entity.rigidbody.rectangle.Y % (assetSize * scaleFactor) != 0)
                            {
                                entity.characterState = CharacterState.MoveDown;
                            }
                            else
                            {
                                if (inputState.Down == false || entity.rigidbody.CanMoveDown(scaleFactor) == false)
                                {
                                    entity.characterState = CharacterState.IdleDown;
                                }
                            }

                        }
                        else if (inputState.Right || entity.characterState == CharacterState.MoveRight)
                        {
                            entity.rigidbody.Move_X(scaleFactor);

                            // move until player until alligne with tile
                            if (entity.rigidbody.rectangle.X % (assetSize * scaleFactor) != 0)
                            {
                                entity.characterState = CharacterState.MoveRight;
                            }
                            else
                            {
                                if (inputState.Right == false || entity.rigidbody.CanMoveRight(scaleFactor) == false)
                                {
                                    entity.characterState = CharacterState.IdleRight;
                                }
                            }

                        }
                        else if (inputState.Left || entity.characterState == CharacterState.MoveLeft)
                        {
                            entity.rigidbody.Move_X(-scaleFactor);

                            // move until player until alligne with tile
                            if (entity.rigidbody.rectangle.X % (assetSize * scaleFactor) != 0)
                            {
                                entity.characterState = CharacterState.MoveLeft;
                            }
                            else
                            {
                                if (inputState.Left == false || entity.rigidbody.CanMoveLeft(scaleFactor) == false)
                                {
                                    entity.characterState = CharacterState.IdleLeft;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}