using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using zTools;
using zWorldElements;

namespace zAssets
{
    public class Player
    {
        Point centerPoint;
        Texture2D texture2D;
        Rectangle rectangle { get => new Rectangle().Create(centerPoint, texture2D); }

        Rectangle rectangleUp { get => new Rectangle(x: rectangle.X + 1, y: rectangle.Y, width: (rectangle.Right - 1) - (rectangle.X + 1), height: 1); }
        Rectangle rectangleDown { get => new Rectangle(x: rectangle.X + 1, y: rectangle.Bottom, width: (rectangle.Right - 1) - (rectangle.X + 1), height: 1); }
        Rectangle rectangleRight { get => new Rectangle(x: rectangle.Right, y: rectangle.Y + 1, width: 1, height: (rectangle.Bottom - 1) - (rectangle.Y + 1)); }
        Rectangle rectangleLeft { get => new Rectangle(x: rectangle.X - 1, y: rectangle.Y, width: 1, height: (rectangle.Bottom - 1) - (rectangle.Y + 1)); }

        public Player(Point centerPoint, Texture2D texture2D)
        {
            this.centerPoint = centerPoint;
            this.texture2D = texture2D;
        }

        public void Update(KeyboardState keyboardState, GamePadState gamePadState, List<IWorldElement> worldElements)
        {
            Move(keyboardState, gamePadState, worldElements);
            ApplyGravity(worldElements);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }

        int moveSpeed { get => 2; }
        private void Move(KeyboardState keyboardState, GamePadState gamePadState, List<IWorldElement> worldElements)
        {
            // Move Right
            if (keyboardState.IsKeyDown(Keys.D) || gamePadState.ThumbSticks.Left.X > 0f)
            {
                IWorldElement firstRightIntersectElement = worldElements.Where(x => x.rectangle.Intersects(rectangleRight)).FirstOrDefault();

                // if no tiles right
                if (firstRightIntersectElement == null)
                {
                    centerPoint.X += moveSpeed;
                }
            }

            // Move Left
            else if (keyboardState.IsKeyDown(Keys.A) || gamePadState.ThumbSticks.Left.X < 0f)
            {
                IWorldElement firstLeftIntersectElement = worldElements.Where(x => x.rectangle.Intersects(rectangleLeft)).FirstOrDefault();

                // if no tiles left
                if (firstLeftIntersectElement == null)
                {
                    centerPoint.X -= moveSpeed;
                }
            }
        }

        int gravitySpeed { get => 3; }
        private void ApplyGravity(List<IWorldElement> worldElements)
        {
            IWorldElement firstDownIntersectTile = worldElements.Where(x => x.rectangle.Intersects(rectangleDown)).FirstOrDefault();

            // if no tiles down
            if (firstDownIntersectTile == null)
            {
                centerPoint.Y += gravitySpeed;
            }

            // fix offset
            if (firstDownIntersectTile != null)
            {
                centerPoint.Y -= Rectangle.Intersect(rectangle, firstDownIntersectTile.rectangle).Height;
            }
        }
    }
}
