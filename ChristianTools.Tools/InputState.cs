using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ChristianTools.Tools
{
    public class InputState
    {
        KeyboardState keyboardState = Keyboard.GetState();
        GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
        MouseState mouseState = Mouse.GetState();

        public bool Right => keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right) || (gamePadState.ThumbSticks.Left.X > 0);
        public bool Left => keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left) || (gamePadState.ThumbSticks.Left.X < 0);
        public bool Jump => keyboardState.IsKeyDown(Keys.Space) || gamePadState.IsButtonDown(Buttons.A);
        public bool NotJump => !(keyboardState.IsKeyDown(Keys.Space) || gamePadState.IsButtonDown(Buttons.A));

        // Keyboard
        public bool IsKeyboardKeyDown(Keys key) => keyboardState.IsKeyDown(key);
        public bool IsKeyboardKeyUp(Keys key) => keyboardState.IsKeyUp(key);

        // Gamepad
        public bool IsGamePadButtonDown(Buttons button) => gamePadState.IsButtonDown(button);
        public bool IsGamePadButtonUp(Buttons button) => gamePadState.IsButtonUp(button);

        // Mouse
        public Point Mouse_Position => mouseState.Position;
        public ButtonState Mouse_LeftButton => mouseState.LeftButton;
    }
}
