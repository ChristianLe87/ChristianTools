namespace ChristianTools.Helpers;

public static class GraphicTools
{
    public static void ChangeViewport(Rectangle newViewportRectangle)
    {
        Viewport newViewport = new Viewport();
        newViewport.Bounds = newViewportRectangle;
        
        if(ChristianGame.graphicsDeviceManager.GraphicsDevice != null)
            ChristianGame.graphicsDeviceManager.GraphicsDevice.Viewport = newViewport;

        // Update WK
        ChristianGame.WK.Viewport = newViewport.Bounds;
    }

    public static void ChangeGameWindow(int gameWindo_Width, int gameWindo_Height)
    {
        ChristianGame.WK.CanvasWidth = gameWindo_Width;
        ChristianGame.WK.CanvasHeight = gameWindo_Height;

        ChristianGame.graphicsDeviceManager.PreferredBackBufferWidth = ChristianGame.WK.CanvasWidth;
        ChristianGame.graphicsDeviceManager.PreferredBackBufferHeight = ChristianGame.WK.CanvasHeight;
        ChristianGame.graphicsDeviceManager.ApplyChanges();
    }
}