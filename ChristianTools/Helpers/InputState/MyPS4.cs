using System;
using Microsoft.Xna.Framework.Input;

namespace ChristianTools.Helpers
{
    public class MyPS4
    {
        private MyGamePad gamePad { get; }

        public MyPS4()
        {
            this.gamePad = new MyGamePad();
        }

        public bool Is_Options_Down() => gamePad.IsButtonDown(Buttons.Start);
        public bool Is_Share_Down() => gamePad.IsButtonDown(Buttons.Back);
        public bool Is_PS_Down() => gamePad.IsButtonDown(Buttons.BigButton);

        // PS4_R
        public bool Is_R1_Down() => gamePad.IsButtonDown(Buttons.RightShoulder);
        public bool Is_R2_Down() => gamePad.IsButtonDown(Buttons.RightTrigger);

        // PS4_L
        public bool Is_L1_Down() => gamePad.IsButtonDown(Buttons.LeftShoulder);
        public bool Is_L2_Down() => gamePad.IsButtonDown(Buttons.LeftTrigger);

        // PS4_buttons
        public bool Is_X_Down() => gamePad.IsButtonDown(Buttons.A);
        public bool Is_Circle_Down() => gamePad.IsButtonDown(Buttons.B);
        public bool Is_Square_Down() => gamePad.IsButtonDown(Buttons.B);
        public bool Is_Triangle_Down() => gamePad.IsButtonDown(Buttons.Y);

        // PS4_DPad
        public bool Is_DPadDown_Down() => gamePad.IsButtonDown(Buttons.DPadDown);
        public bool Is_DPadUp_Down() => gamePad.IsButtonDown(Buttons.DPadUp);
        public bool Is_DPadLeft_Down() => gamePad.IsButtonDown(Buttons.DPadLeft);
        public bool Is_DPadRight_Down() => gamePad.IsButtonDown(Buttons.DPadRight);



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
    }
}
