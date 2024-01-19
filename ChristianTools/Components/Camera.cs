using Microsoft.Xna.Framework;

namespace ChristianTools.Components
{
    public class Camera
    {
        private float zoom = 1;
        private Vector2 position { get; set; }

        public Rectangle cameraView
        {
            get { return ChristianTools.Helpers.MyRectangle.CreateRectangle(new Point((int)position.X, (int)position.Y), ChristianGame.WK.canvasWidth, ChristianGame.WK.canvasHeight); }
        }

        public Matrix transform { get; private set; }

        public Camera(Point position = new Point())
        {
            this.position = new Vector2(position.X, position.Y);
        }


        private void UpdateMatrix()
        {
            transform = Matrix.CreateTranslation(new Vector3((ChristianGame.WK.canvasWidth * 0.5f) - position.X, (ChristianGame.WK.canvasWidth * 0.5f) - position.Y, 0)) *
                        Matrix.CreateScale(this.zoom);
        }

        public void UpdateCamera()
        {
            UpdateMatrix();
        }
        
        public void UpdateCamera(Point setCenter)
        {
            this.position = new Vector2(setCenter.X, setCenter.Y);
            UpdateMatrix();
        }
    }
}