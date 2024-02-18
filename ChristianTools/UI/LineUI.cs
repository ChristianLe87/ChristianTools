using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.UI
{
    public class LineUI : IUI
    {
        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }
        public bool isActive { get; }

        private ChristianTools.Entities.Line line;

        private Point originalStart;
        private Point originalEnd;

        public LineUI(Point start, Point end, Color color, int thickness = 5, string tag = "")
        {
            this.line = new ChristianTools.Entities.Line(start: start, end: end, color: color, thickness: thickness, tag: tag);

            this.originalStart = start;
            this.originalEnd = end;

            this.dxDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
        }

        private void DrawSystem(SpriteBatch spriteBatch)
        {
            Point newStart = new Point();
            Point newEnd = new Point();

            Rectangle viewport = new Rectangle();
            
            
            if (ChristianGame.scenes[ChristianGame.actualScene].camera != null)
                viewport = ChristianGame.scenes[ChristianGame.actualScene].camera.cameraView;
            else
                viewport = ChristianGame.graphicsDeviceManager.GraphicsDevice.Viewport.Bounds;

            
            newStart = new Point(originalStart.X + viewport.X, originalStart.Y + viewport.Y);
            newEnd = new Point(originalEnd.X + viewport.X, originalEnd.Y + viewport.Y);
            
            
            this.line.UpdatePoints(start: newStart, end: newEnd);
            this.line.dxDrawSystem(spriteBatch);
        }

    }
}