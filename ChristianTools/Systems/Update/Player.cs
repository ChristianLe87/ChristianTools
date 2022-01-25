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
                public static void Basic_XY_Movement(InputState inputState, IEntity entity)
                {
                    if (inputState.Up)
                        entity.rigidbody.Move_Y(-ChristianGame.Default.ScaleFactor);
                    else if (inputState.Down)
                        entity.rigidbody.Move_Y(+ChristianGame.Default.ScaleFactor);

                    if (inputState.Right)
                        entity.rigidbody.Move_X(+ChristianGame.Default.ScaleFactor);
                    else if (inputState.Left)
                        entity.rigidbody.Move_X(-ChristianGame.Default.ScaleFactor);

                    entity.rigidbody.Update();
                }

                public static void Zeldamon_Movement(InputState inputState, IEntity entity)
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
                            entity.rigidbody.Move_Y(-ChristianGame.Default.ScaleFactor);

                            // move until player until alligne with tile
                            if (entity.rigidbody.rectangle.Y % (ChristianGame.Default.AssetSize * ChristianGame.Default.ScaleFactor) != 0)
                            {
                                entity.characterState = CharacterState.MoveUp;
                            }
                            else
                            {
                                if (inputState.Up == false || entity.rigidbody.CanMoveUp(ChristianGame.Default.ScaleFactor) == false)
                                {
                                    entity.characterState = CharacterState.IdleUp;
                                }
                            }
                        }
                        else if (inputState.Down || entity.characterState == CharacterState.MoveDown)
                        {
                            entity.rigidbody.Move_Y(ChristianGame.Default.ScaleFactor);

                            // move until player until alligne with tile
                            if (entity.rigidbody.rectangle.Y % (ChristianGame.Default.AssetSize * ChristianGame.Default.ScaleFactor) != 0)
                            {
                                entity.characterState = CharacterState.MoveDown;
                            }
                            else
                            {
                                if (inputState.Down == false || entity.rigidbody.CanMoveDown(ChristianGame.Default.ScaleFactor) == false)
                                {
                                    entity.characterState = CharacterState.IdleDown;
                                }
                            }

                        }
                        else if (inputState.Right || entity.characterState == CharacterState.MoveRight)
                        {
                            entity.rigidbody.Move_X(ChristianGame.Default.ScaleFactor);

                            // move until player until alligne with tile
                            if (entity.rigidbody.rectangle.X % (ChristianGame.Default.AssetSize * ChristianGame.Default.ScaleFactor) != 0)
                            {
                                entity.characterState = CharacterState.MoveRight;
                            }
                            else
                            {
                                if (inputState.Right == false || entity.rigidbody.CanMoveRight(ChristianGame.Default.ScaleFactor) == false)
                                {
                                    entity.characterState = CharacterState.IdleRight;
                                }
                            }

                        }
                        else if (inputState.Left || entity.characterState == CharacterState.MoveLeft)
                        {
                            entity.rigidbody.Move_X(-ChristianGame.Default.ScaleFactor);

                            // move until player until alligne with tile
                            if (entity.rigidbody.rectangle.X % (ChristianGame.Default.AssetSize * ChristianGame.Default.ScaleFactor) != 0)
                            {
                                entity.characterState = CharacterState.MoveLeft;
                            }
                            else
                            {
                                if (inputState.Left == false || entity.rigidbody.CanMoveLeft(ChristianGame.Default.ScaleFactor) == false)
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