using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace zWorldElements
{
    public class Ladder : IWorldElement
    {
        Texture2D texture2D;
        Point centerPoint;
        Rectangle rectangle { get => new Rectangle(centerPoint.X - (texture2D.Width / 2), centerPoint.Y - (texture2D.Height / 2), texture2D.Width, texture2D.Height); }

        public Ladder(Point centerPoint, Texture2D texture2D)
        {
            this.texture2D = texture2D;
            this.centerPoint = centerPoint;
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }
    }
}
