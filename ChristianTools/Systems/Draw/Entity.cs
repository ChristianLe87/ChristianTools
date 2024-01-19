using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Systems.Draw
{
    public class Entity
    {
        public static void DrawSystem(SpriteBatch spriteBatch, IEntity entity)
        {
            if (entity.isActive != true)
                return;

            if (false)
            {
                // old
                spriteBatch.Draw(
                    texture: ChristianGame.atlasTexture2D, // atlas texture
                    destinationRectangle: entity.rigidbody.rectangle,
                    sourceRectangle: entity.animation.imageFromAtlas,
                    color: Color.White,
                    rotation: (float)ChristianTools.Helpers.MyMath.DegreeToRadian(entity.rigidbody.rotationDegree), // always value radians
                    origin: new Vector2(entity.rigidbody.rectangle.Width / 2, entity.rigidbody.rectangle.Height / 2),
                    effects: SpriteEffects.None,
                    layerDepth: 1 / 10f
                );
            }
            else
            {
                // new
                spriteBatch.Draw(
                    texture: ChristianGame.atlasTexture2D, // atlas texture 
                    position: entity.rigidbody.rectangle.Center.ToVector2(), // new Vector2(200,200), //The drawing location on screen.
                    sourceRectangle: new Rectangle(32, 16, 16, 16), //animation.imageFromAtlas // "El pedazo que quiero sacar del atlasTexture" An optional region on the texture which will be rendered. If null - draws full texture.
                    color: Color.White,
                    rotation: (float)ChristianTools.Helpers.MyMath.DegreeToRadian(entity.rigidbody.rotationDegree), // A rotation of this sprite (always value radians)
                    origin: new Vector2(entity.rigidbody.rectangle.Width / 2, entity.rigidbody.rectangle.Height / 2), // Center of the rotation. 0,0 by default.
                    scale: new Vector2(1, 1), //A scaling of this sprite. 
                    effects: SpriteEffects.None, //Modificators for drawing. Can be combined.
                    layerDepth: 1 / 10f
                );
            }
        }
    }
}