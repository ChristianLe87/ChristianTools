using ChristianTools.Components.Tiled;
using Microsoft.Xna.Framework;

namespace ChristianTools.Components
{
    public class Tile
    {
        public Rectangle worldRectangle { get; private set; }
        public Rectangle imageFromAtlas { get; private set; }
        public int layerId { get; private set; } 

        public Tile(Rectangle worldRectangle, Rectangle imageFromAtlas, int layerId)
        {
            this.worldRectangle = worldRectangle;
            this.layerId = layerId;
            this.imageFromAtlas = imageFromAtlas;
        }
    }
}