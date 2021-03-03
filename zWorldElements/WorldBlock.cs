using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using zTools;

namespace zWorldElements
{
    public class WorldBlock : IWorldElement
    {
        Texture2D texture2D;
        Point centerPoint;
        public Rectangle rectangle { get => new Rectangle().Create(centerPoint, texture2D); }

        public WorldBlock(Point centerPoint, Texture2D texture2D)
        {
            this.texture2D = texture2D;
            this.centerPoint = centerPoint;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }
    }
}
