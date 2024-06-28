namespace ChristianTools.UI
{
    public class Button : IUI
    {
        Texture2D defaultTexture;
        Texture2D mouseOverTexture;
        bool isMouseOver;
        //Label label;

        public Rectangle rectangle { get; private set; }
        public string tag { get; private set; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
        public bool isActive { get; set; }
        public Texture2D texture { get; }
        public delegate void DxOnClickAction();

        DxOnClickAction OnClickAction;

        private Alignment UI_Position;
        private int margin;

        public Button(Alignment UI_Position, int width, int height, string text, DxOnClickAction OnClickAction, int margin = 0, string tag = "", Texture2D defaultTexture = null, Texture2D mouseOverTexture = null, bool isActive = true)
        {
            this.UI_Position = UI_Position;
            this.margin = margin;
            
            this.rectangle = Helpers.MyRectangle.GetRectangleBaseOnCanvasPosition(UI_Position, width, height, margin);
            
            
            
            this.defaultTexture = defaultTexture ?? ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray);
            this.mouseOverTexture = mouseOverTexture ?? ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray);
            this.isMouseOver = false;

            //this.label = new Label(UI_Position, rectangle.Width, rectangle.Height, text, margin: 0, textAlignment: Alignment.Midle_Center, tag: "");

            this.tag = tag;

            this.OnClickAction = OnClickAction;


            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem(lastInputState, inputState);
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
            
            this.isActive = isActive;
            
            
            
            //Init(rectangle, text, OnClickAction, tag, defaultTexture, mouseOverTexture, isActive);
        }


        /*public Button(Rectangle rectangle, string text, DxOnClickAction OnClickAction, string tag = "", Texture2D defaultTexture = null, Texture2D mouseOverTexture = null, bool isActive = true)
        {
            Init(rectangle, text, OnClickAction, tag, defaultTexture, mouseOverTexture, isActive);
        }*/

        /*private void Init(Rectangle rectangle, string text, DxOnClickAction OnClickAction, string tag = "", Texture2D defaultTexture = null, Texture2D mouseOverTexture = null, bool isActive = true)
        {
            //this.rectangle = rectangle;
            this.defaultTexture = defaultTexture ?? ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray);
            this.mouseOverTexture = mouseOverTexture ?? ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray);
            this.isMouseOver = false;

            this.label = new Label(UI_Position, rectangle.Width, rectangle.Height, text, margin: 0, textAlignment: Alignment.Midle_Center, tag: "");

            this.tag = tag;

            this.OnClickAction = OnClickAction;


            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem(lastInputState, inputState);
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
            this.isActive = isActive;
        }*/
        
        public void UpdateOnGameWindowSizeChangeEvent()
        {
            this.rectangle = Helpers.MyRectangle.GetRectangleBaseOnCanvasPosition(UI_Position, this.rectangle.Width, this.rectangle.Height, margin);
            //this.label.UpdateOnGameWindowSizeChangeEvent();
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


            //label.dxCustomDrawSystem(spriteBatch);
        }
    }
}
