namespace ChristianTools.Entities
{
    public class ZeroZeroPoint_Entity : ZeroZeroPoint, IEntity
    {
        public ZeroZeroPoint_Entity()
        {
            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => Update(lastInputState, inputState);
        }

        private void Update(InputState lastInputState, InputState inputState)
        {
        }
    }
}
