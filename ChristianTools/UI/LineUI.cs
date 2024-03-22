using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.UI
{
    public class LineUI : IUI
    {
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
        public bool isActive { get; }

        private ChristianTools.Entities.Line line;

        private Point originalStart;
        private Point originalEnd;

        public LineUI(Point start, Point end, Color color, int thickness = 5, string tag = "")
        {
            this.line = new ChristianTools.Entities.Line(start: start, end: end, color: color, thickness: thickness, tag: tag);

            this.originalStart = start;
            this.originalEnd = end;

            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
        }

        private void DrawSystem(SpriteBatch spriteBatch)
        {
            // ToDo: research this
            Point newStart = new Point();
            Point newEnd = new Point();

            newStart = new Point(originalStart.X , originalStart.Y );
            newEnd = new Point(originalEnd.X , originalEnd.Y );


            // ToDo: reserch why this update on a Draw function
            this.line.UpdatePoints(start: newStart, end: newEnd);
            this.line.dxCustomDrawSystem(spriteBatch);
        }
    }
}