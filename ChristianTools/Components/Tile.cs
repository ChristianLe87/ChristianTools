using Microsoft.Xna.Framework;

namespace ChristianTools.Components
{
    public class Tile
    {
        public Rectangle worldRectangle { get; private set; }
        public int image { get; private set; }
        public Tiled.LayerId layerId { get; private set; }

        public Tile(Rectangle worldRectangle, int image, Tiled.LayerId layerId)
        {
            this.worldRectangle = worldRectangle;
            this.image = image;
            this.layerId = layerId;
        }
    }
}