using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace zTopView_RPG
{
    public class Player:IEntity
    {
        Texture2D texture2D;
        float layer = 0.1f;


        public Rigidbody rigidbody { get; }

        public bool isActive => throw new System.NotImplementedException();

        public string tag => throw new System.NotImplementedException();

        public int health => throw new System.NotImplementedException();

        public Player(Texture2D texture2D)
        {
            this.texture2D = texture2D;
            
            this.rigidbody = new Rigidbody(new Vector2(250, 250), 20, 20);
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            // ===== Implementation =====
            {
                Vector2 oldPosition = rigidbody.centerPosition;
                Vector2 newPosition = MovePlayer(oldPosition, 100, 100, 2);
                rigidbody.centerPosition = newPosition;
            }

            // ===== Helpers =====
            Vector2 MovePlayer(Vector2 position, int minPosition, int maxPosition, int moveSpeed)
            {
                if (inputState.Left)
                {
                    position.X -= moveSpeed;
                }
                else if (inputState.Right)
                {
                    position.X += moveSpeed;
                }
                else if (inputState.Up)
                {
                    position.Y -= moveSpeed;
                }
                else if (inputState.Down)
                {
                    position.Y += moveSpeed;
                }

                return position;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, rigidbody.centerPosition, rigidbody.rectangle, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, layer);
        }
    }
}
