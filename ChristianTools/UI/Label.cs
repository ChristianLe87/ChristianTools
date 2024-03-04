using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.UI
{
	public class Label : IUI
	{
		public string text;
		TextAlignment textAlignment;
		public Rectangle rectangle { get; }
		public DxUpdateSystem dxUpdateSystem { get; set; }
		public DxDrawSystem dxDrawSystem { get; set; }
		public bool isActive { get; }
		private Texture2D texture2D;

		public Label(Rectangle rectangle, string text, TextAlignment textAlignment = TextAlignment.Midle_Center, Texture2D texture = null, string tag = "", bool isActive = true)
		{
			this.rectangle = rectangle;
			this.text = text;
			this.dxUpdateSystem = (state, inputState) => UpdateSystem();
			this.dxDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
			this.textAlignment = textAlignment;

			this.texture2D = texture;
			this.isActive = isActive;
		}

		private void UpdateSystem()
		{
			if (this.isActive == false)
				return;
		}
		private void DrawSystem(SpriteBatch spriteBatch)
		{
			Rectangle rec;
			Vector2 vec;
			if (ChristianGame.GetScene.camera != null)
			{
				rec = new Rectangle(rectangle.Location + new Point(ChristianGame.GetScene.camera.cameraView.X, ChristianGame.GetScene.camera.cameraView.Y), rectangle.Size);
				vec = new Vector2(ChristianGame.GetScene.camera.cameraView.X, ChristianGame.GetScene.camera.cameraView.Y);
			}
			else
			{
				rec = rectangle;
				vec = new Vector2();
			}
                

			if (texture2D != null)
				spriteBatch.Draw(texture2D, rec, Color.White);


			spriteBatch.DrawString(ChristianGame.spriteFont, text, GetTextPosition(ChristianGame.spriteFont).ToVector2() + vec, Color.White);
		}

		private Point GetTextPosition(SpriteFont spriteFont)
		{
			int PosLeft_X = rectangle.X;
			int PosCenter_X = (rectangle.Width / 2) + (rectangle.X) - ((int)spriteFont.MeasureString(text).X / 2);
			int PosRight_X = rectangle.X + rectangle.Width - (int)spriteFont.MeasureString(text).X;

			int PosTop_Y = rectangle.Y;
			int PosMiddle_Y = rectangle.Center.Y - (((int)spriteFont.MeasureString(text).Y) / 2);
			int PosDown_Y = rectangle.Y + rectangle.Height - ((int)spriteFont.MeasureString(text).Y);

			return textAlignment switch
			{
				// Left
				TextAlignment.Top_Left => new Point(PosLeft_X, PosTop_Y),
				TextAlignment.Midle_Left => new Point(PosLeft_X, PosMiddle_Y),
				TextAlignment.Down_Left => new Point(PosLeft_X, PosDown_Y),

				// Center
				TextAlignment.Top_Center => new Point(PosCenter_X, PosTop_Y),
				TextAlignment.Midle_Center => new Point(PosCenter_X, PosMiddle_Y),
				TextAlignment.Down_Center => new Point(PosCenter_X, PosDown_Y),

				// Right
				TextAlignment.Top_Right => new Point(PosRight_X, PosTop_Y),
				TextAlignment.Midle_Right => new Point(PosRight_X, PosMiddle_Y),
				TextAlignment.Down_Right => new Point(PosRight_X, PosDown_Y),
				_ => new Point(),
			};
		}


		public enum TextAlignment
		{
			Top_Center,
			Midle_Center,
			Down_Center,

			Top_Left,
			Midle_Left,
			Down_Left,

			Top_Right,
			Midle_Right,
			Down_Right,
		}
	}
}