namespace ChristianTools.Components
{
    public class ClassicRigidbody : IRigidbody
    {
        public Vector2 force { get; set; }
        public Vector2 centerPosition { get; set; }
        public Point size { get; }
        public List<Tile> tiles { get; private set; }
        public float gravity { get; set; }
        public Rectangle GetRectangle => ChristianTools.Helpers.MyRectangle.CreateRectangle(centerPosition.ToPoint(), size.X, size.Y);
        private Rectangle GetRectangleUp(int steps) => ChristianTools.Helpers.MyRectangle.GetRectangleUp(MyRectangle.CreateRectangle(centerPosition.ToPoint(), size.X, size.Y), steps);
        private Rectangle GetRectangleDown(int steps) => ChristianTools.Helpers.MyRectangle.GetRectangleDown(MyRectangle.CreateRectangle(centerPosition.ToPoint(), size.X, size.Y), steps);
        private Rectangle GetRectangleLeft(int steps) => ChristianTools.Helpers.MyRectangle.GetRectangleLeft(MyRectangle.CreateRectangle(centerPosition.ToPoint(), size.X, size.Y), steps);
        private Rectangle GetRectangleRight(int steps) => ChristianTools.Helpers.MyRectangle.GetRectangleRight(MyRectangle.CreateRectangle(centerPosition.ToPoint(), size.X, size.Y), steps);

        public ClassicRigidbody(Vector2 centerPosition, Point size)
        {
            this.centerPosition = centerPosition;
            this.size = size;
        }

        public void Update()
        {
            // Get surrounding tiles
            Point pointInMap = new Point((int)centerPosition.X / 16, (int)centerPosition.Y / 16);
            Tile[,] surroundingElements = Other.GetSurroundingElements(ChristianGame.GetScene?.map?.mainTiles, pointInMap);
            this.tiles = ChristianTools.Helpers.Other.FlattenArray(surroundingElements).Where(x => x != null).ToList();


            this.centerPosition += force;
            this.centerPosition += new Vector2(0, gravity);
        }

        public void Move_X(float X)
        {
            //this.centerPosition += new Vector2(X, 0);


            if (X > 0) // Right
                MoveRight((uint)Math.Abs(X));
            else if (X < 0) // Left
                MoveLeft((uint)Math.Abs(X));
        }

        public void Move_Y(float Y)
        {
            //this.centerPosition += new Vector2(0, Y);
            if (Y < 0) // Up
                MoveUp((uint)Math.Abs(Y));
            else if (Y > 0) // Down
                MoveDown((uint)Math.Abs(Y));
        }

        public bool CanMoveUp(uint Y)
        {
            if (tiles == null)
                return true;

            return !tiles.Any(x => x.rectangle.Intersects(GetRectangleUp((int)Y)));
        }


        // Private because if public, will be confusing with Move_X() and Move_Y() -> Just, keep private
        private void MoveUp(uint steps)
        {
            if (CanMoveUp(steps))
            {
                centerPosition += new Vector2(0, -steps);
            }
            else
            {
                // clamp
                Tile tileUp = tiles.FirstOrDefault(x => x.rectangle.Intersects(GetRectangleUp((int)steps)));
                float dif = tileUp.rectangle.Bottom - (centerPosition.Y - (size.Y / 2));

                centerPosition += new Vector2(0, dif);
            }
        }

        // Private because if public, will be confusing with Move_X() and Move_Y() -> Just, keep private
        private void MoveDown(uint steps)
        {
            if (CanMoveDown(steps))
            {
                this.centerPosition += new Vector2(0, steps);
            }
            else
            {
                // clamp
                Tile tileDown = tiles.FirstOrDefault(x => x.rectangle.Intersects(GetRectangleDown((int)steps)));
                float dif = (centerPosition.Y + (size.Y / 2)) - tileDown.rectangle.Y;
                centerPosition += new Vector2(0, dif);
            }
        }

        // Private because if public, will be confusing with Move_X() and Move_Y() -> Just, keep private
        private void MoveRight(uint steps)
        {
            if (CanMoveRight(steps) == true)
            {
                this.centerPosition += new Vector2(steps, 0);
            }
            else
            {
                // clamp    
                Tile tileRight = tiles.FirstOrDefault(x => x.rectangle.Intersects(GetRectangleRight((int)steps)));
                float dif = (centerPosition.X + (size.X / 2)) - tileRight.rectangle.X;

                centerPosition += new Vector2(-dif, 0);
            }
        }

        // Private because if public, will be confusing with Move_X() and Move_Y() -> Just, keep private
        private void MoveLeft(uint steps)
        {
            if (CanMoveLeft(steps) == true)
            {
                centerPosition += new Vector2(-steps, 0);
            }
            else
            {
                // clamp    
                Tile tileLeft = tiles.FirstOrDefault(x => x.rectangle.Intersects(GetRectangleLeft((int)steps)));
                float dif = tileLeft.rectangle.Right - (centerPosition.X - (size.X / 2));

                centerPosition += new Vector2(-dif, 0);
            }
        }

        public bool CanMoveDown(uint Y)
        {
            if (tiles == null)
                return true;

            return !tiles.Any(x => x.rectangle.Intersects(GetRectangleDown((int)Y)));
        }

        public bool CanMoveRight(uint X)
        {
            if (tiles == null)
                return true;

            return !tiles.Any(x => x.rectangle.Intersects(GetRectangleRight((int)X)));
        }

        public bool CanMoveLeft(uint X)
        {
            if (tiles == null)
                return true;

            return !tiles.Any(x => x.rectangle.Intersects(GetRectangleLeft((int)X)));
        }
    }
} 