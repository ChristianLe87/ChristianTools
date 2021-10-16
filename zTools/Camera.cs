using Microsoft.Xna.Framework;

namespace zTools
{
    public class Camera
    {
        public Matrix transform;
        int WindowWidth;
        int WindowHeight;

        public Camera(int WindowWidth, int WindowHeight)
        {
            this.WindowWidth = WindowWidth;
            this.WindowHeight = WindowHeight;
        }

        public void Update(Point position)
        {
            Vector2 center = new Vector2(position.X - WindowWidth / 2, position.Y - WindowHeight / 2);

            float scaleX = 1;
            float scaley = 1;

            transform = Matrix.CreateScale(new Vector3(scaleX, scaley, 0)) * Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0));
        }
    }
}
