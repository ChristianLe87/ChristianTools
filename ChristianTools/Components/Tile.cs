using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Components
{
    public class Tile : ITile
    {
        public Rigidbody rigidbody { get; }
        public Texture2D texture { get; }

        public string tag { get; }
        public bool isActive { get; set; }

        public DxTileInitializeSystem dxTileInitializeSystem { get; }
        public DxTileUpdateSystem dxTileUpdateSystem { get; private set; }
        public DxTileDrawSystem dxTileDrawSystem { get; }

        public Tile(Texture2D texture, Rectangle rectangle, bool isActive = true, string tag = "")
        {
            this.texture = texture;
            this.rigidbody = new Rigidbody(
                rectangle: rectangle
            );
            this.tag = tag;
            this.isActive = isActive;
        }
    }
}