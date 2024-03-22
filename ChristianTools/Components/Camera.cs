using ChristianTools.Helpers;
using ChristianTools.Systems.Update;
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

        public Camera(IEntity entityToFollow = null)
        {
            this.entityToFollow = entityToFollow;
            this.transform = new Matrix();
        }

        public void Update()
        {
            if (entityToFollow != null)
            {
                Viewport viewport = ChristianGame.graphicsDeviceManager.GraphicsDevice.Viewport;
                Vector3 cameraPosition = new Vector3((viewport.Width / 2) - entityToFollow.rigidbody.rectangle.Center.X, (viewport.Height / 2) - entityToFollow.rigidbody.rectangle.Center.Y, 0);
                transform = Matrix.CreateTranslation(cameraPosition);    
            }
        }
    }
}