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
        /// Move on X, if tiles, dont move
        /// </summary>
        /// <param name="X"></param>
        public void Move_X(int X)
        {
            if (X > 0) // Right
                MoveRight(X);
            else if (X < 0) // Left
                MoveLeft(X);
        }

        /// <summary>
        /// Move on Y, if tiles, dont move
        /// </summary>
        /// <param name="Y"></param>
        public void Move_Y(int Y)
        {
            if (Y < 0) // Up
                MoveUp(Y);
            else if (Y > 0) // Down
                MoveDown(Y);
        }


        public void MoveUp(int Y)
        {
            if (CanMoveUp(Math.Abs(Y)))
            {
                SetCenterPosition(new Point(rectangle.Center.X, rectangle.Center.Y + Y));
            }
            else
            {
                // clamp
                Tile tileUp = tiles.FirstOrDefault(x => x.rectangle.Intersects(GetRectangleUp(Math.Abs(Y))));
                int dif = tileUp.rectangle.Bottom - rectangle.Y;

                SetCenterPosition(new Point(rectangle.Center.X, rectangle.Center.Y + dif));
            }
        }

        public void MoveDown(int Y)
        {
            if (CanMoveDown(Math.Abs(Y)))
            {
                SetCenterPosition(new Point(rectangle.Center.X, rectangle.Center.Y + Y));
            }
            else
            {
                // clamp
                Tile tileDown = tiles.FirstOrDefault(x => x.rectangle.Intersects(GetRectangleDown(Math.Abs(Y))));
                int dif = rectangle.Bottom - tileDown.rectangle.Y;
                SetCenterPosition(new Point(rectangle.Center.X, rectangle.Center.Y + dif));
            }
        }


        void MoveRight(int X)
        {
            if (CanMoveRight(X) == true)
            {
                SetCenterPosition(new Point(rectangle.Center.X + X, rectangle.Center.Y));
            }
            else
            {
                // clamp    
                Tile tileRight = tiles.FirstOrDefault(x => x.rectangle.Intersects(GetRectangleRight(Math.Abs(X))));
                int dif = rectangle.Right - tileRight.rectangle.X;

                SetCenterPosition(new Point(rectangle.Center.X - dif, rectangle.Center.Y));

            }
        }

        void MoveLeft(int X)
        {
            if (CanMoveLeft(X) == true)
            {
                SetCenterPosition(new Point(rectangle.Center.X + X, rectangle.Center.Y));
            }
            else
            {
                // clamp    
                Tile tileLeft = tiles.FirstOrDefault(x => x.rectangle.Intersects(GetRectangleLeft(Math.Abs(X))));
                int dif = tileLeft.rectangle.Right - rectangle.X;

                SetCenterPosition(new Point(rectangle.Center.X - dif, rectangle.Center.Y));
            }
        }

        public bool CanMoveUp(int Y)
        {
            if (tiles == null) return true;
            return !tiles.Any(x => x.rectangle.Intersects(GetRectangleUp(Math.Abs(Y))));
        }

        public bool CanMoveDown(int Y)
        {
            if (tiles == null) return true;
            return !tiles.Any(x => x.rectangle.Intersects(GetRectangleDown(Math.Abs(Y))));
        }

        public bool CanMoveRight(int X)
        {
            if (tiles == null) return true;
            return !tiles.Any(x => x.rectangle.Intersects(GetRectangleRight(Math.Abs(X))));
        }

        public bool CanMoveLeft(int X)
        {
            if (tiles == null) return true;
            return !tiles.Any(x => x.rectangle.Intersects(GetRectangleLeft(Math.Abs(X))));
        }


        public void SetCenterPosition(Point newCenterPosition)
        {
            rectangle = ChristianTools.Helpers.MyRectangle.CreateRectangle(newCenterPosition, rectangle.Width, rectangle.Height);
        }
    }
}