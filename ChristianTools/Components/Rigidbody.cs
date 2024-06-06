namespace ChristianTools.Components
{
    public class Rigidbody
    {
        public Vector2 force { get; set; }
        public Rectangle rectangle { get; set; }
        public Rectangle GetRectangleUp(int steps) => ChristianTools.Helpers.MyRectangle.GetRectangleUp(rectangle, steps);
        public Rectangle GetRectangleDown(int steps) => ChristianTools.Helpers.MyRectangle.GetRectangleDown(rectangle, steps);
        public Rectangle GetRectangleLeft(int steps) => ChristianTools.Helpers.MyRectangle.GetRectangleLeft(rectangle, steps);
        public Rectangle GetRectangleRight(int steps) => ChristianTools.Helpers.MyRectangle.GetRectangleRight(rectangle, steps);

        public List<Tile> tiles;

        public Rigidbody(Rectangle rectangle)
        {
            this.force = Vector2.Zero;
            this.rectangle = rectangle;
        }

        public void Update()
        {
            Point pointInMap = new Point(rectangle.Center.X / 16, rectangle.Center.Y / 16);
            Tile[,] surroundingElements = Other.GetSurroundingElements(ChristianGame.GetScene?.map?.mainTiles, pointInMap);
            this.tiles = ChristianTools.Helpers.Other.FlattenArray(surroundingElements).Where(x => x != null).ToList();

            Move_Y((int)force.Y);
            Move_X((int)force.X);
        }



        /// <summary>
        /// positive move right, negative move left
        /// </summary>
        /// <param name="X"></param>
        public void Move_X(int X)
        {
            if (X > 0) // Right
                MoveRight((uint)Math.Abs(X));
            else if (X < 0) // Left
                MoveLeft((uint)Math.Abs(X));
        }

        /// <summary>
        /// positive move right, negative move left
        /// </summary>
        /// <param name="Y"></param>
        public void Move_Y(int Y)
        {
            if (Y < 0) // Up
                MoveUp((uint)Math.Abs(Y));
            else if (Y > 0) // Down
                MoveDown((uint)Math.Abs(Y));
        }

        // Private because if public, will be confusing with Move_X() and Move_Y() -> Just, keep private
        public void MoveUp(uint steps)
        {
            if (CanMoveUp(steps))
            {
                SetCenterPosition(new Point(rectangle.Center.X, rectangle.Center.Y - (int)steps));
            }
            else
            {
                // clamp
                Tile tileUp = tiles.FirstOrDefault(x => x.rectangle.Intersects(GetRectangleUp((int)steps)));
                int dif = tileUp.rectangle.Bottom - rectangle.Y;

                SetCenterPosition(new Point(rectangle.Center.X, rectangle.Center.Y + dif));
            }
        }

        // Private because if public, will be confusing with Move_X() and Move_Y() -> Just, keep private
        public void MoveDown(uint steps)
        {
            if (CanMoveDown(steps))
            {
                SetCenterPosition(new Point(rectangle.Center.X, rectangle.Center.Y + (int)steps));
            }
            else
            {
                // clamp
                Tile tileDown = tiles.FirstOrDefault(x => x.rectangle.Intersects(GetRectangleDown((int)steps)));
                int dif = rectangle.Bottom - tileDown.rectangle.Y;
                SetCenterPosition(new Point(rectangle.Center.X, rectangle.Center.Y + dif));
            }
        }

        // Private because if public, will be confusing with Move_X() and Move_Y() -> Just, keep private
        public void MoveRight(uint steps)
        {
            if (CanMoveRight(steps) == true)
            {
                SetCenterPosition(new Point(rectangle.Center.X + (int)steps, rectangle.Center.Y));
            }
            else
            {
                // clamp    
                Tile tileRight = tiles.FirstOrDefault(x => x.rectangle.Intersects(GetRectangleRight((int)steps)));
                int dif = rectangle.Right - tileRight.rectangle.X;

                SetCenterPosition(new Point(rectangle.Center.X - dif, rectangle.Center.Y));
            }
        }

        // Private because if public, will be confusing with Move_X() and Move_Y() -> Just, keep private
        public void MoveLeft(uint steps)
        {
            if (CanMoveLeft(steps) == true)
            {
                SetCenterPosition(new Point(rectangle.Center.X - (int)steps, rectangle.Center.Y));
            }
            else
            {
                // clamp    
                Tile tileLeft = tiles.FirstOrDefault(x => x.rectangle.Intersects(GetRectangleLeft((int)steps)));
                int dif = tileLeft.rectangle.Right - rectangle.X;

                SetCenterPosition(new Point(rectangle.Center.X - dif, rectangle.Center.Y));
            }
        }

        public bool CanMoveUp(uint Y)
        {
            if (tiles == null) return true;
            return !tiles.Any(x => x.rectangle.Intersects(GetRectangleUp((int)Y)));
        }

        public bool CanMoveDown(uint Y)
        {
            if (tiles == null) return true;
            return !tiles.Any(x => x.rectangle.Intersects(GetRectangleDown((int)Y)));
        }

        public bool CanMoveRight(uint X)
        {
            if (tiles == null) return true;
            return !tiles.Any(x => x.rectangle.Intersects(GetRectangleRight((int)X)));
        }

        public bool CanMoveLeft(uint X)
        {
            if (tiles == null) return true;
            return !tiles.Any(x => x.rectangle.Intersects(GetRectangleLeft((int)X)));
        }


        public void SetCenterPosition(Point newCenterPosition)
        {
            rectangle = ChristianTools.Helpers.MyRectangle.CreateRectangle(newCenterPosition, rectangle.Width, rectangle.Height);
        }
    }
}