namespace Showroom
{
    public class Entity_Platformer_Player : IEntity
    {
        public IRigidbody rigidbody { get; set; }
        public IAnimation animation { get; }
        public bool isActive { get; set; }
        public string tag { get; }
        public Guid guid { get; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
        
        public Entity_Platformer_Player(Vector2 centerPosition)
        {
            int ts = ChristianGame.WK.TileSize;

            this.rigidbody = new ClassicRigidbody(centerPosition, new Point(ts, ts));
            this.rigidbody.gravity = 4;

            //this.animation = new Animation(ChristianGame.WK.Atlas_Entities.First().Key);
            this.isActive = true;
            this.tag = "";
            this.guid = Guid.NewGuid();
            
            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Entity.PlatformerPlayer(lastInputState, inputState, this);
        }
    }
}