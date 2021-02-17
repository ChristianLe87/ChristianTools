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
            if (Math.Abs(start.X - end.X) > -1 && Math.Abs(start.X - end.X) < 1)
            {
                var bla = 0;
            }

            int ammountOfRectanglesNeeded = Math.Abs((end.X - start.X) / thickness);
            float distanceBetweenStartAndEnd = Vector2.Distance(start.ToVector2(), end.ToVector2());
            float heightOfEachRectangle = distanceBetweenStartAndEnd / ammountOfRectanglesNeeded;
            this.rectangles = new Rectangle[ammountOfRectanglesNeeded + 2];

            float m = Tools.MyMath.M(start.ToVector2(), end.ToVector2());
            float b = Tools.MyMath.B(start.X, start.Y, m);

            for (int i = 0; i <= rectangles.Length; i++)
            {
                // check directoin
                int x;
                if (end.X - start.X > 0)
                    x = start.X + (thickness * i);
                else
                    x = end.X + (thickness * i);

                // y = mx +b
                int y = (int)((m * x) + b);

                if (i == 0)
                {
                    rectangles[i] = new Rectangle(start.X - (thickness / 2), start.Y - (thickness / 2), thickness, thickness);
                }
                else if (i == rectangles.Length)
                {
                    rectangles[i - 1] = new Rectangle(end.X - (thickness / 2), end.Y - (thickness / 2), thickness, thickness);
                }
                else
                {
                    rectangles[i] = new Rectangle(x - (thickness / 2), (int)(y - (heightOfEachRectangle / 2)), thickness, (int)(heightOfEachRectangle < thickness ? thickness : heightOfEachRectangle));
                }
            }
        }

        public void Update(Point? start = null, Point? end = null)
        {
            if (start != null) this.start = new Point(start.Value.X, start.Value.Y);
            if (end != null) this.end = new Point(end.Value.X, end.Value.Y);

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
