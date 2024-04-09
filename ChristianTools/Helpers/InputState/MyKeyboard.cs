namespace ChristianTools.Helpers
{
    public class MyKeyboard
    {
        private KeyboardState keyboardState { get; }

        public MyKeyboard()
        {
            this.keyboardState = Keyboard.GetState();
        }

        public bool IsKeyboardKeyDown(Keys key) => keyboardState.IsKeyDown(key);
        public bool IsKeyboardKeyUp(Keys key) => keyboardState.IsKeyUp(key);
    }
}
