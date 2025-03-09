namespace ChristianTools.UI
{
    public class Dialogue : IUI
    {
        Texture2D defaultTexture;

        Label titleLabel;
        Label textlabel;

        public Rectangle rectangle { get; private set; }
        public string tag { get; private set; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
        public bool isActive { get; set; }
        public Texture2D texture { get; }

        private Alignment UI_Position;
        private int margin;

        private string text;
        private string title;

        public Dialogue(string title, string text, int Width, int Height, Alignment textAlignment, Alignment UI_Position, int margin, string tag, Texture2D texture = null, bool isActive = true)
        {
            this.title = title;
            this.text = text;
            this.UI_Position = UI_Position;
            this.margin = margin;

            this.rectangle = Helpers.MyRectangle.GetRectangleBaseOnCanvasPosition(UI_Position, Width, Height, margin);

            this.defaultTexture = defaultTexture ?? ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray);

            this.titleLabel = new Label(rectangle: rectangle, text: title, textAlignment: Alignment.Top_Left);
            this.textlabel = new Label(rectangle: rectangle, text: text, textAlignment: textAlignment);

            this.tag = tag;

            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem(lastInputState, inputState);
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);

            this.isActive = isActive;
        }

        public void UpdateOnGameWindowSizeChangeEvent()
        {
            if (UI_Position != Alignment.Null)
                this.rectangle = Helpers.MyRectangle.GetRectangleBaseOnCanvasPosition(UI_Position, this.rectangle.Width, this.rectangle.Height, margin);

            this.textlabel.UpdateRectangle(rectangle);
            this.titleLabel.UpdateRectangle(rectangle);
        }



        private int framesCount = 0;
        private int charCount = 0;
        private void UpdateSystem(InputState lastInputState, InputState inputState)
        {
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
            spriteBatch.Draw(defaultTexture, rectangle, Color.White);

            titleLabel.dxCustomDrawSystem(spriteBatch);
            textlabel.dxCustomDrawSystem(spriteBatch);
        }
    }
}
