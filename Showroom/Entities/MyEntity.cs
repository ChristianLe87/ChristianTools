using System.Collections.Generic;
using ChristianTools;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Showroom
{
    public class MyEntity : IEntity
    {
        public Rigidbody rigidbody { get; }
        public Animation animation { get; }
        public bool isActive { get; set; } = true;
        public DxUpdateSystem dxUpdateSystem { get; }
        public DxDrawSystem dxDrawSystem { get; set; }
        public string tag { get; }

        public MyEntity(Point position, Rectangle rectangleStripeFromAtlas)
        {
            this.animation = new Animation(rectangleStripeFromAtlas);
            this.rigidbody = new Rigidbody(rectangle: new Rectangle(position.X, position.Y, rectangleStripeFromAtlas.Width, rectangleStripeFromAtlas.Height));
            //this.dxUpdateSystem = (InputState lastInputState, InputState inputState, IScene scene) => UpdateSystem();
            this.dxDrawSystem = (SpriteBatch spriteBatch, IScene scene) => DrawSystem(spriteBatch, scene);
        }
        
        
        private void UpdateSystem()
        {
        }


        private void DrawSystem(SpriteBatch spriteBatch, IScene scene)
        {
            spriteBatch.Draw(
                texture: ChristianGame.atlasTexture2D,// atlas texture
                destinationRectangle: rigidbody.rectangle,
                sourceRectangle: animation.imageFromAtlas,
                color: Color.White,
                rotation: (float)ChristianTools.Helpers.MyMath.DegreeToRadian(rigidbody.rotationDegree), // always value radians
                origin: new Vector2(rigidbody.rectangle.Width / 2, rigidbody.rectangle.Height / 2),
                effects: SpriteEffects.None,
                layerDepth: 1 / 10f // (float)Tiled.LayerId.Entities/10f
            );
        }
    }
}