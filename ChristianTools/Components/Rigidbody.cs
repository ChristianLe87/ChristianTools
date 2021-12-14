using System;
using System.Collections.Generic;
using System.Linq;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;

namespace ChristianTools.Components
{
    public class Rigidbody
    {
        public float rotationDegree { get; set; }
        // public void SetPosition(Vector2 position) => centerPosition = position;

        public Vector2 force { get; set; }
        public float SetForce_X { set => force = new Vector2(value, force.Y); }
        public float SetForce_Y { set => force = new Vector2(force.X, value); }

        public Vector2 centerPosition { get; private set; }
        public Vector2 SetCenterPosition { set => centerPosition = value; }


        public Rectangle rectangle
        {
            get => Tools.Tools.GetRectangle.Rectangle(
                centerPosition: centerPosition,
                Width: (entity?.animation.GetTexture(entity.characterState).Width ?? baseRectangle.Width),
                Height: (entity?.animation.GetTexture(entity.characterState).Height ?? baseRectangle.Height)
            );
        }

        public Rectangle rectangleUp(int scaleFactor) => Tools.Tools.GetRectangle.Up(rectangle, scaleFactor);
        public Rectangle rectangleDown(int scaleFactor) => Tools.Tools.GetRectangle.Down(rectangle, scaleFactor);
        public Rectangle rectangleLeft(int scaleFactor) => Tools.Tools.GetRectangle.Left(rectangle, scaleFactor);
        public Rectangle rectangleRight(int scaleFactor) => Tools.Tools.GetRectangle.Right(rectangle, scaleFactor);

        public Rectangle rectangleScaled(int scaleFactor) => Tools.Tools.GetRectangle.ScaleSides(rectangle, scaleFactor);

        public bool isGrounded { get; private set; }

        IEntity entity;
        public Rigidbody(Vector2 centerPosition, IEntity entity, Vector2? force = null)
        {
            this.entity = entity;
            this.force = force == null ? Vector2.Zero : force.Value;
            this.centerPosition = centerPosition;
            this.isGrounded = false;
        }

        Rectangle baseRectangle;
        public Rigidbody(Rectangle rectangle, Vector2? force = null)
        {
            this.baseRectangle = rectangle;
            this.force = force == null ? Vector2.Zero : force.Value;
            this.centerPosition = rectangle.Center.ToVector2();
            this.isGrounded = false;
        }


        List<Tile> intersectTiles;
        public void Update(List<Tile> intersectTiles = null)
        {
            if (intersectTiles != null)
                this.intersectTiles = intersectTiles;


            //Move_Y(force.Y);
            centerPosition += force;
        }

        
        public void Move_X(float X)
        {
            int scFct = (int)Math.Abs(X);

            if (X > 0) // Right
            {
                if (CanMoveRight() == true)
                {
                    centerPosition = new Vector2(centerPosition.X + X, centerPosition.Y);
                }
                else if (CanMoveRight() == false)
                {
                    Tile tileRight = this.intersectTiles.Where(x => x.rigidbody.rectangleLeft(scFct).Intersects(rectangle)).FirstOrDefault();
                    int dif = rectangle.Right - tileRight.rigidbody.rectangle.X;
                    centerPosition = new Vector2(centerPosition.X - dif, centerPosition.Y);
                }
            }
            else if (X < 0)
            {
                if (CanMoveLeft() == true)
                {
                    centerPosition = new Vector2(centerPosition.X + X, centerPosition.Y);
                }
                else if (CanMoveLeft() == false)
                {
                    Tile tileLeft = this.intersectTiles.Where(x => x.rigidbody.rectangleRight(scFct).Intersects(rectangle)).FirstOrDefault();
                    int dif = tileLeft.rigidbody.rectangle.Right - rectangle.X;
                    centerPosition = new Vector2(centerPosition.X + dif, centerPosition.Y);
                }
            }

            bool CanMoveRight()
            {
                Tile tileRight = this.intersectTiles.Where(x => x.rigidbody.rectangleLeft(scFct).Intersects(rectangle)).FirstOrDefault();
                return tileRight == null ? true : false;
            }

            bool CanMoveLeft()
            {
                Tile tileLeft = this.intersectTiles.Where(x => x.rigidbody.rectangleRight(scFct).Intersects(rectangle)).FirstOrDefault();
                return tileLeft == null ? true : false;
            }
        }


        public void Move_Y(float Y)
        {
            int scFct = (int)Math.Abs(Y);

            if (Y > 0) // down
            {
                if (CanMoveDown() == true)
                {
                    centerPosition = new Vector2(centerPosition.X, centerPosition.Y + Y);
                }
                else if (CanMoveDown() == false)
                {
                    Tile tileDown = this.intersectTiles.Where(x => x.rigidbody.rectangleUp(scFct).Intersects(rectangle)).FirstOrDefault();
                    int dif = rectangle.Bottom - tileDown.rigidbody.rectangle.Y;

                    dif = Math.Clamp(dif, 0, scFct * 2); // fix a problem that jump on corners
                    centerPosition = new Vector2(centerPosition.X, centerPosition.Y - dif);
                }
            }
            else if (Y < 0)
            {
                if (CanMoveUp() == true)
                {
                    centerPosition = new Vector2(centerPosition.X, centerPosition.Y + Y);
                }
                else if (CanMoveUp() == false)
                {
                    Tile tileUp = this.intersectTiles.Where(x => x.rigidbody.rectangleDown(scFct).Intersects(rectangle)).FirstOrDefault();
                    int dif = tileUp.rigidbody.rectangle.Bottom - rectangle.Y;

                    dif = Math.Clamp(dif, 0, scFct * 2); // fix a problem that jump on corners
                    centerPosition = new Vector2(centerPosition.X, centerPosition.Y + dif);
                }
            }

            bool CanMoveDown()
            {
                Tile tileDown = this.intersectTiles.Where(x => x.rigidbody.rectangleUp(scFct).Intersects(rectangle)).FirstOrDefault();
                return tileDown == null ? true : false;
            }

            bool CanMoveUp()
            {
                Tile tileUp = this.intersectTiles.Where(x => x.rigidbody.rectangleDown(scFct).Intersects(rectangle)).FirstOrDefault();
                return tileUp == null ? true : false;
            }
        }
    }
}