using System;
using System.Collections.Generic;
using System.Linq;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;

namespace ChristianTools.Components
{
    public class Rigidbody : IRigidbody
    {
        public double rotationDegree { get; set; }
        public Vector2 force { get; set; }
        public Rectangle rectangle { get; set; }

        public Rectangle GetRectangleUp(int scaleFactor) =>ChristianTools.Helpers.MyRectangle.GetRectangleUp(rectangle, scaleFactor);
        public Rectangle GetRectangleDown(int scaleFactor) => ChristianTools.Helpers.MyRectangle.GetRectangleDown(rectangle, scaleFactor);
        public Rectangle GetRectangleLeft(int scaleFactor) => ChristianTools.Helpers.MyRectangle.GetRectangleLeft(rectangle, scaleFactor);
        public Rectangle GetRectangleRight(int scaleFactor) => ChristianTools.Helpers.MyRectangle.GetRectangleRight(rectangle, scaleFactor);

        private List<Tile> tiles;
        private Tile[,] surroundingElements;
        private int scaleFactor = 2;
        //public bool isGrounded => Other.GetRow(surroundingElements, 2).Where(x => x != null).Where(x => x.rigidbody.rectangle.Intersects(GetRectangleDown)).Count() > 0;

        public Rigidbody(Rectangle rectangle, Vector2 force = new Vector2())
        {
            this.rotationDegree = 0;
            this.force = force;
            this.rectangle = rectangle;
        }

        public void Update()
        {
            //Point pointInMap = new Point(rectangle.Center.X / 16, rectangle.Center.Y / 16);
            //this.surroundingElements = Other.GetSurroundingElements(ChristianGame.GetScene?.map?.mainTiles, pointInMap);
            this.tiles = ChristianTools.Helpers.Other.FlattenArray(ChristianGame.GetScene.map.mainTiles).Where(x => x != null).ToList();

            Move_Y((int)force.Y);
            Move_X((int)force.X);
        }



        /// <summary>
        /// Move on X, if tiles, dont move
        /// </summary>
        /// <param name="X"></param>
        public void Move_X(int X)
        {
            int scFct = (int)Math.Abs(X);

            if (X > 0) // Right
            {
                if (CanMoveRight(scFct) == true)
                {
                    SetCenterPosition(new Point( rectangle.Center.X + X, rectangle.Center.Y));
                }
                else if (CanMoveRight(scFct) == false)
                {
                    Tile tileRight = tiles.FirstOrDefault(x => x.rigidbody.GetRectangleLeft(scFct).Intersects(rectangle));
                    int dif = rectangle.Right - tileRight.rigidbody.rectangle.X;

                    dif = Math.Clamp(dif, 0, scFct); // fix a problem that jump on corners
                    SetCenterPosition(new Point(rectangle.Center.X - dif, rectangle.Center.Y));
                }
            }
            else if (X < 0)
            {
                if (CanMoveLeft(scFct) == true)
                {
                    SetCenterPosition(new Point(rectangle.Center.X + X, rectangle.Center.Y));
                }
                else if (CanMoveLeft(scFct) == false)
                {
                    Tile tileLeft = tiles.FirstOrDefault(x => x.rigidbody.GetRectangleRight(scFct).Intersects(rectangle));
                    int dif = tileLeft.rigidbody.rectangle.Right - rectangle.X;

                    dif = Math.Clamp(dif, 0, scFct); // fix a problem that jump on corners
                    SetCenterPosition(new Point(rectangle.Center.X + dif, rectangle.Center.Y));
                }
            }
        }

        /// <summary>
        /// Move on Y, if tiles, dont move
        /// </summary>
        /// <param name="Y"></param>
        public void Move_Y(int Y)
        {
            int scFct = (int)Math.Abs(Y);

            if (Y > 0) // down
            {
                if (CanMoveDown(scFct) == true)
                {
                    SetCenterPosition(new Point(rectangle.Center.X, rectangle.Center.Y + Y));
                }
                else if (CanMoveDown(scFct) == false)
                {
                    Tile tileDown = tiles.FirstOrDefault(x => x.rigidbody.GetRectangleUp(scFct).Intersects(rectangle));
                    int dif = rectangle.Bottom - tileDown.rigidbody.rectangle.Y;

                    dif = Math.Clamp(dif, 0, scFct); // fix a problem that jump on corners
                    SetCenterPosition(new Point(rectangle.Center.X, rectangle.Center.Y - dif));
                }
            }
            else if (Y < 0)
            {
                if (CanMoveUp(scFct) == true)
                {
                    SetCenterPosition(new Point(rectangle.Center.X, rectangle.Center.Y + Y));
                }
                else if (CanMoveUp(scFct) == false)
                {
                    Tile tileUp = tiles.FirstOrDefault(x => x.rigidbody.GetRectangleDown(scFct).Intersects(rectangle));
                    int dif = tileUp.rigidbody.rectangle.Bottom - rectangle.Y;

                    dif = Math.Clamp(dif, 0, scFct); // fix a problem that jump on corners
                    SetCenterPosition(new Point(rectangle.Center.X, rectangle.Center.Y + dif));
                }
            }
        }

        public void SetCenterPosition(Point newCenterPosition)
        {
            rectangle = ChristianTools.Helpers.MyRectangle.CreateRectangle(newCenterPosition, rectangle.Width, rectangle.Height);
        }


        public bool CanMoveRight(int scaleFactor)
        {
            if (tiles == null)
                return true;

            int tilesRight = tiles.Count(x => x.rigidbody.GetRectangleLeft(scaleFactor).Intersects(rectangle));
            return tilesRight == 0 ? true : false;
        }

        public bool CanMoveLeft(int scaleFactor)
        {
            if (tiles == null)
                return true;

            int tilesLeft = tiles.Count(x => x.rigidbody.GetRectangleRight(scaleFactor).Intersects(rectangle));
            return tilesLeft == 0 ? true : false;
        }


        public bool CanMoveDown(int scaleFactor)
        {
            if (tiles == null)
                return true;

            int tilesDown = tiles.Count(x => x.rigidbody.GetRectangleUp(scaleFactor).Intersects(rectangle));
            return tilesDown == 0 ? true : false;
        }

        public bool CanMoveUp(int scaleFactor)
        {
            if (tiles == null)
                return true;

            int tilesUp = tiles.Count(x => x.rigidbody.GetRectangleDown(scaleFactor).Intersects(rectangle));
            return tilesUp == 0 ? true : false;
        }
    }
}