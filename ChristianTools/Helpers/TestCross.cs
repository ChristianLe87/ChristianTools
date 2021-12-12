using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Helpers
{
    public class TestCross
    {
        Rectangle ver;
        Rectangle hor;

        Texture2D pixelTexture2D;
        Vector2 center;

        public TestCross(Vector2 center, Texture2D pixelTexture2D)
        {
            this.center = center;

            this.ver = Tools.Tools.GetRectangle.Rectangle(center, 3, 100);
            this.hor = Tools.Tools.GetRectangle.Rectangle(center, 100, 3);

            this.pixelTexture2D = pixelTexture2D;
        }

        public void Update(Vector2 newCenter)
        {
            this.center = newCenter;
            this.ver = Tools.Tools.GetRectangle.Rectangle(center, 3, 100);
            this.hor = Tools.Tools.GetRectangle.Rectangle(center, 100, 3);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(pixelTexture2D, ver, Color.White);
            spriteBatch.Draw(pixelTexture2D, hor, Color.White);
        }
    }
}