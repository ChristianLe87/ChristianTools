namespace ChristianTools.Entities
{
    public class Bullet : BaseEntity
    {
        TimeSpan timeToDeactivate;

        public Bullet(Vector2 centerPosition, Vector2 direction, int steps = 3, uint secondsToDeactivate = 5) : base(ChristianTools.Helpers.MyRectangle.CreateRectangle(centerPosition.ToPoint(), 16, 16))
        {
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
                rigidbody.Update();
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
        }
    }
}