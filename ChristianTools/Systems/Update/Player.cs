using ChristianTools.Helpers;

namespace ChristianTools.Systems
{
    public partial class Systems
    {
        public partial class Update
        {
            public class Player
            {
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
                }
            }
        }
    }
}