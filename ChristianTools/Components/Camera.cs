using System;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Components
{
	public class Camera
	{
		public Rectangle rectangle { get; set; }
		public Matrix transform { get; set; }
		public Viewport viewport { get; }
		int zoom = 1;

		public Camera(Viewport viewport)
		{
			this.viewport = viewport;
			transform = Matrix.CreateScale(new Vector3(zoom, zoom, 0)) * Matrix.CreateTranslation(Vector3.Zero);//-center.X, -center.Y, 0);
			rectangle = new Rectangle(0, 0, viewport.Width, viewport.Height);
		}
		
		[Obsolete("-> Use ChristianTools.Systems.Systems.Update.Camera", true)]
		public void UpdateOld(Vector2 targetPosition)
		{
			throw new Exception("-> Use ChristianTools.Systems.Systems.Update.Camera");
		}
		
		public void Update(Vector2 targetPosition)
		{
			this.rectangle = new Rectangle(
				x: (int)(targetPosition.X - this.viewport.Width / 2),
				y: (int)targetPosition.Y - this.viewport.Height / 2,
				width: this.viewport.Width,
				height: this.viewport.Height
			);

			this.transform = Matrix.CreateTranslation(new Vector3(-this.rectangle.X, -this.rectangle.Y, 0));
		}
	}
}