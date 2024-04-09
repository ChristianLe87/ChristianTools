namespace ChristianTools.Helpers
{
    public class MyTouch
    {
        public MyTouch()
        {
        }

        private static Point lastTouch = new Point();
        public Point GetOnWindowTouch()
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
        
        public Point GetOnWorldTouch()
        {
            TouchCollection touchCollection = TouchPanel.GetState();
            
            if (touchCollection.Count > 0)
            {
                //Only Fire Select Once it's been released
                if (touchCollection[0].State == TouchLocationState.Moved || touchCollection[0].State == TouchLocationState.Pressed)
                {
                    lastTouch = touchCollection[0].Position.ToPoint();
                    lastTouch -= new Point((int)ChristianGame.GetScene.camera.cameraCenterPosition.X, (int)ChristianGame.GetScene.camera.cameraCenterPosition.Y);
                    return lastTouch;
                }
            }

            return lastTouch;
        }
        

        public bool IsTouchDown() => TouchPanel.GetState().Count > 0;
    }
}
