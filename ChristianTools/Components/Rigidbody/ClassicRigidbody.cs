namespace ChristianTools.Components
{
    public class ClassicRigidbody : IRigidbody
    {
        public Vector2 force { get; set; }
        public Rectangle GetRectangle => ChristianTools.Helpers.MyRectangle.CreateRectangle(centerPosition.ToPoint(), size.X, size.Y);
        private Rectangle GetRectangleUp(int steps) => ChristianTools.Helpers.MyRectangle.GetRectangleUp(MyRectangle.CreateRectangle(centerPosition.ToPoint(), size.X, size.Y), steps);
        private Rectangle GetRectangleDown(int steps) => ChristianTools.Helpers.MyRectangle.GetRectangleDown(MyRectangle.CreateRectangle(centerPosition.ToPoint(), size.X, size.Y), steps);
        private Rectangle GetRectangleLeft(int steps) => ChristianTools.Helpers.MyRectangle.GetRectangleLeft(MyRectangle.CreateRectangle(centerPosition.ToPoint(), size.X, size.Y), steps);
        private Rectangle GetRectangleRight(int steps) => ChristianTools.Helpers.MyRectangle.GetRectangleRight(MyRectangle.CreateRectangle(centerPosition.ToPoint(), size.X, size.Y), steps);
        public List<Tile> tiles { get; private set; }

        public float gravity { get; set; }

        public Vector2 centerPosition { get; set; }
        public Point size { get; }


        public ClassicRigidbody(Rectangle rectangle, Vector2 force = new Vector2())
        {
            this.force = force;
            this.centerPosition = rectangle.Center.ToVector2();
            this.size = rectangle.Size;
            this.gravity = 0;
        }

        public void Update()
        {
            Point pointInMap = new Point((int)centerPosition.X / 16, (int)centerPosition.Y / 16);
            Tile[,] surroundingElements = Other.GetSurroundingElements(ChristianGame.GetScene?.map?.mainTiles, pointInMap);
            this.tiles = ChristianTools.Helpers.Other.FlattenArray(surroundingElements).Where(x => x != null).ToList();

            Move_Y((int)force.Y);
            Move_X((int)force.X);

            MoveGravity();
        }



        /// <summary>
        /// positive move right, negative move left
        /// </summary>
        /// <param name="X"></param>
        public void Move_X(float X)
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
        public void Move_Y(float Y)
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
                centerPosition = new Vector2(centerPosition.X, centerPosition.Y - steps);
            }
            else
            {
                // clamp
                Tile tileUp = tiles.FirstOrDefault(x => x.rectangle.Intersects(GetRectangleUp((int)steps)));
                float dif = tileUp.rectangle.Bottom - (centerPosition.Y - (size.Y / 2));

                centerPosition = new Vector2(centerPosition.X, centerPosition.Y + dif);
            }
        }

        // Private because if public, will be confusing with Move_X() and Move_Y() -> Just, keep private
        public void MoveDown(uint steps)
        {
            if (CanMoveDown(steps))
            {
                this.centerPosition = new Vector2(centerPosition.X, centerPosition.Y + steps);
            }
            else
            {
                // clamp
                Tile tileDown = tiles.FirstOrDefault(x => x.rectangle.Intersects(GetRectangleDown((int)steps)));
                float dif = (centerPosition.Y + (size.Y / 2)) - tileDown.rectangle.Y;
                centerPosition = new Vector2(centerPosition.X, centerPosition.Y + dif);
            }
        }

        // Private because if public, will be confusing with Move_X() and Move_Y() -> Just, keep private
        public void MoveRight(uint steps)
        {
            if (CanMoveRight(steps) == true)
            {
                this.centerPosition = new Vector2(centerPosition.X + steps, centerPosition.Y);
            }
            else
            {
                // clamp    
                Tile tileRight = tiles.FirstOrDefault(x => x.rectangle.Intersects(GetRectangleRight((int)steps)));
                float dif = (centerPosition.X + (size.X / 2)) - tileRight.rectangle.X;

                centerPosition = new Vector2(centerPosition.X - dif, centerPosition.Y);
            }
        }

        // Private because if public, will be confusing with Move_X() and Move_Y() -> Just, keep private
        public void MoveLeft(uint steps)
        {
            if (CanMoveLeft(steps) == true)
            {
                centerPosition = new Vector2(centerPosition.X - steps, centerPosition.Y);
            }
            else
            {
                // clamp    
                Tile tileLeft = tiles.FirstOrDefault(x => x.rectangle.Intersects(GetRectangleLeft((int)steps)));
                int dif = tileLeft.rectangle.Right - size.X;

                centerPosition = new Vector2(centerPosition.X - dif, centerPosition.Y);
            }
        }

        public bool CanMoveUp(uint Y)
        {
            if (tiles == null)
                return true;

            return !tiles.Any(x => x.rectangle.Intersects(GetRectangleUp((int)Y)));
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

        private void MoveGravity()
        {
            MoveDown((uint)gravity);
        }
    }
}