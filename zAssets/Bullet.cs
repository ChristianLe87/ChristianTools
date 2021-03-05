using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Showroom_dotNet5;
using zTools;

namespace zAssets
{
    public class Bullet
    {
        Texture2D texture2D;
        Point position;
        TimeSpan autoDestroyTime;
        public bool isActive;
        double x;
        double y;

        public Rectangle rectangle { get => new Rectangle().Create(position, texture2D); }

        public Bullet(Texture2D texture2D, Point start, Point direction, int steps, TimeSpan autoDestroyTime = new TimeSpan())
        {
            this.texture2D = texture2D;
            this.position = start;
            this.autoDestroyTime = autoDestroyTime;
            this.isActive = true;

            double radAngle = Tools.MyMath.GetAngleInRadians(
                                                        Point1_Start: start,
                                                        Point_1_End: new Point(WK.Default.Window.Pixels.Width, (int)start.Y),
                                                        Point2_Start: start,
                                                        Pount2_End: direction
            );

            this.x = steps * Math.Cos(radAngle);
            this.y = steps * Math.Sin(radAngle);
        }

        public void Update()
        {
            // Implementation
            {
                if (isActive == false) return;

                Move();
                TimeToDestroy();
            }

            // Helpers
            void Move()
            {
                position.X += (int)x;
                position.Y += (int)y;
            }

            void TimeToDestroy()
            {
                if (autoDestroyTime.TotalMilliseconds != 0)
                {
                    TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, (int)((1f / (WK.Default.FPS)) * 1000));
                    autoDestroyTime = autoDestroyTime.Subtract(timeSpan);

                    if (autoDestroyTime.TotalMilliseconds <= 0) isActive = false;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isActive == false) return;
            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }
    }
}
