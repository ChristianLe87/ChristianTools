namespace ChristianTools.Prefabs
{
    public class BaseEntity : IEntity
    {
        public IRigidbody rigidbody { get; set; }
        public IAnimation animation { get; set; }
        public bool isActive { get; set; }
        public string tag { get; }
        public Guid guid { get; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }

        public BaseEntity(Rectangle rectangle, string tag = "", bool isActive = true)
        {
            int ts = ChristianGame.WK.TileSize;

            this.rigidbody = new ClassicRigidbody(rectangle.Center.ToVector2(), new Point(ts, ts));
            this.isActive = isActive;
            this.tag = tag;
            this.guid = Guid.NewGuid();
            //this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => Systems.Update.Entity.BaseUpdateSystem(lastInputState, inputState, this);
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => Systems.Draw.Entity.Draw(spriteBatch, this);
        }
        public BaseEntity(Rectangle rectangle, string atlasTexture, string tag = "", bool isActive = true)
        {
            int ts = ChristianGame.WK.TileSize;

            this.rigidbody = new ClassicRigidbody(rectangle.Center.ToVector2(), new Point(ts, ts));
            this.animation = new Animation(atlasTexture);
            this.isActive = isActive;
            this.tag = tag;
            this.guid = Guid.NewGuid();
            //this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => Systems.Update.Entity.BaseUpdateSystem(lastInputState, inputState, this);
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => Systems.Draw.Entity.Draw(spriteBatch, this);
        }

        public BaseEntity(Rectangle rectangle, Color color, string tag = "", bool isActive = true)
        {
            int ts = ChristianGame.WK.TileSize;

            this.rigidbody = new ClassicRigidbody(rectangle);
            this.animation = new Animation(color);
            this.isActive = isActive;
            this.tag = tag;
            this.guid = Guid.NewGuid();
            //this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => Systems.Update.Entity.BaseUpdateSystem(lastInputState, inputState, this);
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => Systems.Draw.Entity.Draw(spriteBatch, this);
        }

        public BaseEntity(Point centerPosition, Color color, string tag = "", bool isActive = true)
        {
            int ts = ChristianGame.WK.TileSize;

            this.rigidbody = new ClassicRigidbody(centerPosition.ToVector2(), new Point(ts, ts));
            this.animation = new Animation(color);
            this.isActive = isActive;
            this.tag = tag;
            this.guid = Guid.NewGuid();
            //this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => Systems.Update.Entity.BaseUpdateSystem(lastInputState, inputState, this);
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => Systems.Draw.Entity.Draw(spriteBatch, this);
        }
    }
}
