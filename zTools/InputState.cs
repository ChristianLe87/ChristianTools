using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace zTools
{
    public class InputState
    {
        KeyboardState keyboardState = Keyboard.GetState();
        GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

        public bool Right { get => keyboardState.IsKeyDown(Keys.D) || (gamePadState.ThumbSticks.Left.X > 0); }
        public bool Left { get => keyboardState.IsKeyDown(Keys.A) || (gamePadState.ThumbSticks.Left.X < 0); }
        public bool Jump { get => keyboardState.IsKeyDown(Keys.Space) || gamePadState.IsButtonDown(Buttons.A); }
    }
}