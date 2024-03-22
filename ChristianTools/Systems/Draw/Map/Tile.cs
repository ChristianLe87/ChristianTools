using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Systems.Draw.Map
{
    public class Tile
    {
        public static void Draw(SpriteBatch spriteBatch, Components.Tile tile)
        {
            if (tile != null)
            {
                spriteBatch.Draw(
                    texture: ChristianGame.atlasEntities, // atlas texture 
                    position: tile.worldRectangle.Center.ToVector2(), //The drawing location on screen.
                    sourceRectangle: tile.imageFromAtlas, // "El pedazo que quiero sacar del atlasTexture" An optional region on the texture which will be rendered. If null - draws full texture.
                    color: Color.White,
                    rotation: (float)ChristianTools.Helpers.MyMath.DegreeToRadian(0), // A rotation of this sprite (always value radians)
                    origin: new Vector2(tile.imageFromAtlas.Width / 2, tile.imageFromAtlas.Height / 2), // Center of the rotation. 0,0 by default.
                    scale: new Vector2(1, 1), //A scaling of this sprite. 
                    effects: SpriteEffects.None, //Modificators for drawing. Can be combined.
                    layerDepth: (int)tile.layerId / 10f // 1f//1 / 10f
                );
            }
        }
    }
}