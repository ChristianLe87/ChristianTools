using System;
using ChristianTools;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Showroom
{
    public class Tree : IEntity
	{
		//public Rectangle atlasRectangle { get=>rigidbody.rectangle; private set; }
		public Rigidbody rigidbody { get; }
		public Animation animation { get; private set; }
		public bool isActive { get; set; } = true;
		public DxUpdateSystem dxUpdateSystem { get; set; }
		public DxDrawSystem dxDrawSystem { get; set; }
		public string tag { get; }

		public Tree(Point position, Rectangle rectangleStripeFromAtlas)
		{
			this.animation = new Animation(rectangleStripeFromAtlas);
			this.rigidbody = new Rigidbody(rectangle: new Rectangle(position.X, position.Y, rectangleStripeFromAtlas.Width, rectangleStripeFromAtlas.Height));
			this.dxUpdateSystem = (InputState lastInputState, InputState inputState, IScene scene) => UpdateSystem();
			this.dxDrawSystem = (SpriteBatch spriteBatch, IScene scene) => DrawSystem(spriteBatch, scene);
		}


		private void UpdateSystem()
		{
			
			InputState inputState = new InputState();
			if (inputState.Up)
				rigidbody.Move_Y(-5);
			
			if (inputState.Down)
				rigidbody.Move_Y(5);
			
			
			if (inputState.Right)
				rigidbody.Move_X(5);
			
			if (inputState.Left)
				rigidbody.Move_X(-5);
			
			
			
			return;

			if (System.OperatingSystem.IsAndroid() || OperatingSystem.IsIOS())
			{
				if(inputState.IsTouchDown())
					rigidbody.SetCenterPosition(inputState.GetTouch());
			}
			else
			{
				if (inputState.Mouse_LeftButton == ButtonState.Pressed)
					rigidbody.SetCenterPosition(inputState.GetTouch());
			}

			if (inputState.IsKeyboardKeyDown(Keys.P))
			{
				rigidbody.rotationDegree += 1;
			}
			
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