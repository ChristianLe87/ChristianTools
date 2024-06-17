namespace ChristianTools.UI
{
	public class Label : IUI
	{
		public string text;
		Alignment textAlignment;
		public Rectangle rectangle { get; private set; }
		public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
		public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
		public bool isActive { get; private set; }
		private Texture2D texture2D;

		public Label(Alignment UI_Position, int width, int height, string text, int margin = 0, Alignment textAlignment = Alignment.Midle_Center, Texture2D texture = null, string tag = "", bool isActive = true)
		{
			Rectangle rectangle = Helpers.MyRectangle.GetRectangleBaseOnCanvasPosition(UI_Position, width, height, margin);
			Init(rectangle, text, textAlignment, texture, tag, isActive);
		}

		public Label(Rectangle rectangle, string text, Alignment textAlignment = Alignment.Midle_Center, Texture2D texture = null, string tag = "", bool isActive = true)
		{
			Init(rectangle, text, textAlignment, texture, tag, isActive);
		}

		private void Init(Rectangle rectangle, string text, Alignment textAlignment = Alignment.Midle_Center, Texture2D texture = null, string tag = "", bool isActive = true)
		{
			this.rectangle = rectangle;
			this.text = text;
			this.dxCustomUpdateSystem = (state, inputState) => UpdateSystem();
			this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
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
			if (texture2D != null)
				spriteBatch.Draw(texture2D, rectangle, Color.White);


			spriteBatch.DrawString(ChristianGame.spriteFont, text, GetTextPosition(ChristianGame.spriteFont).ToVector2() + new Vector2(), Color.White);
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
				Alignment.Top_Left => new Point(PosLeft_X, PosTop_Y),
				Alignment.Midle_Left => new Point(PosLeft_X, PosMiddle_Y),
				Alignment.Down_Left => new Point(PosLeft_X, PosDown_Y),

				// Center
				Alignment.Top_Center => new Point(PosCenter_X, PosTop_Y),
				Alignment.Midle_Center => new Point(PosCenter_X, PosMiddle_Y),
				Alignment.Down_Center => new Point(PosCenter_X, PosDown_Y),

				// Right
				Alignment.Top_Right => new Point(PosRight_X, PosTop_Y),
				Alignment.Midle_Right => new Point(PosRight_X, PosMiddle_Y),
				Alignment.Down_Right => new Point(PosRight_X, PosDown_Y),
				_ => new Point(),
			};
		}
	}
}
