using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NUnit.Framework;

namespace Test_ChristianTools
{
    public class GetRectangle_Test
    {
        [Test]
        public void Test_Rectangle1()
        {
            /*
            Rectangle rectangle = ChristianTools.Helpers.MyRectangle.CreateRectangle(new Point(100, 120), 80, 70);

            if (rectangle.X == 60 && rectangle.Y == 85)
                Assert.Pass();
            else
                Assert.Fail();
                */
        }

        [Test]
        public void Test_Rectangle2()
        {
            Texture2D texture2D = null;
            //Rectangle rectangle = ChristianTools.Helpers.MyRectangle.CreateRectangle(new Point(50, 50), texture2D);

            Assert.Fail();
        }

        [Test]
        public void Test_RectangleUp()
        {
            Assert.Fail();
        }

        [Test]
        public void Test_RectangleDown()
        {
            Assert.Fail();
        }

        [Test]
        public void Test_RectangleRight()
        {
            Assert.Fail();
        }

        [Test]
        public void Test_RectangleLeft()
        {
            Assert.Fail();
        }

        [Test]
        public void Test_ScaleSides()
        {
            Assert.Fail();
        }
    }
}