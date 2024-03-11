using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NUnit.Framework;

namespace Test_ChristianTools
{
    public class Other_Test
    {
        [Test]
        public void GetSurroundingElements_Center()
        {
            int[,] map = new int[,]
            {
                { 1, 2, 3, 4, 5 },
                { 6, 7, 8, 9, 10 },
                { 11, 12, 13, 14, 15 },
                { 16, 17, 18, 19, 20 },
                { 21, 22, 23, 24, 25 }
            };

            int[,] expected = new int[,]
            {
                { 7, 8, 9 },
                { 12, 13, 14 },
                { 17, 18, 19 }
            };

            int[,] result = ChristianTools.Helpers.Other.GetSurroundingElements(map, new Point(2, 2));
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void GetSurroundingElements_TopLeft()
        {
            int[,] map = new int[,]
            {
                { 1, 2, 3, 4, 5 },
                { 6, 7, 8, 9, 10 },
                { 11, 12, 13, 14, 15 },
                { 16, 17, 18, 19, 20 },
                { 21, 22, 23, 24, 25 }
            };

            int[,] expected = new int[,]
            {
                { 0, 0, 0 },
                { 0, 1, 2 },
                { 0, 6, 7 }
            };

            int[,] result = ChristianTools.Helpers.Other.GetSurroundingElements(map, new Point(0, 0));
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void GetSurroundingElements_DownRight()
        {
            int[,] map = new int[,]
            {
                { 1, 2, 3, 4, 5 },
                { 6, 7, 8, 9, 10 },
                { 11, 12, 13, 14, 15 },
                { 16, 17, 18, 19, 20 },
                { 21, 22, 23, 24, 25 }
            };

            int[,] expected = new int[,]
            {
                { 19, 20, 0 },
                { 24, 25, 0 },
                { 0, 0, 0 }
            };

            int[,] result = ChristianTools.Helpers.Other.GetSurroundingElements(map, new Point(4, 4));
            Assert.AreEqual(result, expected);
        }
    }
}
