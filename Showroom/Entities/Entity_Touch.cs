namespace Showroom
{
    public class Entity_Touch : BaseEntity
    {
        public Entity_Touch(Rectangle rectangle, string tag = "", bool isActive = true) : base(rectangle, tag, isActive)
        {
            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => Update(lastInputState, inputState);
        }

        private void Update(InputState lastInputState, InputState inputState)
        {
            ChristianTools.Systems.Update.Entity.Move_WASD_Clamp(lastInputState, inputState, this);
            if (inputState.Action || inputState.touch.IsTouchDown())
            {
                rigidbody.centerPosition = inputState.GetActionOnWorldPosition().ToVector2();
            }
        }
    }
}