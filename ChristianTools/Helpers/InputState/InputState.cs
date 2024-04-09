namespace ChristianTools.Helpers
{
    public class InputState
    {
        public MyMouse mouse { get; }
        public MyKeyboard keyboard { get; }
        public MyGamePad gamePad { get; }
        public MyPS4 ps4 { get; }
        public MyTouch touch { get; }

        public InputState()
        {
            this.mouse = new MyMouse();
            this.keyboard = new MyKeyboard();
            this.gamePad = new MyGamePad();
            this.ps4 = new MyPS4();
            this.touch = new MyTouch();
        }

        public bool Right => keyboard.IsKeyboardKeyDown(Keys.D) || keyboard.IsKeyboardKeyDown(Keys.Right) || gamePad.IsThumbSticksRight;
        public bool Left => keyboard.IsKeyboardKeyDown(Keys.A) || keyboard.IsKeyboardKeyDown(Keys.Left) || gamePad.IsThumbSticksLeft;
        public bool Up => keyboard.IsKeyboardKeyDown(Keys.W) || keyboard.IsKeyboardKeyDown(Keys.Up) || gamePad.IsThumbSticksUp;
        public bool Down => keyboard.IsKeyboardKeyDown(Keys.S) || keyboard.IsKeyboardKeyDown(Keys.Down) || gamePad.IsThumbSticksDown;
        public bool Jump => keyboard.IsKeyboardKeyDown(Keys.Space) || gamePad.IsButtonDown(Buttons.A);
        public bool NotJump => !(keyboard.IsKeyboardKeyDown(Keys.Space) || gamePad.IsButtonDown(Buttons.A));
        public bool Action => keyboard.IsKeyboardKeyDown(Keys.Enter) || gamePad.IsButtonDown(Buttons.X) || mouse.IsLeftButton_Click || touch.IsTouchDown();
        public bool Escape => keyboard.IsKeyboardKeyDown(Keys.Escape);

        public Point GetActionOnWindowPosition()
        {
            if (touch.IsTouchDown())
                return touch.GetOnWindowTouch();

            return mouse.GetOnWindowPosition();
        }

        public Point GetActionOnWorldPosition()
        {
            if (touch.IsTouchDown())
                return touch.GetOnWorldTouch();

            return mouse.GetOnWorldPosition();
        }
    }
}
