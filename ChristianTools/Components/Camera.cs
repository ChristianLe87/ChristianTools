namespace ChristianTools.Components
{
    public class Camera
    {
        //private Viewport viewport; // Es el rectangulo por donde la camara ve
        public Matrix transform;
        public Vector3 cameraCenterPosition => transform.Translation;

        private IEntity entityToFollow;
        private float zoom { get; set; }

        public Camera(IEntity entityToFollow = null)
        {
            this.entityToFollow = entityToFollow;
            this.transform = Matrix.CreateTranslation(Vector3.Zero);
            this.zoom = 1;
        }

        public void Update()
        {
            this.zoom = ChristianGame.WK.ScaleFactor;

            Viewport viewport = ChristianGame.graphicsDeviceManager.GraphicsDevice.Viewport;

            if (entityToFollow != null)
            {
                transform = Matrix.CreateTranslation(new Vector3(-entityToFollow.rigidbody.centerPosition.X, -entityToFollow.rigidbody.centerPosition.Y, 0)) *
                            Matrix.CreateScale(new Vector3(zoom, zoom, 0)) *
                            Matrix.CreateTranslation(new Vector3(viewport.Width / 2, viewport.Height / 2, 0));
            }
            else
            {
                transform = Matrix.CreateScale(new Vector3(zoom, zoom, 0)) *
                            Matrix.CreateTranslation(new Vector3(viewport.Width / 2, viewport.Height / 2, 0));
            }
        }
    }
}
