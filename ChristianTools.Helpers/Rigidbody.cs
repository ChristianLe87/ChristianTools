using Microsoft.Xna.Framework;

namespace ChristianTools.Helpers
{
    public class Rigidbody
    {
        Vector2 force;
        public Vector2 GetForce { get => force; }
        Vector2 gravity;

        int scaleFactor;

        public Point centerPosition { get => new Point(transform.X, transform.Y); set { transform.X = value.X; transform.Y = value.Y; } }
        public int centerPosition_X { get => centerPosition.X; set { transform.X = value; } }
        public int centerPosition_Y { get => centerPosition.Y; set { transform.Y = value; } }

        public Rectangle rectangle { get => Tools.Tools.GetRectangle.Rectangle(transform.Center, transform.Width, transform.Height); }

        public Rectangle rectangleUp { get => Tools.Tools.GetRectangle.Up(rectangle, scaleFactor); }
        public Rectangle rectangleDown { get => Tools.Tools.GetRectangle.Down(rectangle, scaleFactor); }
        public Rectangle rectangleLeft { get => Tools.Tools.GetRectangle.Left(rectangle, scaleFactor); }
        public Rectangle rectangleRight { get => Tools.Tools.GetRectangle.Right(rectangle, scaleFactor); }

        Rectangle transform;

        public Rigidbody(Point centerPosition, int Width, int Height, Vector2 gravity, int scaleFactor)
        {
            this.gravity = gravity;
            this.transform = Tools.Tools.GetRectangle.Rectangle(centerPosition, Width, Height);
            this.scaleFactor = scaleFactor;
        }

        public void Update()
        {
            // Force
            centerPosition += (force * scaleFactor).ToPoint();

            // Gravity
            centerPosition += gravity.ToPoint();
        }

        public void AddForce(Vector2 forceToAdd)
        {
            force += forceToAdd;
        }

        public void SetForce(Vector2 force)
        {
            this.force = force;
        }
    }
}