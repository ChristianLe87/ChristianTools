using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Systems.Draw.Map
{
    public class MyBlaTile
    {
        public static void DrawSystem(SpriteBatch spriteBatch, ChristianTools.Components.Tile tile)
        {
            spriteBatch.Draw(
                texture: ChristianGame.atlasEntities, // atlas texture 
                position: tile.worldRectangle.Center.ToVector2(), // new Vector2(blaEntity.rigidbodyRectangle.X, blaEntity.rigidbodyRectangle.Y), // entity.rigidbody.rectangle.Center.ToVector2(), // new Vector2(200,200), //The drawing location on screen.
                sourceRectangle: tile.imageFromAtlas, //animation.imageFromAtlas // "El pedazo que quiero sacar del atlasTexture" An optional region on the texture which will be rendered. If null - draws full texture.
                color: Color.White,
                rotation: (float)ChristianTools.Helpers.MyMath.DegreeToRadian( /*blaEntity.rigidbodyRectangle?.rotationDegree?? */0), // A rotation of this sprite (always value radians)
                origin: new Vector2(tile.worldRectangle.Width / 2, tile.worldRectangle.Height / 2), // Center of the rotation. 0,0 by default.
                scale: new Vector2(1, 1), //A scaling of this sprite. 
                effects: SpriteEffects.None, //Modificators for drawing. Can be combined.
                layerDepth: 1f //1 / 10f
            );
        }

    }
}