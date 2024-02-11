using Microsoft.Xna.Framework;

namespace ChristianTools.Components
{
    public class Rigidbody
    {
        public double rotationDegree;
        public Vector2 force;

        public Rectangle rectangle;

        public Rectangle GetRectangleUp(int scaleFactor) => ChristianTools.Helpers.MyRectangle.GetRectangleUp(rectangle);
        public Rectangle GetRectangleDown(int scaleFactor) => ChristianTools.Helpers.MyRectangle.GetRectangleDown(rectangle);
        public Rectangle GetRectangleLeft(int scaleFactor) => ChristianTools.Helpers.MyRectangle.GetRectangleLeft(rectangle);
        public Rectangle GetRectangleRight(int scaleFactor) => ChristianTools.Helpers.MyRectangle.GetRectangleRight(rectangle);
        public Rectangle GetRectangleScaled(int scaleFactor) => ChristianTools.Helpers.MyRectangle.ScaleRectangleSides(rectangle);
        //public bool isGrounded(int scaleFactor) => (CanMoveDown(scaleFactor) == false);
        //Enums_Interfaces_Delegates.IEntity entity;
        

        public Rigidbody(Rectangle rectangle, Vector2 force = new Vector2())
        {
            this.rotationDegree = 0;
            this.force = force;
            this.rectangle = rectangle;
        }

        public void Update()
        {
            // Force
            Move_X((int)force.X);
            Move_Y((int)force.Y);
        }

        /// <summary>
        /// Move on X, if tiles, dont move
        /// </summary>
        /// <param name="X"></param>
        public void Move_X(int X)
        {
            rectangle.X += X;
        }


        /// <summary>
        /// Move on Y, if tiles, dont move
        /// </summary>
        /// <param name="Y"></param>
        public void Move_Y(int Y)
        {
            rectangle.Y += Y;
        }


        public void SetCenterPosition(Point newCenterPosition)
        {
            rectangle = ChristianTools.Helpers.MyRectangle.CreateRectangle(newCenterPosition, rectangle.Width, rectangle.Height);
        }
    }
}