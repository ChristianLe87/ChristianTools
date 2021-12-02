using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace My_EasyTests
{
    public class Scene_1 : IScene
    {
        Texture2D texture2D;
        float rotationAngleInRadians = 45f;
        int canvasWidth = 500;
        int canvasHeight = 500;

        Rectangle rectangle;
        Vector2 position;

        public Scene_1()
        {
            this.texture2D = Tools.Texture.CreateTriangle(Game1.graphicsDeviceManager.GraphicsDevice, Color.Pink, 100, 100, Tools.Texture.PointDirection.Right);
            this.rectangle = Tools.GetRectangle.Rectangle(new Vector2(canvasWidth / 2, canvasHeight / 2), texture2D.Width, texture2D.Height);

            this.position = new Vector2(canvasWidth/2, canvasHeight/2);
        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            Point mousePosition = mouseState.Position;

            double angleInRadians = Tools.MyMath.GetAngleInRadians(
                Point1_Start: position,
                Point1_End: new Vector2(500, 250),
                Point2_Start: position,
                Point2_End: mousePosition.ToVector2()
            );

            rotationAngleInRadians = (float)angleInRadians;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
               texture: texture2D,
               destinationRectangle: new Rectangle(canvasWidth / 2, canvasHeight / 2, texture2D.Width, texture2D.Height),
               sourceRectangle: null,
               color: Color.White,
               rotation: rotationAngleInRadians,
               origin: new Vector2(texture2D.Width / 2, texture2D.Height / 2),
               effects: SpriteEffects.None,
               layerDepth: 0f
           );
        }
    }
}