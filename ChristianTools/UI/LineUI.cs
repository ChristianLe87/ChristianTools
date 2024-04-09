namespace ChristianTools.UI
{
    public class LineUI : ChristianTools.Helpers.Hybrids.Line, IUI
    {
        public LineUI(Point start, Point end, Color color, int thickness = 5, string tag = "") : base(start, end, color, thickness, tag)
        {
        }
    }
}