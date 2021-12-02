using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace My_EasyTests
{
    public class Scene_1 : IScene
    {
        Rigidbody rigidbody;
        Animation animation;

        public Scene_1()
        {
            int canvasWidth = 500;
            int canvasHeight = 500;

            Vector2 position = new Vector2(canvasWidth / 2, canvasHeight / 2);
            Texture2D texture2D = Tools.Texture.CreateTriangle(Game1.graphicsDeviceManager.GraphicsDevice, Color.Pink, 100, 100, Tools.Texture.PointDirection.Right);

            this.animation = new Animation(texture2D);
            this.rigidbody = new Rigidbody(position, texture2D.Width, texture2D.Height);
        }

        public void Update()
        {
            InputState inputState = new InputState();

            // Mouse
            {
                double angleInRadians = Tools.MyMath.GetAngleInRadians(
                    Point1_Start: rigidbody.centerPosition,
                    Point1_End: new Vector2(rigidbody.centerPosition.X + 250, rigidbody.centerPosition.Y),
                    Point2_Start: rigidbody.centerPosition,
                    Point2_End: inputState.Mouse_Position().ToVector2()
                );

                rigidbody.SetAngleRotation((float)Tools.MyMath.RadianToDegree(angleInRadians));
            }


            // Keyboard
            {
                int move = 1;

                if (inputState.Left)
                    rigidbody.Move_X(-move);
                else if (inputState.Right)
                    rigidbody.Move_X(move);

                if (inputState.Up)
                    rigidbody.Move_Y(-move);
                else if (inputState.Down)
                    rigidbody.Move_Y(move);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
               texture: animation.GetTexture(),
               destinationRectangle: new Rectangle((int)rigidbody.centerPosition.X, (int)rigidbody.centerPosition.Y, rigidbody.rectangle.Width, rigidbody.rectangle.Height),
               sourceRectangle: null,
               color: Color.White,
               rotation: (float)Tools.MyMath.DegreeToRadian(rigidbody.rotationDegree),// always value radians
               origin: new Vector2(rigidbody.rectangle.Width / 2, rigidbody.rectangle.Height / 2),
               effects: SpriteEffects.None,
               layerDepth: 0f
           );
        }
    }
}