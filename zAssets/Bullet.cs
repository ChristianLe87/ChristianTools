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
        float m;
        float timeCount;

        public int Health;
        public bool isActive;
        public Rectangle rectangle { get => new Rectangle((int)position.X - (texture2D.Width / 2), (int)position.Y - (texture2D.Height / 2), texture2D.Width, texture2D.Height); }

        public Bullet(Vector2 start, Vector2 direction)
        {
            this.texture2D = Tools.Texture.CreateCircleTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Black, 10);
            this.position = start;
            this.m = Tools.MyMath.M(start, direction);
            this.timeCount = 0f;
            this.isActive = true;
        }

        public void Update()
        {
            // Implementation
            {
                position = Move();
                TimeToDestroy();
            }

            // Helpers
            void TimeToDestroy()
            {
                timeCount += 1f / WK.Default.FPS;

                int waitTime = 2;
                if (timeCount > waitTime) isActive = false;
            }

            Vector2 Move()
            {
                position.Y = m * position.X;
                position.X++;

                return position;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }
    }
}
