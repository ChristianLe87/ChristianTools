
using System;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Helpers.Enums_Interfaces_Delegates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Showroom_CrossPlatform;

namespace ChristianTools.Entities
{
	public class Bullet : IEntity
	{
		public Rigidbody rigidbody { get; }
		public Animation animation { get; }
		public bool isActive { get; set; }

		private TimeSpan timeToDeactivate;
		
		public DxUpdateSystem dxUpdateSystem { get; }
		public DxDrawSystem dxDrawSystem { get; set; }
		public string tag { get; }

		public Bullet(Vector2 direction, int steps, Rectangle imageFromAtlas, TimeSpan timeToDeactivate)
		{
			this.animation = new Animation(imageFromAtlas);
			this.timeToDeactivate = timeToDeactivate;
			this.isActive = true;
			

			double radAngle = Helpers.MyMath.GetAngleInRadians(imageFromAtlas.Center.ToVector2(), direction);
			float x = (float)(steps * Math.Cos(radAngle));
			float y = (float)(steps * Math.Sin(radAngle));

			this.rigidbody = new Rigidbody(
				rectangle:imageFromAtlas,
				force: new Vector2(x, y)
			);

			this.dxUpdateSystem = (Viewport viewport, InputState lastInputState, InputState inputState, IScene scene) => BulletUpdateSystem();

		}
		
		
		public void BulletUpdateSystem()
		{
			// Implementation
			if (isActive == true)
			{
				TimeToDestroy();
				rigidbody.Update();
			}

			// Helpers
			void TimeToDestroy()
			{
				if (timeToDeactivate.TotalMilliseconds != 0)
				{
					TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, (int)((1f / ChristianGame.WK.FPS) * 1000));
					timeToDeactivate = timeToDeactivate.Subtract(timeSpan);

					if (timeToDeactivate.TotalMilliseconds <= 0)
						isActive = false;
				}
			}
		}
	}
}