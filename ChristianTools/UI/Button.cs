namespace ChristianTools.UI
{
    public class Button : IUI
    {
        private Texture2D defaultTexture;
        private Texture2D mouseOverTexture;
        private bool isMouseOver;
        private Label label;

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

        public string tag { get; private set; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
        public bool isActive { get; set; }

        public delegate void DxOnClickAction();

        DxOnClickAction OnClickAction;

        private Alignment UI_Position;
        private int margin;
        private int scaleFactor => ChristianGame.WK.ScaleFactor;


        /// <summary>
        /// Create Button base on UI_Position
        /// </summary>
        /// <param name="UI_Position"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="text"></param>
        /// <param name="OnClickAction"></param>
        /// <param name="margin"></param>
        /// <param name="tag"></param>
        /// <param name="defaultTexture"></param>
        /// <param name="mouseOverTexture"></param>
        /// <param name="isActive"></param>
        public Button(Alignment UI_Position, int width, int height, string text, DxOnClickAction OnClickAction, int margin = 0, string tag = "", Texture2D defaultTexture = null, Texture2D mouseOverTexture = null, bool isActive = true)
        {
            this.originalRectangle = Helpers.MyRectangle.GetRectangleBaseOnCanvasPosition(UI_Position, width, height, margin * scaleFactor);

            this.label = new Label(text: text, textAlignment: Alignment.Midle_Center, UI_Position: UI_Position, Width: width, Height: height, margin: margin, texture: defaultTexture, tag: tag);

            Init(UI_Position: UI_Position, OnClickAction: OnClickAction, margin: margin, tag: tag, defaultTexture: defaultTexture, mouseOverTexture: mouseOverTexture, isActive: isActive);
        }


        /// <summary>
        /// Create Button base on Rectangle
        /// </summary>
        /// <param name="rectangle"></param>
        /// <param name="text"></param>
        /// <param name="OnClickAction"></param>
        /// <param name="tag"></param>
        /// <param name="defaultTexture"></param>
        /// <param name="mouseOverTexture"></param>
        /// <param name="isActive"></param>
        public Button(Rectangle rectangle, string text, DxOnClickAction OnClickAction, string tag = "", Texture2D defaultTexture = null, Texture2D mouseOverTexture = null, bool isActive = true)
        {
            this.originalRectangle = rectangle;
            this.label = new Label(rectangle: originalRectangle, text: text, textAlignment: Alignment.Midle_Center);

            Init(Alignment.Null, OnClickAction: OnClickAction, margin: 0, tag: tag, defaultTexture: defaultTexture, mouseOverTexture: mouseOverTexture, isActive: isActive);
        }

        private void Init(Alignment UI_Position, DxOnClickAction OnClickAction, int margin, string tag, Texture2D defaultTexture, Texture2D mouseOverTexture, bool isActive)
        {
            this.UI_Position = UI_Position;
            this.margin = margin;
            this.defaultTexture = defaultTexture ?? ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray);
            this.mouseOverTexture = mouseOverTexture ?? ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray);
            this.isMouseOver = false;
            this.tag = tag;
            this.OnClickAction = OnClickAction;
            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem(lastInputState, inputState);
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
            this.isActive = isActive;
        }


        public void UpdateOnGameWindowSizeChangeEvent()
        {
            // Code
        }

        private void UpdateSystem(InputState lastInputState, InputState inputState)
        {
            if (scaledRectangle.Contains(inputState.GetActionOnWindowPosition()))
            {
                isMouseOver = true;

                if ((inputState.Action == true && lastInputState.Action == false) || inputState.touch.IsTouchDown())
                    OnClickAction?.Invoke();
            }
            else
            {
                isMouseOver = false;
            }
        }

        private void DrawSystem(SpriteBatch spriteBatch)
        {
            if (isMouseOver)
                spriteBatch.Draw(mouseOverTexture, scaledRectangle, Color.White);
            else
                spriteBatch.Draw(defaultTexture, scaledRectangle, Color.White);


            label.dxCustomDrawSystem(spriteBatch);
        }
    }
}