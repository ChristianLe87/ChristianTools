using System.Collections.Generic;
using System.Linq;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;

namespace ChristianTools.Components
{
    public class Rigidbody : IRigidbody
    {
        public double rotationDegree { get; set; }
        public Vector2 force { get; set; }
        public Rectangle rectangle { get; set; }
        public Rectangle GetRectangleUp => MyRectangle.GetRectangleUp(rectangle, scaleFactor);
        public Rectangle GetRectangleDown => MyRectangle.GetRectangleDown(rectangle, scaleFactor);
        public Rectangle GetRectangleLeft => MyRectangle.GetRectangleLeft(rectangle, scaleFactor);
        public Rectangle GetRectangleRight => MyRectangle.GetRectangleRight(rectangle, scaleFactor);

        private Tile[,] surroundingElements;
        private int scaleFactor = 2;
        public bool isGrounded => Other.GetRow(surroundingElements, 2).Where(x => x != null).Where(x => x.worldRectangle.Intersects(GetRectangleDown)).Count() > 0;

        public Rigidbody(Rectangle rectangle, Vector2 force = new Vector2())
        {
            this.rotationDegree = 0;
            this.force = force;
            this.rectangle = rectangle;
        }

        public void Update()
        {
            Point pointInMap = new Point(rectangle.Center.X / 16, rectangle.Center.Y / 16);
            this.surroundingElements = Other.GetSurroundingElements(ChristianGame.GetScene?.map?.mainTiles, pointInMap);

            UpdateForce();
            UpdateClamp();
        }

        private void UpdateForce()
        {
            Move_Y((int)force.Y);
            Move_X((int)force.X);
        }

        private void UpdateClamp()
        {
            if (CanMoveDown() == false)
                ClampDown();

            if (CanMoveUp() == false)
                ClampUp();
        }


        public void Move_X(int X)
        {
            rectangle = ChristianTools.Helpers.MyRectangle.MoveRectangle_X(rectangle, X);
        }

        public void Move_Y(int Y)
        {
            if (CanMoveDown() && Y > 0)
                rectangle = ChristianTools.Helpers.MyRectangle.MoveRectangle_Y(rectangle, Y);

            if (CanMoveUp() && Y < 0)
                rectangle = ChristianTools.Helpers.MyRectangle.MoveRectangle_Y(rectangle, Y);
        }

        public void SetCenterPosition(Point newCenterPosition)
        {
            rectangle = ChristianTools.Helpers.MyRectangle.CreateRectangle(newCenterPosition, rectangle.Width, rectangle.Height);
        }

        private bool CanMoveDown()
        {
            int rowNumber = 2;
            if (Other.GetRow(surroundingElements, rowNumber).Where(x => x != null).Where(x => x.worldRectangle.Intersects(GetRectangleDown)).Count() > 0)
                return false;
            else
                return true;
        }

        private bool CanMoveUp()
        {
            int rowNumber = 0;
            if (Other.GetRow(surroundingElements, rowNumber).Where(x => x != null).Where(x => x.worldRectangle.Intersects(GetRectangleUp)).Count() > 0)
                return false;
            else
                return true;
        }


        private void ClampDown()
        {
            Tile tile = ChristianTools.Helpers.Other.FlattenArray(ChristianGame.GetScene.map?.mainTiles).Where(x => x != null).FirstOrDefault(x => x.worldRectangle.Intersects(GetRectangleDown));
            if (tile != null)
            {
                int dif = tile.worldRectangle.Y - rectangle.Bottom;
                if (dif != 0) rectangle = MyRectangle.MoveRectangle_Y(rectangle, dif);
            }
        }

        private void ClampUp()
        {
            Tile tile = ChristianTools.Helpers.Other.FlattenArray(ChristianGame.GetScene.map?.mainTiles).Where(x => x != null).FirstOrDefault(x => x.worldRectangle.Intersects(GetRectangleUp));
            if (tile != null)
            {
                int dif = tile.worldRectangle.Bottom - rectangle.Y;
                if (dif != 0) rectangle = MyRectangle.MoveRectangle_Y(rectangle, dif);
            }
        }
    }
}
