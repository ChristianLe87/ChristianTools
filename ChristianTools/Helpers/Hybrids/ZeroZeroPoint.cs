namespace ChristianTools.Helpers.Hybrids
{
    public class ZeroZeroPoint
    {
        public IRigidbody rigidbody { get; set; }
        public Animation animation { get; }
        public bool isActive { get; set; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
        public string tag { get; }
        public Guid guid { get; }

        private Texture2D texture2D_X;
        private Texture2D texture2D_Y;

        public ZeroZeroPoint()
        {
            this.rigidbody = new ClassicRigidbody(new Vector2(0, 0), new Point(200, 200));//new Rectangle(-100, -100, 200, 200))));
            this.animation = new Animation();
            this.isActive = true;
            this.tag = "";
            this.guid = Guid.NewGuid();

            texture2D_X = ChristianTools.Helpers.Texture.CreateColorTexture(Color.Red, 2, rigidbody.size.Y);
            texture2D_Y = ChristianTools.Helpers.Texture.CreateColorTexture(Color.Green, rigidbody.size.X, 2);

            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => Draw(spriteBatch);
        }

        private void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D_X, new Rectangle(-texture2D_X.Width / 2, -texture2D_X.Height / 2, texture2D_X.Width, texture2D_X.Height), Color.White);
            spriteBatch.Draw(texture2D_Y, new Rectangle(-texture2D_Y.Width / 2, -texture2D_Y.Height / 2, texture2D_Y.Width, texture2D_Y.Height), Color.White);
        }
    }
}
