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
        public bool isActive { get; private set; }
        public string tag { get; }
        public int health { get; }

        public Animation animation { get; }
        public Animation.CharacterState characterState { get; }

        public Bullet(Texture2D texture2D, Vector2 centerPosition, Vector2 direction, int steps, TimeSpan timeToDeactivate = new TimeSpan(), int FPS = 60)
        {
            this.animation = new Animation(texture2D);
            this.timeToDeactivate = timeToDeactivate;
            this.isActive = true;
            this.FPS = FPS;

            double radAngle = ChristianTools.Tools.Tools.MyMath.GetAngleInRadians(
                Point1_Start: centerPosition,
                Point1_End: new Vector2(500, (int)centerPosition.Y),
                Point2_Start: centerPosition,
                Point2_End: direction
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
                if (timeToDeactivate.TotalMilliseconds != 0)
                {
                    TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, (int)((1f / FPS) * 1000));
                    timeToDeactivate = timeToDeactivate.Subtract(timeSpan);

                    if (timeToDeactivate.TotalMilliseconds <= 0)
                        isActive = false;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isActive == true)
                spriteBatch.Draw(animation.GetTexture(characterState), rigidbody.rectangle, Color.White);
        }
    }
}