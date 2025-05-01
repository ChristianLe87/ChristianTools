namespace ChristianTools.UI
{
    public class Dialogue : IUI
    {
        Texture2D defaultTexture;

        Label titleLabel;
        Label textlabel;

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

        //public readonly string tag;
        public string tag { get; }

        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
        public bool isActive { get; set; }
        private Alignment UI_Position;
        private int margin;

        public string text;
        public string title;

        private int scaleFactor => ChristianGame.WK.ScaleFactor;


        /// <summary>
        /// Create Label base on UI_Position
        /// </summary>
        /// <param name="title"></param>
        /// <param name="text"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="textAlignment"></param>
        /// <param name="UI_Position"></param>
        /// <param name="margin"></param>
        /// <param name="tag"></param>
        /// <param name="texture"></param>
        /// <param name="isActive"></param>
        public Dialogue(string title, string text, int Width, int Height, /*Alignment textAlignment,*/ Alignment UI_Position, int margin, string tag = "", Texture2D texture = null, bool isActive = true)
        {
            this.text = text;
            this.title = title;
            this.UI_Position = UI_Position;
            this.margin = margin;

            this.defaultTexture = defaultTexture ?? ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray);
            Texture2D transparentTexture = ChristianTools.Helpers.Texture.CreateColorTexture(new Color(0, 0, 0, 0));

            // titleLabel
            this.originalRectangle = Helpers.MyRectangle.GetRectangleBaseOnCanvasPosition(UI_Position, Width, Height, margin * scaleFactor);
            this.titleLabel = new Label(text: title, textAlignment: Alignment.Top_Left, UI_Position: UI_Position, Width: Width, Height: Height, margin: margin, texture: transparentTexture, tag: tag);

            // textlabel
            this.originalRectangle = Helpers.MyRectangle.GetRectangleBaseOnCanvasPosition(UI_Position, Width, Height, margin * scaleFactor);
            this.textlabel = new Label(text: text, textAlignment: Alignment.Midle_Center, UI_Position: UI_Position, Width: Width, Height: Height, margin: margin, texture: transparentTexture, tag: tag);

            this.tag = tag;

            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem(lastInputState, inputState);
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);

            this.isActive = isActive;
        }

        public void UpdateOnGameWindowSizeChangeEvent()
        {
            // Code
        }



        private int framesCount = 0;
        private int charCount = 0;
        private void UpdateSystem(InputState lastInputState, InputState inputState)
        {
            titleLabel.text = title;

            if (isActive)
            {
                framesCount++;
                if (framesCount > 2)
                {
                    framesCount = 0;
                    charCount++;
                }


                if (charCount < text.Length)
                {
                    textlabel.text = text.Substring(0, charCount);
                }
                else
                {
                    textlabel.text = text;
                }
            }
            else
            {
                ResetDialogue();
            }
        }

        public void ResetDialogue()
        {
            framesCount = 0;
            charCount = 0;
            textlabel.text = string.Empty;
        }

        private void DrawSystem(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(defaultTexture, scaledRectangle, Color.White);

            titleLabel.dxCustomDrawSystem(spriteBatch);
            textlabel.dxCustomDrawSystem(spriteBatch);
        }
    }
}
