using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Components
{
    public class Camera
    {
        //private Viewport viewport; // Es el rectangulo por donde la camara ve
        public Matrix transform;
        public Vector3 cameraCenterPosition => transform.Translation;

        private IEntity entityToFollow;
        private float zoom { get; set; }

        public Camera(int zoom = 1, IEntity entityToFollow = null)
        {
            this.entityToFollow = entityToFollow;
            this.transform = Matrix.CreateTranslation(Vector3.Zero);
            this.zoom = zoom;
        }

        public void Update()
        {
            if (entityToFollow != null)
            {
                Viewport viewport = ChristianGame.graphicsDeviceManager.GraphicsDevice.Viewport;
                
                //Vector3 cameraPosition = new Vector3((viewport.Width / 2) - entityToFollow.rigidbody.rectangle.Center.X, (viewport.Height / 2) - entityToFollow.rigidbody.rectangle.Center.Y, 0);
                //transform = Matrix.CreateTranslation(cameraPosition);

                transform = Matrix.CreateTranslation(new Vector3(-entityToFollow.rigidbody.rectangle.Center.X, -entityToFollow.rigidbody.rectangle.Center.Y, 0)) *
                            Matrix.CreateScale(new Vector3(zoom, zoom, 0)) *
                            Matrix.CreateTranslation(new Vector3(viewport.Width / 2, viewport.Height / 2, 0));
            }
        }
    }
}