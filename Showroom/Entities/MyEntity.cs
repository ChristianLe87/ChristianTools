using System.Collections.Generic;
using ChristianTools;
using ChristianTools.Components;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Showroom
{
    public class MyEntity : Entity
    {

        public MyEntity(Point position, Rectangle rectangleStripeFromAtlas, string tag= "", bool isActive= true) : base(position, rectangleStripeFromAtlas, tag, isActive)
        {
            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem(inputState: inputState);
            this.dxDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
        }
        
        
        private void UpdateSystem(InputState inputState)
        {
            if (inputState.Up)
                rigidbody.Move_Y(-5);
			
            if (inputState.Down)
                rigidbody.Move_Y(5);
			
			
            if (inputState.Right)
                rigidbody.Move_X(5);
			
            if (inputState.Left)
                rigidbody.Move_X(-5);
            
        }


        private void DrawSystem(SpriteBatch spriteBatch)
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