using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace zWorldElements
{
    public class Slope
    {
        Texture2D texture2D;
        Rectangle[] rectangles;

        public Slope(Rectangle rectangle, Texture2D texture2D, SlopeOrientation slopeFace)
        {
            this.texture2D = texture2D;
            this.rectangles = new Rectangle[rectangle.Width];

            switch (slopeFace)
            {
                case SlopeOrientation.Right:
                    for (int i = 0; i < rectangles.Length; i++)
                    {
                        Rectangle r = new Rectangle();
                        r.X = rectangle.X + i;
                        r.Y = rectangle.Y + i;
                        r.Width = 1;
                        r.Height = rectangle.Height - i;

                        this.rectangles[i] = r;
                    }
                    break;
                case SlopeOrientation.Left:
                    for (int i = 0; i < rectangles.Length; i++)
                    {
                        Rectangle r = new Rectangle();
                        r.X = rectangle.X + i;
                        r.Y = (rectangle.Width - i) + rectangle.Y;
                        r.Width = 1;
                        r.Height = i;

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
