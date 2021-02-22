﻿using System;
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
            int amountOn_Y = Math.Abs(start.Y - end.Y) / thickness;
            rectangles = new Rectangle[amountOn_X + 1];

            float m = Tools.MyMath.M(start.ToVector2(), end.ToVector2());
            float b = Tools.MyMath.B(start.X, start.Y, m);

            // When bigger on X
            if (amountOn_X > amountOn_Y)
            {
                for (int i = 0; i < rectangles.Length; i++)
                {
                    Rectangle rectangle = new Rectangle();


                    // Calculate X
                    if (start.X - end.X < 0)
                        rectangle.X = (start.X + (i * thickness) - (thickness / 2));
                    else
                        rectangle.X = (start.X - (i * thickness) - (thickness / 2));


                    // Calculate Y
                    rectangle.Y = (int)((m * rectangle.X) + b); // y = mx +b


                    // Width and Height
                    rectangle.Width = thickness;
                    rectangle.Height = thickness;


                    // Apply
                    rectangles[i] = rectangle;
                }
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