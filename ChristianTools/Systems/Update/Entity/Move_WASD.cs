namespace ChristianTools.Systems.Update
{

    public partial class Entity
    {
        public static void Move_WASD_Clamp(InputState lastInputState, InputState inputState, IEntity entity)
        {
            SimpleSystems.MoveRightLeft_Clamp(entity, inputState);
            SimpleSystems.MoveUpDown_Clamp(entity, inputState);
        }
    }
}