using System.Collections.Generic;
using System.Linq;
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

        public DxUpdateSystem dxUpdateSystem { get; }
        public DxDrawSystem dxDrawSystem { get; }

        public byte Al { get; set; }

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