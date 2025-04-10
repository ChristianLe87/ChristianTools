namespace ChristianTools.Prefabs
{
    public abstract class BaseEntity : IEntity
    {
        public IRigidbody rigidbody { get; set; }
        public IAnimation animation { get; }
        public bool isActive { get; set; }
        public string tag { get; }
        public Guid guid { get; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
        
        public BaseEntity(Rectangle rectangle, string tag = "", bool isActive = true)
        {
            int ts = ChristianGame.WK.TileSize;

            this.rigidbody = new ClassicRigidbody(rectangle.Center.ToVector2(), new Point(ts, ts));
            this.animation = new Animation("MyAtlasTexture");
            this.isActive = isActive;
            this.tag = tag;
            this.guid = Guid.NewGuid();
            //this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => Systems.Update.Entity.BaseUpdateSystem(lastInputState, inputState, this);
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => Systems.Draw.Entity.Draw(spriteBatch, this);
        }
    }
}
