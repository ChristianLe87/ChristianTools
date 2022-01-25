using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.APF
{
    /*public class Slope : IWorldElement
    {
        Texture2D texture2D;
        Vector2 centerPoint;
        public string tag { get; }
        public Rectangle rectangle { get => new Rectangle(); }
        Rectangle[] rectangles;

        public Slope(Rectangle rectangle, Texture2D texture2D, SlopeOrientation slopeFace, string tag)
        {
            this.texture2D = texture2D;
            this.centerPoint = rectangle.Center.ToVector2();
            this.rectangles = new Rectangle[rectangle.Width];
            this.tag = tag;

            float ratio = (float)rectangle.Height / (float)rectangle.Width;
            switch (slopeFace)
            {
                case SlopeOrientation.Right:
                    for (int i = 0; i < rectangles.Length; i++)
                    {
                        Rectangle r = Tools.GetRectangle.Rectangle(
                            centerPosition: new Vector2(rectangle.X + i, (int)(rectangle.Y + (i * ratio))),
                            Width: 1,
                            Height: (int)(rectangle.Height - (i * ratio))
                        );

                        this.rectangles[i] = r;
                    }
                    break;
                case SlopeOrientation.Left:
                    for (int i = 0; i < rectangles.Length; i++)
                    {
                        Rectangle r = Tools.GetRectangle.Rectangle(
                            centerPosition: new Vector2(rectangle.X + i, (int)(rectangle.Width - (i * ratio)) + rectangle.Y),
                            Width: 1,
                            Height: (int)(i * ratio)
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
    }*/
}
