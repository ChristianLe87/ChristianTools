namespace ChristianTools.Entities
{
    public class Bullet : IEntity
    {
        
        public IRigidbody rigidbody { get; set; }
        public Animation animation { get; }
        public bool isActive { get; set; }
        public string tag { get; }
        public Guid guid { get; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
        
        
        TimeSpan timeToDeactivate;

        public Bullet(Vector2 centerPosition, Vector2 direction, int steps = 3, uint secondsToDeactivate = 5)
        {
            this.rigidbody = new BulletRigidbody(centerPosition, new Point(16, 16));
            this.animation = new Animation();
            this.isActive = true;
            this.tag = "";
            this.guid = Guid.NewGuid();
            
            this.timeToDeactivate = new TimeSpan(0, 0, (int)secondsToDeactivate);

            double radAngle = Helpers.MyMath.GetAngleInRadians(centerPosition, direction);
            float x = (float)(steps * Math.Cos(radAngle));
            float y = (float)(steps * Math.Sin(radAngle));
            this.rigidbody.force = new Vector2(x, y);

            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => BulletUpdateSystem(inputState);
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => Systems.Draw.Entity.Draw(spriteBatch, this);
        }

        public void BulletUpdateSystem(InputState inputState)
        {
            // Implementation
            if (isActive == true)
            {
                TimeToDestroy();
                //CheckCollision();
                /*rigidbody.Update();

                if (rigidbody.CanMoveLeft(16) == false)
                {
                    int bla = 0;
                }
                */
            }

            // Helpers
            void TimeToDestroy()
            {
                if (timeToDeactivate.TotalMilliseconds != 0)
                {
                    TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, (int)((1f / ChristianGame.WK.FPS) * 1000));
                    timeToDeactivate = timeToDeactivate.Subtract(timeSpan);

                    if (timeToDeactivate.TotalMilliseconds <= 0)
                        isActive = false;
                }
            }

            void CheckCollision()
            {
                if (rigidbody.CanMoveUp(1) == false || rigidbody.CanMoveDown(1) == false || rigidbody.CanMoveRight(1) == false || rigidbody.CanMoveLeft(1))
                    isActive = false;
            }
        }
    }
}