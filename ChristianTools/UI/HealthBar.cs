using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.UI
{
    public class HealthBar : IUI
    {
        Texture2D topTexture;
        Texture2D backTexture;
        Direction direction;
        public uint value { get; set; }
        public uint maxVal { get; }
        public uint reduceValue { get; }

        public Rectangle rectangle { get; }
        public bool isActive { get; set; }
        public string tag => throw new System.NotImplementedException();

        public DxUpdateSystem dxUpdateSystem { get; }
        public DxDrawSystem dxDrawSystem { get; }

        public Texture2D texture { get; }

        public HealthBar(Texture2D topTexture, Texture2D backTexture, Rectangle rectangle, Direction direction, uint maxVal = 100, uint reduceValue = 5, uint startValue = 80)
        {
            this.topTexture = topTexture;
            this.backTexture = backTexture;
            this.rectangle = rectangle;
            this.direction = direction;
            this.value = startValue;
            this.maxVal = maxVal;
            this.reduceValue = reduceValue;

            this.dxDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
        }

        private void DrawSystem(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backTexture, rectangle, Color.White);
            spriteBatch.Draw(topTexture, GetTopRectangle(), Color.White);
        }

        private Rectangle GetTopRectangle()
        {
            int proportionWidth = (int)(((float)rectangle.Width / (float)maxVal) * (float)value);
            int proportionHeight = (int)(((float)rectangle.Height / (float)maxVal) * (float)value);

            return direction switch
            {
                Direction.Right => new Rectangle(rectangle.X, rectangle.Y, proportionWidth, rectangle.Height),
                Direction.Left => new Rectangle(rectangle.X + rectangle.Width - proportionWidth, rectangle.Y, proportionWidth, rectangle.Height),
                Direction.Up => new Rectangle(rectangle.X, rectangle.Y + rectangle.Height - proportionHeight, rectangle.Width, proportionHeight),
                Direction.Down => new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, proportionHeight),
                _ => new Rectangle()
            };
        }

        public void Increase()
        {
            this.value += reduceValue;
        }

        public void Reduce()
        {
            this.value -= reduceValue;
        }

        public enum Direction
        {
            Right,
            Left,
            Up,
            Down
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}