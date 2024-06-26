namespace ChristianTools.Systems.Update
{
    public partial class Entity
    {
        public static void Add_WASD_Forece(InputState lastInputState, InputState inputState, IEntity entity, int steps = 1)
        {
            if (entity.isActive != true)
                return;

            if (inputState.Up)
                entity.rigidbody.force = new Vector2(entity.rigidbody.force.X, -steps);
            else if (inputState.Down)
                entity.rigidbody.force = new Vector2(entity.rigidbody.force.X, steps);

            if (inputState.Right)
                entity.rigidbody.force = new Vector2(steps, entity.rigidbody.force.Y);
            else if (inputState.Left)
                entity.rigidbody.force = new Vector2(-steps, entity.rigidbody.force.Y);


            BaseUpdateSystem(lastInputState, inputState, entity);
        }
    }
}