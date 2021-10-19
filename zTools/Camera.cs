using Microsoft.Xna.Framework;

namespace zTools
{
    public class Camera
    {
        public Matrix transform;
        int WindowWidth;
        int WindowHeight;
        float rotation = 0;

        public Camera(int WindowWidth, int WindowHeight)
        {
            this.WindowWidth = WindowWidth;
            this.WindowHeight = WindowHeight;
        }

        public void Update(Point position)
        {
            Vector2 center = new Vector2(position.X - WindowWidth / 2, position.Y - WindowHeight / 2);

            transform = Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0)) * Matrix.CreateRotationZ(rotation);
        }

        public void Rotate()
        {
            rotation += 0.01f;
        }
    }
}