namespace Showroom
{
    public class Entity_Bullet : IEntity
    {
        TimeSpan timeToDeactivate;
        public IRigidbody rigidbody { get; set; }
        public Animation animation { get; }
        public bool isActive { get; set; }
        public string tag { get; }
        public Guid guid { get; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }

        public Entity_Bullet(Vector2 direction, uint secondsToDeactivate, uint steps)
        {
            this.rigidbody = new Rigidbody2(new Vector2(ChristianGame.WK.CanvasWidth / 2, ChristianGame.WK.CanvasHeight / 2), new Point(16, 16));
            this.animation = new Animation();
            this.isActive = true;
            this.tag = "";
            this.guid = Guid.NewGuid();

            this.timeToDeactivate = new TimeSpan(0, 0, (int)secondsToDeactivate);

            // Calculate force
            {
                double radAngle = ChristianTools.Helpers.MyMath.GetAngleInRadians(rigidbody.centerPosition, direction);
                float x = (float)(steps * Math.Cos(radAngle));
                float y = (float)(steps * Math.Sin(radAngle));
                this.rigidbody.force = new Vector2(x, y);
            }

            this.dxCustomUpdateSystem = (lastInputState, inputState) => Update(lastInputState, inputState);
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => ChristianTools.Systems.Draw.Entity.Draw(spriteBatch, this);
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            // Implementation
            if (isActive == true)
                TimeToDestroy();


            // Helpers
            void TimeToDestroy()
            {
                if (timeToDeactivate.TotalMilliseconds > 0)
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