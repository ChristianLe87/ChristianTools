namespace ChristianTools.Entities
{
    public class Line : ChristianTools.Helpers.Hybrids.Line, IEntity
    {
        public Line(Point start, Point end, Color color, int thickness = 5, string tag = "") : base(start, end, color, thickness, tag)
        {
        }
    }
}