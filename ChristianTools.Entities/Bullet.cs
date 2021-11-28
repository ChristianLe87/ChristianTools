using System;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Entities
{
    public class Bullet : IEntity
    {
        Texture2D texture2D;
        TimeSpan autoDestroyTime;

        public Rigidbody rigidbody { get; }
        public bool isActive { get; private set; }
        public string tag { get; }
        public int health { get; }

        public Bullet(Texture2D texture2D, Vector2 centerPosition, Vector2 direction, int steps, TimeSpan autoDestroyTime = new TimeSpan())
        {
            this.texture2D = texture2D;
            this.autoDestroyTime = autoDestroyTime;
            this.isActive = true;

            double radAngle = ChristianTools.Tools.Tools.MyMath.GetAngleInRadians(
                Point1_Start: centerPosition,
                Point1_End: new Vector2(500, (int)centerPosition.Y),
                Point2_Start: centerPosition,
                Pount2_End: direction
            );

            float x = (float)(steps * Math.Cos(radAngle));
            float y = (float)(steps * Math.Sin(radAngle));

            this.rigidbody = new Rigidbody(centerPosition, texture2D.Width, texture2D.Height, force: new Vector2(x, y));
        }

        public void Update(InputState lastInputState = null, InputState inputState = null)
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
                if (autoDestroyTime.TotalMilliseconds != 0)
                {
                    TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, (int)((1f / (60/*WK.Default.FPS*/)) * 1000));
                    autoDestroyTime = autoDestroyTime.Subtract(timeSpan);

                    if (autoDestroyTime.TotalMilliseconds <= 0)
                        isActive = false;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isActive == true)
                spriteBatch.Draw(texture2D, rigidbody.rectangle, Color.White);
        }
    }
}