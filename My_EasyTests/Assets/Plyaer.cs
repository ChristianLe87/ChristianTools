using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace My_EasyTests
{
    public class Player
    {
        Texture2D texture2D;
        Rectangle rectangle;
        float layer = 0.1f;


        public Player()
        {
            texture2D = Tools.CreateColorTexture(
                graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                color: Color.Pink);

            rectangle = new Rectangle(250, 250, 20, 20);
        }

        public void Update()
        {
            // ===== Implementation =====
            {
                Vector2 oldPosition = new Vector2(rectangle.X, rectangle.Y);
                Vector2 newPosition = MovePlayer(oldPosition, 100, 100, 2);
                rectangle = new Rectangle((int)newPosition.X, (int)newPosition.Y, rectangle.Width, rectangle.Height);
            }

            // ===== Helpers =====
            Vector2 MovePlayer(Vector2 position, int minPosition, int maxPosition, int moveSpeed)
            {
                KeyboardState keyboardState = Keyboard.GetState();

                if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
                {
                    position.X -= moveSpeed;
                }
                else if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
                {
                    position.X += moveSpeed;
                }
                else if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
                {
                    position.Y -= moveSpeed;
                }
                else if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
                {
                    position.Y += moveSpeed;
                }

                return position;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture2D, rectangle, Color.White);
            spriteBatch.Draw(texture2D, new Vector2(rectangle.X, rectangle.Y), rectangle, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, layer);
        }
    }
}
