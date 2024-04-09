namespace Showroom
{
    public class Entity_Touch : BaseEntity
    {
        public Entity_Touch(Rectangle rectangle, Rectangle imageFromAtlas, string tag = "", bool isActive = true) : base(rectangle, imageFromAtlas, tag, isActive)
        {
            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => Update(lastInputState, inputState);
        }

        private void Update(InputState lastInputState, InputState inputState)
        {
            ChristianTools.Systems.Update.Entity.Move_WASD(lastInputState, inputState, this, 10);
            if (inputState.Action || inputState.touch.IsTouchDown())
            {
                rigidbody.rectangle = ChristianTools.Helpers.MyRectangle.CreateRectangle(inputState.GetActionOnWorldPosition(), 16, 16);
            }
        }
    }
}