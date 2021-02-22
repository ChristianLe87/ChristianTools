using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using zTools;

namespace zUI
{
    public class Line
    {
        Texture2D texture2D;
        Rectangle[] rectangles;

        Point start;
        Point end;
        int thickness;

        public Line(Point start, Point end, int thickness, Texture2D texture2D)
        {
            this.start = start;
            this.end = end;
            this.thickness = thickness;
            this.texture2D = texture2D;

            CreateLine();
        }

        void CreateLine()
        {
            int amountOn_X = Math.Abs(start.X - end.X) / thickness;
            int amountOn_Y = 0;
            rectangles = new Rectangle[amountOn_X + 1];

            for (int i = 0; i < rectangles.Length; i++)
            {
                Rectangle rectangle = new Rectangle();

                if(start.X - end.X < 0)
                    rectangle.X = (start.X + (i * thickness) - (thickness / 2));
                else
                    rectangle.X = (start.X - (i * thickness) - (thickness / 2));
                
                rectangle.Y = start.Y;
                rectangle.Width = thickness;
                rectangle.Height = thickness;

                rectangles[i] = rectangle;
            }
        }

        public void Update(Point? start = null, Point? end = null)
        {
            if (start != null)
                this.start = new Point(start.Value.X, start.Value.Y);

            if (end != null)
                this.end = new Point(end.Value.X, end.Value.Y);

            CreateLine();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var rectangle in rectangles)
            {
                spriteBatch.Draw(texture2D, rectangle, Color.White);
            }
        }
    }
}
