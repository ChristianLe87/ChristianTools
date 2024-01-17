using System.Collections.Generic;
using ChristianTools;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Entities
{
    public class Entity : IEntity
    {
        public Rigidbody rigidbody { get; }
        public Animation animation { get; }
        public bool isActive { get; set; } = true;
        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }
        public string tag { get; }

        public Entity(Point position, Rectangle rectangleStripeFromAtlas, string tag= "", bool isActive= true)
        {
            this.animation = new Animation(rectangleStripeFromAtlas);
            this.rigidbody = new Rigidbody(rectangle: new Rectangle(position.X, position.Y, rectangleStripeFromAtlas.Width, rectangleStripeFromAtlas.Height));
            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem();
            this.dxDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
            this.tag = tag;
            this.isActive = isActive;
        }
        
        
        private void UpdateSystem()
        {
            if (this.isActive != true)
                return;
            
            this.animation?.Update();
            this.rigidbody?.Update();
        }


        private void DrawSystem(SpriteBatch spriteBatch)
        {
            if (this.isActive != true)
                return;

            spriteBatch.Draw(
                texture: ChristianGame.atlasTexture2D,// atlas texture
                destinationRectangle: rigidbody.rectangle,
                sourceRectangle: animation.imageFromAtlas,
                color: Color.White,
                rotation: (float)ChristianTools.Helpers.MyMath.DegreeToRadian(rigidbody.rotationDegree), // always value radians
                origin: new Vector2(rigidbody.rectangle.Width / 2, rigidbody.rectangle.Height / 2),
                effects: SpriteEffects.None,
                layerDepth: 1 / 10f 
            );
        }
    }
}