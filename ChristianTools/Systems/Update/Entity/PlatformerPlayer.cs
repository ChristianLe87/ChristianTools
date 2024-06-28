namespace ChristianTools.Systems.Update
{
    public partial class Entity
    {
        // Always a number factor by the tile width (16: 2,4,8)
        //private static uint gravity = entity.rigidbody.gravity; // 4
        private static uint jumpForce = 12;// gravity * 3;

        public static void PlatformerPlayer(InputState lastInputState, InputState inputState, IEntity entity)
        {
            SimpleSystems.MoveRightLeft_NoClamp(entity, inputState);
            SimpleSystems.JumpSystem(entity, inputState, lastInputState, jumpForce);
        }
    }
}