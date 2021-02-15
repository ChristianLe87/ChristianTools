using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using zTools;
using zUI;

namespace Showroom_dotNet5
{
    public class Scene_Lines : IScene
    {
        Line line_1;
        Button goToMenu;

        public Scene_Lines()
        {
            Initialize();
            goToMenu = new Button(
                            rectangle: new Rectangle(0, WK.Default.Height - 50, 100, 50),
                            text: "Menu",
                            defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                            mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                            spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                            fontColor: Color.Black,
                            ButtonID: "goToMenu"
            );
        }

        public void Initialize()
        {
            line_1 = new Line(new Point(WK.Default.Width / 2, WK.Default.Height / 2), new Point(0, 0), 5, Color.Red);
        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            if(mouseState.LeftButton == ButtonState.Pressed)
            {
                line_1.Update(end: new Point(mouseState.X, mouseState.Y));
            }

            goToMenu.Update(() => Game1.ChangeToScene(WK.Scene.Scene_Menu));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            line_1.Draw(spriteBatch);
            goToMenu.Draw(spriteBatch);
        }
    }

    public class Line
    {
        Texture2D texture2D;
        Rectangle[] rectangles;

        Point start;
        Point end;
        int thickness;

        public Line(Point start, Point end, int thickness, Color color)
        {
            this.start = start;
            this.end = end;
            this.thickness = thickness;
            this.texture2D = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, color);

            CreateLine();
        }

        void CreateLine()
        {
            int ammountOfRectanglesNeeded = Math.Abs((end.X - start.X) / thickness);
            this.rectangles = new Rectangle[ammountOfRectanglesNeeded];

            float m = Tools.MyMath.M(start.ToVector2(), end.ToVector2());
            float b = Tools.MyMath.B(start.X, start.Y, m);

            for (int i = 0; i < rectangles.Length; i++)
            {
                // check directoin
                int x;
                if (end.X - start.X > 0)
                    x = start.X + (thickness * i);
                else
                    x = end.X + (thickness * i);

                // y = mx +b
                float y = (m * x) + b;

                rectangles[i] = new Rectangle(x, (int)y, thickness, thickness);
            }
        }

        public void Update(Point? start = null, Point? end = null)
        {
            if (start != null) this.start = new Point(start.Value.X, start.Value.Y);
            if (end != null) this.end = new Point(end.Value.X, end.Value.Y);

            CreateLine();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var rectangle in rectangles)
            {
                spriteBatch.Draw(texture2D, rectangle, Color.White);
            }
        }
    }
}