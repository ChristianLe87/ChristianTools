namespace ChristianTools.UI
{
    public class Button : IUI
    {
        Texture2D defaultTexture;
        Texture2D mouseOverTexture;
        bool isMouseOver;
        Label label;

        public Rectangle rectangle { get; private set; }
        public string tag { get; private set; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
        public bool isActive { get; set; }


        public Texture2D texture { get; }

        public delegate void DxOnClickAction();

        DxOnClickAction OnClickAction;

        public Button(Alignment UI_Position, int W, int H, string text, DxOnClickAction OnClickAction, string tag = "", Texture2D defaultTexture = null, Texture2D mouseOverTexture = null, bool isActive = true)
        {
            Rectangle _rectangle = new Rectangle(0, 0, W, H);

            switch (UI_Position)
            {
                case Alignment.Top_Center:
                    _rectangle.X = (ChristianGame.WK.CanvasWidth / 2) - (_rectangle.Width / 2);
                    _rectangle.Y = 0;
                    break;
                case Alignment.Midle_Center:
                    _rectangle.X = (ChristianGame.WK.CanvasWidth / 2) - (_rectangle.Width / 2);
                    _rectangle.Y = (ChristianGame.WK.CanvasHeight / 2) - (_rectangle.Height / 2);
                    break;
                case Alignment.Down_Center:
                    _rectangle.X = (ChristianGame.WK.CanvasWidth / 2) - (_rectangle.Width / 2);
                    _rectangle.Y = ChristianGame.WK.CanvasHeight - _rectangle.Height;
                    break;

                case Alignment.Top_Left:
                    _rectangle.X = 0;
                    _rectangle.Y = 0;
                    break;
                case Alignment.Midle_Left:
                    _rectangle.X = 0;
                    _rectangle.Y = (ChristianGame.WK.CanvasHeight / 2) - (_rectangle.Height / 2);
                    break;
                case Alignment.Down_Left:
                    _rectangle.X = 0;
                    _rectangle.Y = ChristianGame.WK.CanvasHeight - _rectangle.Height;
                    break;

                case Alignment.Top_Right:
                    _rectangle.X = ChristianGame.WK.CanvasWidth - _rectangle.Width;
                    _rectangle.Y = 0;
                    break;
                case Alignment.Midle_Right:
                    _rectangle.X = ChristianGame.WK.CanvasWidth - _rectangle.Width;
                    _rectangle.Y = (ChristianGame.WK.CanvasHeight / 2) - (_rectangle.Height / 2);
                    break;
                case Alignment.Down_Right:
                    _rectangle.X = ChristianGame.WK.CanvasWidth - _rectangle.Width;
                    _rectangle.Y = ChristianGame.WK.CanvasHeight - _rectangle.Height;
                    break;

                default:
                    break;
            }

            Init(_rectangle, text, OnClickAction, tag, defaultTexture, mouseOverTexture, isActive);
        }


        public Button(Rectangle rectangle, string text, DxOnClickAction OnClickAction, string tag = "", Texture2D defaultTexture = null, Texture2D mouseOverTexture = null, bool isActive = true)
        {
            Init(rectangle, text, OnClickAction, tag, defaultTexture, mouseOverTexture, isActive);
        }

        private void Init(Rectangle rectangle, string text, DxOnClickAction OnClickAction, string tag = "", Texture2D defaultTexture = null, Texture2D mouseOverTexture = null, bool isActive = true)
        {
            this.rectangle = rectangle;
            this.defaultTexture = defaultTexture ?? ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray);
            this.mouseOverTexture = mouseOverTexture ?? ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray);
            this.isMouseOver = false;

            this.label = new Label(rectangle, text, Alignment.Midle_Center, tag: "");

            this.tag = tag;

            this.OnClickAction = OnClickAction;


            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem(lastInputState, inputState);
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
            this.isActive = isActive;
        }

        private void UpdateSystem(InputState lastInputState, InputState inputState)
        {
            if (rectangle.Contains(inputState.GetActionOnWindowPosition()))
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
                spriteBatch.Draw(mouseOverTexture, rectangle, Color.White);
            else
                spriteBatch.Draw(defaultTexture, rectangle, Color.White);


            label.dxCustomDrawSystem(spriteBatch);
        }
    }
}