namespace ChristianTools.Entities
{
    
    public class Bullet : IEntity
    {
        TimeSpan timeToDeactivate;

        public Rigidbody rigidbody { get; set; }
        public bool isActive { get; set; }
        public string tag { get; }
        public Guid guid { get; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }

        public Animation animation { get; }


        public Bullet(Vector2 centerPosition, Vector2 direction, int steps = 3, uint secondsToDeactivate = 5)
        {
            
            this.animation = new Animation();
            this.timeToDeactivate = new TimeSpan(0, 0, (int)secondsToDeactivate);
            this.isActive = true;

            double radAngle = Helpers.MyMath.GetAngleInRadians(centerPosition, direction);
            float x = (float)(steps * Math.Cos(radAngle));
            float y = (float)(steps * Math.Sin(radAngle));

            this.rigidbody = new Rigidbody(
                 ChristianTools.Helpers.MyRectangle.CreateRectangle(centerPosition.ToPoint(), 16,16),
                 force: new Vector2(steps,steps)
            );
            this.rigidbody.force = new Vector2(x, y); 

            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => BulletUpdateSystem(inputState);
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => Systems.Draw.Entity.Draw(spriteBatch, this);
 
        }

        public void BulletUpdateSystem(InputState inputState)
        {
            if (inputState.keyboard.IsKeyboardKeyDown(Keys.P) && isActive == true)
            {
                int bla = 0;
            }
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