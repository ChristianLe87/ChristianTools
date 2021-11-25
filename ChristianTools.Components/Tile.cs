using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Components
{
    public class Tile
    {
        public Rigidbody rigidbody { get; }
        Texture2D texture;

        public string tag { get; }
        public bool isActive { get; set; }

        public delegate void DxOnUpdate();

        public Tile(Texture2D texture, Rectangle rectangle, int scaleFactor, string tag = "")
        {
            this.texture = texture;
            this.rigidbody = new Rigidbody(rectangle.Center, rectangle.Width, rectangle.Height, Vector2.Zero, scaleFactor);
            this.tag = tag;
            this.isActive = true;
        }

        public void Update(DxOnUpdate dxOnUpdate)
        {
            dxOnUpdate();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isActive == true)
                spriteBatch.Draw(texture, rigidbody.rectangle, Color.White);
        }
    }
}