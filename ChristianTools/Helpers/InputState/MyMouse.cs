
namespace ChristianTools.Helpers
{
    public class MyMouse
    {
        private MouseState mouseState;

        public MyMouse()
        {
            this.mouseState = Mouse.GetState();
        }
        
        
        //public Point Mouse_Position => mouseState.Position;
        public Point GetOnWorldPosition()
        {
            if (ChristianGame.GetScene.camera != null)
            {
                Point point = mouseState.Position;
                point -= new Point((int)ChristianGame.GetScene.camera.cameraCenterPosition.X, (int)ChristianGame.GetScene.camera.cameraCenterPosition.Y);
                point -= new Point(ChristianGame.WK.Viewport.X, ChristianGame.WK.Viewport.Y);
                
                return point;
            }
            else
            {
                return mouseState.Position;
            }
        }
        
        public Point GetOnWindowPosition()
        {
            return mouseState.Position - new Point((int)ChristianGame.graphicsDeviceManager.GraphicsDevice.Viewport.X, (int)ChristianGame.graphicsDeviceManager.GraphicsDevice.Viewport.Y);
        }
        
        //public ButtonState Mouse_LeftButton => mouseState.LeftButton;
        //public ButtonState Mouse_RightButton => mouseState.RightButton;
        public bool IsLeftButton_Click => mouseState.LeftButton == ButtonState.Pressed;
        public bool IsRightButton_Click => mouseState.RightButton == ButtonState.Pressed;
    }
}