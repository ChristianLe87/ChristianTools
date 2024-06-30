namespace ChristianTools.UI
{
	public class Label : IUI
	{
		public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
		public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
		public bool isActive { get; set; }
		public string tag { get; private set; }

		private Texture2D defaultTexture;
		private Rectangle rectangle;

		public string text;
		private Point textPosition;

		private Alignment textAlignment = Alignment.Null;
		private Alignment UI_Position = Alignment.Null;
		private int margin;

		public Label(string text, Alignment textAlignment, Alignment UI_Position, int Width, int Height, int margin = 0, Texture2D texture = null, string tag = "")
		{
			Rectangle rec = Helpers.MyRectangle.GetRectangleBaseOnCanvasPosition(UI_Position, Width, Height, margin);

			Init(text: text, textAlignment: textAlignment, texture: texture, rectangle: rec, margin: margin, UI_Position: UI_Position, tag: tag);
		}

		public Label(string text, Alignment textAlignment, Rectangle rectangle, Texture2D texture = null, string tag = "")
		{
			Init(text: text, textAlignment: textAlignment, texture: texture, rectangle: rectangle, margin: margin, tag: tag);
		}

		private void Init(string text, Alignment textAlignment, Texture2D texture, Rectangle rectangle, string tag, int margin = 0, Alignment UI_Position = Alignment.Null)
		{
			this.tag = tag;
			this.text = text;
			this.textAlignment = textAlignment;
			this.UI_Position = UI_Position;
			this.margin = margin;

			this.rectangle = rectangle;
			this.defaultTexture = texture;
			this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);

			this.isActive = true;
			this.textPosition = GetTextPosition(ChristianGame.spriteFont);
		}

		private void DrawSystem(SpriteBatch spriteBatch)
		{
			if (defaultTexture != null)
				spriteBatch.Draw(defaultTexture, rectangle, Color.White);

			spriteBatch.DrawString(ChristianGame.spriteFont, text, textPosition.ToVector2(), Color.White);
		}

		public void UpdateRectangle(Rectangle rectangle)
		{
			this.rectangle = rectangle;
			this.textPosition = GetTextPosition(ChristianGame.spriteFont);
		}
		
		
		public void UpdateOnGameWindowSizeChangeEvent()
		{
			if (UI_Position != Alignment.Null)
				this.rectangle = Helpers.MyRectangle.GetRectangleBaseOnCanvasPosition(this.UI_Position, rectangle.Width, rectangle.Height, this.margin);

			this.textPosition = GetTextPosition(ChristianGame.spriteFont);
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