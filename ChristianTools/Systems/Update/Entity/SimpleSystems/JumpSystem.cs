namespace ChristianTools.Systems.Update;

public partial class Entity
{
    public partial class SimpleSystems
    {
        public static void JumpSystem(IEntity entity, InputState inputState, InputState lastInputState, uint jumpForce, uint steps = 1)
        {
            if (inputState.Jump && !lastInputState.Jump && entity.rigidbody.CanMoveDown(steps) == false)
            {
                entity.rigidbody.force = new Vector2(0, -jumpForce);
            }

            if (entity.rigidbody.force.Y <= 0)
            {
                entity.rigidbody.force += new Vector2(0, 0.65f);
            }
        }
    }
}