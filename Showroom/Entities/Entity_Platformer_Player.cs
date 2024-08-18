namespace Showroom
{
    public class Entity_Platformer_Player : IEntity
    {
        public IRigidbody rigidbody { get; set; }
        public Animation animation { get; }
        public bool isActive { get; set; }
        public string tag { get; }
        public Guid guid { get; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
        
        public Entity_Platformer_Player(Vector2 centerPosition)
        {
            this.rigidbody = new ClassicRigidbody(centerPosition, new Point(16, 16));
            this.rigidbody.gravity = 4;

            this.animation = new Animation();
            this.isActive = true;
            this.tag = "";
            this.guid = Guid.NewGuid();
            
            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Entity.PlatformerPlayer(lastInputState, inputState, this);
        }
    }
}