using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Systems
{
    public partial class Systems
    {
        public partial class Draw
        {
            public static void Entity(SpriteBatch spriteBatch, IEntity entity)
            {
                if (entity.isActive == false)
                    return;


                if (entity.dxDrawSystem != null)
                {
                    entity.dxDrawSystem(spriteBatch);
                }
                else
                {
                    Texture2D texture2D = entity.animation.GetTexture(entity.characterState);
                    Rectangle rectangle = new Rectangle((int)entity.rigidbody.centerPosition.X, (int)entity.rigidbody.centerPosition.Y, texture2D.Width, texture2D.Height);


                    spriteBatch.Draw(
                        texture: texture2D,
                        destinationRectangle: rectangle,
                        sourceRectangle: null,
                        color: Color.White,
                        rotation: (float)Tools.Tools.MyMath.DegreeToRadian(entity.rigidbody.rotationDegree),// always value radians
                        origin: new Vector2(rectangle.Width / 2, rectangle.Height / 2),
                        effects: SpriteEffects.None,
                        layerDepth: 1f
                    );
                }

            }
        }
    }
}