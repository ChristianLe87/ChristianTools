using System;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Entities
{
    public class Bullet : IEntity
    {
        TimeSpan timeToDeactivate;
        int FPS;

        public Rigidbody rigidbody { get; }
        public bool isActive { get; set; }
        public string tag { get; }
        public int health { get; }

        public Animation animation { get; }
        public CharacterState characterState { get; set; }

        public DxUpdateSystem dxUpdateSystem { get; }
        public DxDrawSystem dxDrawSystem { get; }

        public Bullet(Texture2D texture2D, Vector2 centerPosition, Vector2 direction, int steps, TimeSpan timeToDeactivate = new TimeSpan(), int FPS = 60)
        {
            this.animation = new Animation(texture2D);
            this.timeToDeactivate = timeToDeactivate;
            this.isActive = true;
            this.FPS = FPS;

            double radAngle = Tools.Tools.MyMath.GetAngleInRadians(centerPosition, direction);
            float x = (float)(steps * Math.Cos(radAngle));
            float y = (float)(steps * Math.Sin(radAngle));

            this.rigidbody = new Rigidbody(
                centerPosition: centerPosition,
                entity: this,
                force: new Vector2(x, y)
            );

            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => BulletUpdateSystem();
        }

        public void BulletUpdateSystem()
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
                    TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, (int)((1f / FPS) * 1000));
                    timeToDeactivate = timeToDeactivate.Subtract(timeSpan);

                    if (timeToDeactivate.TotalMilliseconds <= 0)
                        isActive = false;
                }
            }
        }
    }
}