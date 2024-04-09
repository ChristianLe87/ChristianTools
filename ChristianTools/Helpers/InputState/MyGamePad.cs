namespace ChristianTools.Helpers
{
    public class MyGamePad
    {
        private GamePadState gamePadState { get; }

        public MyGamePad()
        {
            // Check the device for Player One: GamePadCapabilities gamePadCapabilities = GamePad.GetCapabilities(PlayerIndex.One);
            this.gamePadState = (OperatingSystem.IsIOS() || OperatingSystem.IsAndroid()) ? new GamePadState() : GamePad.GetState(PlayerIndex.One);
        }

        public bool IsButtonDown(Buttons button) => gamePadState.IsButtonDown(button);
        public bool IsButtonUp(Buttons button) => gamePadState.IsButtonUp(button);

        public bool IsThumbSticksUp => gamePadState.ThumbSticks.Left.Y > 0;
        public bool IsThumbSticksDown => gamePadState.ThumbSticks.Left.Y < 0;
        public bool IsThumbSticksLeft => gamePadState.ThumbSticks.Left.X < 0;
        public bool IsThumbSticksRight => gamePadState.ThumbSticks.Left.X > 0;
    }
}
