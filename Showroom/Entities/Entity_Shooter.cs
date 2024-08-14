
namespace Showroom
{
    public class Entity_Shooter : IEntity
    {
        public IRigidbody rigidbody { get; set; }
        public Animation animation { get; }
        public bool isActive { get; set; }
        public string tag { get; }
        public Guid guid { get; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }

        public Entity_Shooter()
        {
            this.rigidbody = new Rigidbody2(new Vector2(ChristianGame.WK.CanvasWidth / 2, ChristianGame.WK.CanvasHeight / 2), new Point(16, 16));
            this.animation = new Animation();
            this.isActive = true;
            this.tag = "";
            this.guid = Guid.NewGuid();
            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => Update(lastInputState, inputState);
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => ChristianTools.Systems.Draw.Entity.Draw(spriteBatch, this);
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            ChristianTools.Entities.Line line = ChristianGame.GetScene.entities.OfType<ChristianTools.Entities.Line>().FirstOrDefault();

            if (inputState.Action && !lastInputState.Action)
            {

                Vector2 direction = inputState.GetActionOnWorldPosition().ToVector2();
                line?.UpdatePoints(end: direction.ToPoint());

                Entity_Bullet bulletEntity = new Entity_Bullet(direction, 5, 1);
                ChristianGame.GetScene.entities.Add(bulletEntity);
            }
        }
    }
}