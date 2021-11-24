using Microsoft.Xna.Framework;

namespace ChristianTools.Helpers
{
    public class Rigidbody
    {
        public Vector2 force { get; private set; }
        Vector2 gravity;

        public Point centerPosition { get; set; }

        public Rectangle rectangle { get => Tools.Tools.GetRectangle.Rectangle(centerPosition, Width, Height); }

        public Rectangle rectangleUp { get => Tools.Tools.GetRectangle.Up(rectangle, scaleFactor); }
        public Rectangle rectangleDown { get => Tools.Tools.GetRectangle.Down(rectangle, scaleFactor); }
        public Rectangle rectangleLeft { get => Tools.Tools.GetRectangle.Left(rectangle, scaleFactor); }
        public Rectangle rectangleRight { get => Tools.Tools.GetRectangle.Right(rectangle, scaleFactor); }

        int Width;
        int Height;

        int scaleFactor;
        public Rigidbody(Point centerPosition, int Width, int Height, Vector2 gravity, int scaleFactor)
        {
            this.gravity = gravity;
            this.centerPosition = centerPosition;
            this.Width = Width;
            this.Height = Height;
            this.scaleFactor = scaleFactor;
        }

        public void Update()
        {
            // Force
            centerPosition += force.ToPoint();

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

        public void SetForce_X(int X)
        {
            this.force = new Vector2(X, force.Y);
        }

        public void SetForce_Y(int Y)
        {
            this.force = new Vector2(force.X, Y);
        }

        public void Move_X(int X)
        {
            centerPosition = new Point(centerPosition.X + X, centerPosition.Y);
        }

        public void Move_Y(int Y)
        {
            centerPosition = new Point(centerPosition.X, centerPosition.Y + Y);
        }
    }
}