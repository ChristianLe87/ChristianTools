using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace zWorldElements
{
    public class Slope
    {
        Texture2D texture2D;
        Point centerPoint;
        //Rectangle rectangle { get => new Rectangle(centerPoint.X - (texture2D.Width / 2), centerPoint.Y - (texture2D.Height / 2), texture2D.Width, texture2D.Height); }

        Rectangle[] rectangles;

        public Slope(Point centerPoint, Texture2D texture2D, SlopeFace slopeFace)
        {
            this.centerPoint = centerPoint;
            this.texture2D = texture2D;


            if (slopeFace == SlopeFace.Right)
            {
                Rectangle rectangle = new Rectangle(centerPoint.X - (centerPoint.X / 2), centerPoint.Y - (centerPoint.Y / 2), 16, 16);
                this.rectangles = new Rectangle[16];
                for (int i = 0; i < rectangles.Length; i++)
                {
                    Rectangle r = new Rectangle();
                    r.X = (i + centerPoint.X) - (centerPoint.X / 2);
                    r.Y = i;
                    r.Width = 1;
                    r.Height = 16 - i;

                    this.rectangles[i] = r;
                }
            }
            else if (slopeFace == SlopeFace.Left)
            {
                Rectangle rectangle = new Rectangle(centerPoint.X - (centerPoint.X / 2), centerPoint.Y - (centerPoint.Y / 2), 16, 16);
                this.rectangles = new Rectangle[16];
                for (int i = rectangles.Length - 1; i != 0; i--)
                {
                    Rectangle r = new Rectangle();
                    r.X = (i + centerPoint.X) - (centerPoint.X / 2);
                    r.Y = (centerPoint.Y - i) - (centerPoint.Y / 2);
                    r.Width = 1;
                    r.Height = i;

                    this.rectangles[i] = r;
                }
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


    public enum SlopeFace
    {
        Right,
        Left
    }
}
