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

        public void Update(InputState inputState, InputState lastInputState, List<IWorldElement> worldElements)
        {
            Move(inputState, worldElements);
            ApplyGravity(worldElements);
            Jump(inputState, lastInputState, worldElements);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }

        int moveSpeed { get => 2; }
        private void Move(InputState inputState, List<IWorldElement> worldElements)
        {
            // Move Right
            if (inputState.Right)
            {
                IWorldElement firstRightIntersectTile = worldElements.Where(x => x.rectangle.Intersects(rectangleRight)).FirstOrDefault();

                // if no tiles right
                if (firstRightIntersectTile == null)
                {
                    centerPoint.X += isJumping ? moveSpeed : 1;
                }
            }

            // Move Left
            else if (inputState.Left)
            {
                IWorldElement firstLeftIntersectTile = worldElements.Where(x => x.rectangle.Intersects(rectangleLeft)).FirstOrDefault();

                // if no tiles left
                if (firstLeftIntersectTile == null)
                {
                    centerPoint.X -= isJumping ? moveSpeed : 1;
                }
            }
        }

        int gravitySpeed { get => 3; }
        private void ApplyGravity(List<IWorldElement> worldElements)
        {
            IWorldElement firstDownIntersectTile = worldElements.Where(x => x.rectangle.Intersects(rectangleDown)).FirstOrDefault();

            // if no tiles down
            if (firstDownIntersectTile == null && isJumping == false)
            {
                centerPoint.Y += gravitySpeed;
            }

            // fix offset
            if (firstDownIntersectTile != null)
            {
                centerPoint.Y -= Rectangle.Intersect(rectangle, firstDownIntersectTile.rectangle).Height;
            }
        }

        bool isJumping;
        int jumpTargetPosition_Y;
        int jumpHeight { get => /*WK.Default.Pixels_Y*/16 * 3; }
        int jumpSpeed { get => 3; }
        int framesOfFlightCount;
        int framesOfFlight { get => 2; }
        private void Jump(InputState inputState, InputState lastInputState, List<IWorldElement> worldElements)
        {
            if (inputState.Jump && lastInputState.NotJump)
            {
                IWorldElement firstDownIntersectTile = worldElements.Where(x => x.rectangle.Intersects(rectangleDown)).FirstOrDefault();

                if (firstDownIntersectTile != null && rectangleDown.Intersects(firstDownIntersectTile.rectangle))
                {
                    isJumping = true;
                    jumpTargetPosition_Y = centerPoint.Y - jumpHeight;
                }
            }

            if (isJumping)
            {
                IWorldElement firstTopIntersectTile = worldElements.Where(x => x.rectangle.Intersects(rectangleUp)).FirstOrDefault();

                if (firstTopIntersectTile == null)
                {
                    if (centerPoint.Y > jumpTargetPosition_Y)
                    {
                        centerPoint.Y -= jumpSpeed;
                    }
                    else
                    {
                        if (framesOfFlightCount > framesOfFlight)
                        {
                            isJumping = false;
                            framesOfFlightCount = 0;
                        }
                        else
                        {
                            framesOfFlightCount++;
                        }
                    }
                }
                else
                {
                    isJumping = false;
                    framesOfFlightCount = 0;
                }
            }
        }
    }
}