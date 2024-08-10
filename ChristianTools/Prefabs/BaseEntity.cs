namespace ChristianTools.Prefabs
{
    public abstract class BaseEntity : IEntity
    {
        public IRigidbody rigidbody { get; set; }
        public Animation animation { get; }
        public bool isActive { get; set; }
        public string tag { get; }
        public Guid guid { get; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }

        public BaseEntity(Rectangle rectangle, string tag = "", bool isActive = true)
        {
            this.rigidbody = new ClassicRigidbody(rectangle);
            this.animation = new Animation();
            this.isActive = isActive;
            this.tag = tag;
            this.guid = Guid.NewGuid();
            //this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => Systems.Update.Entity.BaseUpdateSystem(lastInputState, inputState, this);
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => Systems.Draw.Entity.Draw(spriteBatch, this);
        }
    }
}
