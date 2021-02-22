using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace zAssets
{
    public class Prefab
    {
        Texture2D texture2D;
        Point position;

        public Rectangle rectangle { get => new Rectangle(x: position.X - (texture2D.Width / 2), y: position.Y - (texture2D.Height / 2), width: texture2D.Width, height: texture2D.Height); }
        public bool isActive;
        public string tag { get; private init; }

        public Prefab(Texture2D texture2D, Point position, bool isActive = true, string tag = "")
        {
            this.texture2D = texture2D;
            this.position = position;
            this.isActive = isActive;
            this.tag = tag;
        }

        public void Update(Point? position = null, bool? isActive= null)
        {
            if (position != null)
                this.position = new Point(position.Value.X, position.Value.Y);

            if (isActive != null)
                this.isActive = isActive.Value;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }
    }
}
