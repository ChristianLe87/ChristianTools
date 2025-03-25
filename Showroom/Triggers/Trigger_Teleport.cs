namespace Showroom
{
    public class Trigger_Teleport : ITriggerPoint
    {
        public IRigidbody rigidbody { get; set; }
        public Animation animation { get; }
        public bool isActive { get; set; }
        public string tag { get; }
        public Guid guid { get; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
        private string goToScene;

        public Trigger_Teleport(string goToScene, Rectangle rectangle, string tag = "", bool isActive = true)
        {
            this.goToScene = goToScene;
            int ts = ChristianGame.WK.TileSize;

            this.rigidbody = new ClassicRigidbody(rectangle.Center.ToVector2(), new Point(ts, ts));
            this.animation = new Animation();
            this.isActive = true;
            this.tag = "";
            this.guid = Guid.NewGuid();
            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem();
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => ChristianTools.Systems.Draw.Trigger.Draw(spriteBatch, this);
        }

        private void UpdateSystem()
        {
            int ts = ChristianGame.WK.TileSize;

            var player = ChristianGame.GetScene.entities?.FirstOrDefault(e => e.tag == "player");
            if (player != null)
            {
                if (player.rigidbody.GetRectangle.Intersects(this.rigidbody.GetRectangle))
                {
                    ChristianGame.ChangeToScene(goToScene);

                    player = ChristianGame.GetScene.entities.FirstOrDefault(e => e.tag == "player");
                    var rectangle = new Rectangle(8 * ts, 16 * ts, ts, ts);
                    player.rigidbody.centerPosition = rectangle.Center.ToVector2();
                }
            }
        }
    }
}