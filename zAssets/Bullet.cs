using System;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Showroom_dotNet5;

namespace zAssets
{
    public class Bullet : IEntity
    {
        Texture2D texture2D;
        TimeSpan autoDestroyTime;
        double x;
        double y;


        public Rigidbody rigidbody { get; }
        public bool isActive { get; private set; }
        public string tag { get; }
        public int health { get; }

        public Bullet(Texture2D texture2D, Vector2 centerPosition, Vector2 direction, int steps, TimeSpan autoDestroyTime = new TimeSpan())
        {
            this.texture2D = texture2D;
            this.rigidbody = new Rigidbody(centerPosition, texture2D.Width, texture2D.Height);
            this.autoDestroyTime = autoDestroyTime;
            this.isActive = true;

            double radAngle = Tools.MyMath.GetAngleInRadians(
                                                        Point1_Start: centerPosition,
                                                        Point1_End: new Vector2(WK.Default.Window.Pixels.Width, (int)centerPosition.Y),
                                                        Point2_Start: centerPosition,
                                                        Pount2_End: direction
            );

            this.x = steps * Math.Cos(radAngle);
            this.y = steps * Math.Sin(radAngle);
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            // Implementation
            {
                if (isActive == false)
                    return;

                Move();
                TimeToDestroy();
            }

            // Helpers
            void Move()
            {
                rigidbody.Move_X((float)x);
                rigidbody.Move_Y((float)y);
            }

            void TimeToDestroy()
            {
                if (autoDestroyTime.TotalMilliseconds != 0)
                {
                    TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, (int)((1f / (WK.Default.FPS)) * 1000));
                    autoDestroyTime = autoDestroyTime.Subtract(timeSpan);

                    if (autoDestroyTime.TotalMilliseconds <= 0)
                        isActive = false;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isActive == false)
                return;

            spriteBatch.Draw(texture2D, rigidbody.rectangle, Color.White);
        }
    }
}