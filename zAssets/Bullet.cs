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
        Vector2 position;
        Dir dir;
        float m;
        float b;
        float timeCount;
        int steps;
        int autoDestroyTime;

        public int Health;
        public bool isActive;
        public Rectangle rectangle { get => new Rectangle((int)position.X - (texture2D.Width / 2), (int)position.Y - (texture2D.Height / 2), texture2D.Width, texture2D.Height); }

        public Bullet(Texture2D texture2D, Vector2 start, Vector2 direction, int steps, TimeSpan autoDestroyTime = new TimeSpan())
        {
            this.texture2D = texture2D;
            this.position = start;
            this.m = Tools.MyMath.M(start, direction);
            this.b = Tools.MyMath.B(position.X, position.Y, m);
            this.timeCount = 0f;
            this.steps = steps;
            this.autoDestroyTime = (int)autoDestroyTime.TotalSeconds;

            // is inclined
            if (m != 0)
            {
                // Go left
                if (direction.X - position.X < 0)
                {
                    // go up
                    if (direction.Y - position.Y < 0)
                    {
                        dir = Dir.UpLeft;
                    }
                    // go down
                    else if (direction.Y - position.Y > 0)
                    {
                        dir = Dir.DownLeft;
                    }
                }

                // go right
                else if (direction.X - position.X > 0)
                {
                    // go up
                    if (direction.Y - position.Y < 0)
                    {
                        dir = Dir.UpRight;
                    }
                    // go down
                    else if (direction.Y - position.Y > 0)
                    {
                        dir = Dir.DownRight;
                    }
                }
            }

            // is horizontal or vertical
            else if (m == 0)
            {
                // go up
                if (direction.X == position.X && direction.Y - position.Y < 0)
                {
                    dir = Dir.Up;
                }
                // go down
                else if (direction.X == position.X && direction.Y - position.Y > 0)
                {
                    dir = Dir.Down;
                }
                // go right
                else if (direction.Y == position.Y && direction.X - position.X > 0)
                {
                    dir = Dir.Right;
                }
                // go left
                else if (direction.Y == position.Y && direction.X - position.X < 0)
                {
                    dir = Dir.Left;
                }
            }

            this.isActive = true;
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
            void TimeToDestroy()
            {
                if (autoDestroyTime != 0)
                {
                    timeCount += 1f / WK.Default.FPS;

                    if (timeCount > autoDestroyTime) isActive = false;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isActive == false) return;

            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }

        private void Move()
        {
            switch (dir)
            {
                case Dir.Up:
                    position.Y -= steps;
                    break;
                case Dir.Down:
                    position.Y += steps;
                    break;
                case Dir.Right:
                    position.X += steps;
                    break;
                case Dir.Left:
                    position.X -= steps;
                    break;
                case Dir.UpLeft:
                    position.X -= steps;
                    position.Y = (m * position.X) + b;
                    break;
                case Dir.DownLeft:
                    position.X -= steps;
                    position.Y = (m * position.X) + b;
                    break;
                case Dir.UpRight:
                    position.X += steps;
                    position.Y = (m * position.X) + b;
                    break;
                case Dir.DownRight:
                    position.X += steps;
                    position.Y = (m * position.X) + b;
                    break;
            }
        }

        enum Dir
        {
            Up,
            Down,
            Right,
            Left,
            UpLeft,
            DownLeft,
            UpRight,
            DownRight
        }
    }
}
