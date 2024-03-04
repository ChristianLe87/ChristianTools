using ChristianTools.Helpers;
using Microsoft.Xna.Framework;

namespace ChristianTools.Components
{
    public class Rigidbody : IRigidbody
    {
        public double rotationDegree { get; set; }
        public Vector2 force { get; set; }
        public Rectangle rectangle { get; set; }
        public Rigidbody(Rectangle rectangle)
        {
            this.rotationDegree = 0;
            this.force = new Vector2();
            this.rectangle = rectangle;
        }
        
        public void Update()
        {
            // Force
            Move_X((int)force.X);
            Move_Y((int)force.Y);
        }

        public void Move_X(int X)
        {
            int rX = rectangle.X + X;
            int rY = rectangle.Y;
            int rW = rectangle.Width;
            int rH = rectangle.Height;

            rectangle = new Rectangle(rX, rY, rW, rH);
        }

        public void Move_Y(int Y)
        {
            int rX = rectangle.X;
            int rY = rectangle.Y + Y;
            int rW = rectangle.Width;
            int rH = rectangle.Height;

            rectangle = new Rectangle(rX, rY, rW, rH);
        }

        public void SetCenterPosition(Point newCenterPosition)
        {
        }
    }
}