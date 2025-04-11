namespace ChristianTools.UI
{
	public class Label : IUI
	{
		public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
		public DxCustomDrawSystem dxCustomDrawSystem { get; set; }

		private readonly Rectangle originalRectangle;
		private Rectangle scaledRectangle
		{
			get
			{
				if (UI_Position == Alignment.Null)
				{
					Rectangle rectangle = originalRectangle;
					rectangle.X *= scaleFactor;
					rectangle.Y *= scaleFactor;
					rectangle.Width *= scaleFactor;
					rectangle.Height *= scaleFactor;

					return Helpers.MyRectangle.GetRectangleBaseOnCanvasPosition(UI_Position, rectangle, margin * scaleFactor);
				}
				else
				{
					return Helpers.MyRectangle.GetRectangleBaseOnCanvasPosition(UI_Position, originalRectangle.Width * scaleFactor, originalRectangle.Height * scaleFactor, margin * scaleFactor);
				}
			}
		}


		public bool isActive { get; set; }
		public string tag { get; private set; }

		private Texture2D defaultTexture;

		public string text;

		private Alignment textAlignment = Alignment.Null;
		private Alignment UI_Position = Alignment.Null;
		private int margin;

		private SpriteFont spriteFont => ChristianGame.WK.spriteFonts[Math.Clamp((ChristianGame.WK.ScaleFactor - 1), 0, (ChristianGame.WK.MaxScaleFactor - 1))];
		private int scaleFactor => ChristianGame.WK.ScaleFactor;

		/// <summary>
		/// Create Label base on UI_Position
		/// </summary>
		/// <param name="text"></param>
		/// <param name="textAlignment"></param>
		/// <param name="UI_Position"></param>
		/// <param name="Width"></param>
		/// <param name="Height"></param>
		/// <param name="margin"></param>
		/// <param name="texture"></param>
		/// <param name="tag"></param>
		public Label(string text, Alignment UI_Position, int Width = 50, int Height = 10, Alignment textAlignment = Alignment.Midle_Center, int margin = 0, Texture2D texture = null, string tag = "")
		{
			this.originalRectangle = Helpers.MyRectangle.GetRectangleBaseOnCanvasPosition(UI_Position, Width, Height, margin);
			Init(text: text, textAlignment: textAlignment, texture: texture, margin: margin, UI_Position: UI_Position, tag: tag);
		}

		/// <summary>
		/// Create Label base on Rectangle
		/// </summary>
		/// <param name="text"></param>
		/// <param name="textAlignment"></param>
		/// <param name="rectangle"></param>
		/// <param name="texture"></param>
		/// <param name="tag"></param>
		public Label(string text, Rectangle rectangle, Alignment textAlignment = Alignment.Midle_Center, Texture2D texture = null, string tag = "")
		{
			this.originalRectangle = rectangle;
			Init(text: text, textAlignment: textAlignment, texture: texture, margin: margin, tag: tag);
		}

		private void Init(string text, Alignment textAlignment, Texture2D texture, string tag, int margin = 0, Alignment UI_Position = Alignment.Null)
		{
			this.tag = tag;
			this.text = text;
			this.textAlignment = textAlignment;
			this.UI_Position = UI_Position;
			this.margin = margin;
			this.defaultTexture = texture;
			this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
			this.isActive = true;
		}

		private void DrawSystem(SpriteBatch spriteBatch)
		{
			if (defaultTexture != null) spriteBatch.Draw(defaultTexture, scaledRectangle, Color.White);

			Vector2 position = GetTextPosition(this.spriteFont).ToVector2();
			spriteBatch.DrawString(this.spriteFont, text, position, Color.White);
		}

		/*public void UpdateRectangle(Rectangle rectangle)
		{
			//this.rectangle = rectangle;
			//this.textPosition = GetTextPosition(this.spriteFont);
		}*/
		
		
		public void UpdateOnGameWindowSizeChangeEvent()
		{
			//if (UI_Position != Alignment.Null) this.rectangle = Helpers.MyRectangle.GetRectangleBaseOnCanvasPosition(this.UI_Position, rectangle.Width, rectangle.Height, this.margin);

			//this.textPosition = GetTextPosition(this.spriteFont);
		}

		private Point GetTextPosition(SpriteFont spriteFont)
		{
			//Rectangle rectangle = scaledRectangle;

			int PosLeft_X = scaledRectangle.X;
			int PosCenter_X = (scaledRectangle.Width / 2) + (scaledRectangle.X) - ((int)spriteFont.MeasureString(text).X / 2);
			int PosRight_X = scaledRectangle.X + scaledRectangle.Width - (int)spriteFont.MeasureString(text).X;

			int PosTop_Y = scaledRectangle.Y;
			int PosMiddle_Y = scaledRectangle.Center.Y - (((int)spriteFont.MeasureString(text).Y) / 2);
			int PosDown_Y = scaledRectangle.Y + scaledRectangle.Height - ((int)spriteFont.MeasureString(text).Y);

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