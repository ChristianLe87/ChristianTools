using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Showroom_dotNet5
{
    public class Scene_Lines_Points_Mesh : IScene
    {

        Line line;

        public Scene_Lines_Points_Mesh()
        {
            Initialize();
        }

        public void Initialize()
        {
            line = new Line(new Point(WK.Default.Width / 2, WK.Default.Height / 2), new Point(0, 0), 5, Color.Red);
        }

        public void Update()
        {

            MouseState mouseState = Mouse.GetState();
            if(mouseState.LeftButton == ButtonState.Pressed)
            {
                line.Update(end: new Point(mouseState.X, mouseState.Y));
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            line.Draw(spriteBatch);
        }
    }

    public class Line
    {
        Texture2D texture2D;
        Rectangle[] rectangles;

        Point start;
        Point end;
        int thickness;
        Color color;

        public Line(Point start, Point end, int thickness, Color color)
        {
            this.start = start;
            this.end = end;
            this.thickness = thickness;
            this.color = color;

            CreateLine();
        }

        void CreateLine()
        {
            int ammountOfRectanglesNeeded = (end.X - start.X) / thickness;
            this.rectangles = new Rectangle[Math.Abs(ammountOfRectanglesNeeded)];
            this.texture2D = zTools.Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, color);

            float m = zTools.Tools.MyMath.M(start.ToVector2(), end.ToVector2());
            float b = zTools.Tools.MyMath.B(start.X, start.Y, m);

            for (int i = 0; i < rectangles.Length; i++)
            {
                // y = mx +b
                var x = start.X + (thickness * i);
                var y = (m * x) + b;

                rectangles[i] = new Rectangle(x, (int)y, thickness, thickness);
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