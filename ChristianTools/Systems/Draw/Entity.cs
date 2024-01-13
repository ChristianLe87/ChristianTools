using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Systems
{
    public partial class Draw
    {
        public static void Entity(SpriteBatch spriteBatch, IScene scene, IEntity entity)
        {
            if (entity.isActive != true)
                return;

            if (entity.dxDrawSystem != null)
            {
                entity.dxDrawSystem(spriteBatch, scene);
            }
            else
            {
                //spriteBatch.Draw(ChristianGame.atlasTexture2D, entity.rigidbody.rectangle.Center.ToVector2(), Color.White);

                spriteBatch.Draw(
                    texture: ChristianGame.atlasTexture2D,
                    destinationRectangle: entity.rigidbody.rectangle,
                    sourceRectangle: entity.animation.imageFromAtlas,
                    color: Color.White,
                    rotation: (float)ChristianTools.Helpers.MyMath.DegreeToRadian(entity.rigidbody.rotationDegree),
                    origin: new Vector2(entity.rigidbody.rectangle.Width / 2, entity.rigidbody.rectangle.Height / 2),
                    effects: SpriteEffects.None,
                    layerDepth: 1f);
            }


            //entity.animation?.Update();
            entity.rigidbody?.Update();
        }
    }
}