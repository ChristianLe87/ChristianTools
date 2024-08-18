namespace ChristianTools.Components
{
    public class BulletRigidbody : IRigidbody
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

        public BulletRigidbody(Vector2 centerPosition, Point size)
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
        }

        public void Move_X(float X)
        {
            this.centerPosition += new Vector2(X, 0);
        }

        public void Move_Y(float Y)
        {
            this.centerPosition += new Vector2(0, Y);
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
    }
}