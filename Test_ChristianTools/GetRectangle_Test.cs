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
            Rectangle rectangle = ChristianTools.Helpers.MyRectangle.CreateRectangle(new Point(100, 120), 80, 70);

            if (rectangle.X == 60 && rectangle.Y == 85)
                Assert.Pass();
            else
                Assert.Fail();
                
        }

        //[Test]
        public void Test_Rectangle2()
        {
            Texture2D texture2D = null;
            //Rectangle rectangle = ChristianTools.Helpers.MyRectangle.CreateRectangle(new Point(50, 50), texture2D.Width, texture2D.Height);

            Assert.Fail();
        }

        [Test]
        public void Test_RectangleUp()
        {
            Rectangle rectangle = new Rectangle(-25, -25, 50, 50);
            int height = 1;
            Rectangle result = ChristianTools.Helpers.MyRectangle.GetRectangleUp(rectangle, height);

            Rectangle expectedResult = new Rectangle(rectangle.X, rectangle.Y-height, rectangle.Width, height);
            
            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void Test_RectangleDown()
        {
            Rectangle rectangle = new Rectangle(-25, -25, 50, 50);
            int height = 1;
            Rectangle result = ChristianTools.Helpers.MyRectangle.GetRectangleDown(rectangle, height);

            Rectangle expectedResult = new Rectangle(rectangle.X, rectangle.Bottom, rectangle.Width, height);
            
            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void Test_RectangleRight()
        {
            Rectangle rectangle = new Rectangle(-25, -25, 50, 50);
            int width = 1;
            Rectangle result = ChristianTools.Helpers.MyRectangle.GetRectangleRight(rectangle, width);

            Rectangle expectedResult = new Rectangle(rectangle.Right, rectangle.Top, width, rectangle.Width);
            
            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void Test_RectangleLeft()
        {
            Rectangle rectangle = new Rectangle(-25, -25, 50, 50);
            int width = 1;
            Rectangle result = ChristianTools.Helpers.MyRectangle.GetRectangleLeft(rectangle, width);

            Rectangle expectedResult = new Rectangle(rectangle.X-width, rectangle.Y, width, rectangle.Width);
            
            Assert.AreEqual(result, expectedResult);
        }

        //[Test]
        public void Test_ScaleSides()
        {
            Assert.Fail();
        }
    }
}