using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace ChristianTools.Helpers
{
    public class InputState
    {
        private KeyboardState keyboardState = Keyboard.GetState();
        private GamePadState gamePadState = (OperatingSystem.IsIOS()|| OperatingSystem.IsAndroid()) ? new GamePadState() : GamePad.GetState(PlayerIndex.One); // Check the device for Player One: GamePadCapabilities gamePadCapabilities = GamePad.GetCapabilities(PlayerIndex.One);
        private MouseState mouseState = Mouse.GetState();

        // General
        public bool Right => keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right) || (gamePadState.ThumbSticks.Left.X > 0);
        public bool Left => keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left) || (gamePadState.ThumbSticks.Left.X < 0);
        public bool Up => keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up) || (gamePadState.ThumbSticks.Left.Y > 0);
        public bool Down => keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down) || (gamePadState.ThumbSticks.Left.Y < 0);

        /// <summary>
        /// keyboardState.IsKeyDown(Keys.Space) || gamePadState.IsButtonDown(Buttons.A);
        /// </summary>
        public bool Jump => keyboardState.IsKeyDown(Keys.Space) || gamePadState.IsButtonDown(Buttons.A);

        public bool NotJump => !(keyboardState.IsKeyDown(Keys.Space) || gamePadState.IsButtonDown(Buttons.A));
        public bool Action => keyboardState.IsKeyDown(Keys.Enter) || gamePadState.IsButtonDown(Buttons.X) || (mouseState.LeftButton == ButtonState.Pressed);

        // Keyboard
        public bool IsKeyboardKeyDown(Keys key) => keyboardState.IsKeyDown(key);
        public bool IsKeyboardKeyUp(Keys key) => keyboardState.IsKeyUp(key);

        // Gamepad
        public bool IsGamePadButtonDown(Buttons button) => gamePadState.IsButtonDown(button);
        public bool IsGamePadButtonUp(Buttons button) => gamePadState.IsButtonUp(button);

        // PS4
        public bool PS4_Options_Down() => gamePadState.IsButtonDown(Buttons.Start);
        public bool PS4_Share_Down() => gamePadState.IsButtonDown(Buttons.Back);
        public bool PS4_PS_Down() => gamePadState.IsButtonDown(Buttons.BigButton);


        // PS4_ThumbSticks
        /*{
            if (gamePadState.ThumbSticks.Left.X != 0f || gamePadState.ThumbSticks.Left.Y != 0f)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Left Sticks X {gamePadState.ThumbSticks.Left.X}");
                Console.WriteLine($"Left Sticks Y {gamePadState.ThumbSticks.Left.Y}");
                Console.WriteLine("---------------------------------");
            }

            if (gamePadState.IsButtonDown(Buttons.LeftStick))
            {
                Console.WriteLine("Button LeftStick");
            }

            if (gamePadState.IsButtonDown(Buttons.RightStick))
            {
                System.Console.WriteLine("Button RightStick");
            }

            if (gamePadState.ThumbSticks.Right.X != 0f || gamePadState.ThumbSticks.Right.Y != 0f)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Right Sticks X {gamePadState.ThumbSticks.Right.X}");
                Console.WriteLine($"Right Sticks Y {gamePadState.ThumbSticks.Right.Y}");
                Console.WriteLine("---------------------------------");
            }
        }*/

        // PS4_R
        public bool PS4_R1_Down() => gamePadState.IsButtonDown(Buttons.RightShoulder);
        public bool PS4_R2_Down() => gamePadState.IsButtonDown(Buttons.RightTrigger);

        // PS4_L
        public bool PS4_L1_Down() => gamePadState.IsButtonDown(Buttons.LeftShoulder);
        public bool PS4_L2_Down() => gamePadState.IsButtonDown(Buttons.LeftTrigger);

        // PS4_buttons
        public bool PS4_X_Down() => gamePadState.IsButtonDown(Buttons.A);
        public bool PS4_Circle_Down() => gamePadState.IsButtonDown(Buttons.B);
        public bool PS4_Square_Down() => gamePadState.IsButtonDown(Buttons.B);
        public bool PS4_Triangle_Down() => gamePadState.IsButtonDown(Buttons.Y);

        // PS4_DPAd
        public bool PS4_DPadDown_Down() => gamePadState.IsButtonDown(Buttons.DPadDown);
        public bool PS4_DPadUp_Down() => gamePadState.IsButtonDown(Buttons.DPadUp);
        public bool PS4_DPadLeft_Down() => gamePadState.IsButtonDown(Buttons.DPadLeft);
        public bool PS4_DPadRight_Down() => gamePadState.IsButtonDown(Buttons.DPadRight);


        // Mouse
        //public Point Mouse_Position => mouseState.Position;
        public Point Mouse_OnWorldPosition()
        {
            if (ChristianGame.GetScene.camera != null)
            {
                Point point = mouseState.Position;
                point -= new Point((int)ChristianGame.GetScene.camera.cameraCenterPosition.X, (int)ChristianGame.GetScene.camera.cameraCenterPosition.Y);
                return point;
            }
            else
            {
                return mouseState.Position;
            }
        }
        
        public Point Mouse_OnWindowPosition()
        {
            return mouseState.Position;
        }
        
        public ButtonState Mouse_LeftButton => mouseState.LeftButton;
        public ButtonState Mouse_RightButton => mouseState.RightButton;
        public bool Mouse_LeftButton_Click =>(Mouse_LeftButton == ButtonState.Pressed) ? true : false;
        public bool Mouse_RightButton_Click =>(Mouse_RightButton == ButtonState.Pressed) ? true : false;


        // Touch
        private static Point lastTouch = new Point();
        public Point GetTouch()
        {
            // Thanks to: https://stackoverflow.com/a/38471621
            {
                TouchCollection touchCollection = TouchPanel.GetState();

                if (touchCollection.Count > 0)
                {
                    //Only Fire Select Once it's been released
                    if (touchCollection[0].State == TouchLocationState.Moved || touchCollection[0].State == TouchLocationState.Pressed)
                    {
                        lastTouch = touchCollection[0].Position.ToPoint();
                        return lastTouch;
                    }
                }

                return lastTouch;
            }
        }

        public bool IsTouchDown()
        {
            return TouchPanel.GetState().Count > 0;
        }
    }
}