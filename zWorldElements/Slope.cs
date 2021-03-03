using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using zTools;

namespace zWorldElements
{
    public class Slope : IWorldElement
    {
        Texture2D texture2D;
        Point centerPoint;
        public Rectangle rectangle { get => new Rectangle(); }
        Rectangle[] rectangles;

        public Slope(Rectangle rectangle, Texture2D texture2D, SlopeOrientation slopeFace)
        {
            this.texture2D = texture2D;
            this.centerPoint = rectangle.Center;
            this.rectangles = new Rectangle[rectangle.Width];

            float ratio = (float)rectangle.Height / (float)rectangle.Width;
            switch (slopeFace)
            {
                case SlopeOrientation.Right:
                    for (int i = 0; i < rectangles.Length; i++)
                    {
                        Rectangle r = new Rectangle().Create(
                            rectangle.X + i,
                            rectangle.Y + (i * ratio),
                            1,
                            rectangle.Height - (i * ratio)
                        );

                        this.rectangles[i] = r;
                    }
                    break;
                case SlopeOrientation.Left:
                    for (int i = 0; i < rectangles.Length; i++)
                    {
                        Rectangle r = new Rectangle().Create(
                            rectangle.X + i,
                            (rectangle.Width - (i * ratio)) + rectangle.Y,
                            1,
                            (i * ratio)
                        );

                        this.rectangles[i] = r;
                    }
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var rectangle in rectangles)
            {
                spriteBatch.Draw(texture2D, rectangle, Color.White);
            }
        }
    }

    public enum SlopeOrientation
    {
        Right,
        Left
    }
}
