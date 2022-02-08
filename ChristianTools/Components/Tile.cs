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

        public DxTileUpdateSystem dxTileUpdateSystem { get; private set; }
        public DxTileDrawSystem dxTileDrawSystem { get; }

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

        public Color GetShadow(List<Light> lights)
        {
            if (lights == null)
                return Shadow.Shadow_0;


            int nearDistance = lights.Select(x => (int)Vector2.Distance(x.centerPosition.ToVector2(), rigidbody.centerPosition)).Min();

            int AssetSize_x_ScaleFactor = ChristianGame.Default.AssetSize * ChristianGame.Default.ScaleFactor;


            if (nearDistance > 6 * AssetSize_x_ScaleFactor)
            {
                return Shadow.Shadow_100;
            }
            else if (nearDistance > 5 * AssetSize_x_ScaleFactor)
            {
                return Shadow.Shadow_75;
            }
            else if (nearDistance > 4 * AssetSize_x_ScaleFactor)
            {
                return Shadow.Shadow_50;
            }
            else if (nearDistance > 3 * AssetSize_x_ScaleFactor)
            {
                return Shadow.Shadow_25;
            }
            else if (nearDistance > 2 * AssetSize_x_ScaleFactor)
            {
                return Shadow.Shadow_10;
            }
            else
            {
                return Shadow.Shadow_0;
            }
        }
    }
}