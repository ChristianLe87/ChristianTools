namespace ChristianTools.Components
{
    public class Rigidbody2 : IRigidbody
    {
        public Vector2 force { get; set; }
        public Vector2 centerPosition { get; set; }
        public Point size { get; }
        public List<Tile> tiles { get; }
        public float gravity { get; set; }
        public Rectangle GetRectangle { get; }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Move_X(float X)
        {
            throw new NotImplementedException();
        }

        public void Move_Y(float Y)
        {
            throw new NotImplementedException();
        }

        public bool CanMoveUp(uint Y)
        {
            throw new NotImplementedException();
        }

        public bool CanMoveDown(uint Y)
        {
            throw new NotImplementedException();
        }

        public bool CanMoveRight(uint X)
        {
            throw new NotImplementedException();
        }

        public bool CanMoveLeft(uint X)
        {
            throw new NotImplementedException();
        }
    }
}