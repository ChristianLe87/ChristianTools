using System;
using Microsoft.Xna.Framework;

namespace ChristianTools.Components
{
    public class Shadow
    {
        public static Color Shadow_0 { get; } = new Color(Color.Black, byte.MinValue);
        public static Color Shadow_10 { get; } = new Color(Color.Black, byte.MaxValue / 10);
        public static Color Shadow_25 { get; } = new Color(Color.Black, byte.MaxValue * 1/4);
        public static Color Shadow_50 { get; } = new Color(Color.Black, byte.MaxValue * 1/2);
        public static Color Shadow_75 { get; } = new Color(Color.Black, byte.MaxValue * 3/4);
        public static Color Shadow_100 { get; } = new Color(Color.Black, byte.MaxValue);
    }
}