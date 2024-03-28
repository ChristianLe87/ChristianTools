using System;
using System.Collections.Generic;
using System.Linq;
using ChristianTools.Helpers;
using ChristianTools.Prefabs;
using Microsoft.Xna.Framework;

namespace ChristianTools.Components
{
    public class Rigidbody
    {
        public double rotationDegree { get; set; }
        public Vector2 force { get; set; }
        public Rectangle rectangle { get; set; }
        public float gravity { get; set; }
        //public Vector2 friction { get; set; }


        public Rectangle GetRectangleUp(int steps) =>ChristianTools.Helpers.MyRectangle.GetRectangleUp(rectangle, steps);
        public Rectangle GetRectangleDown(int steps) => ChristianTools.Helpers.MyRectangle.GetRectangleDown(rectangle, steps);
        public Rectangle GetRectangleLeft(int steps) => ChristianTools.Helpers.MyRectangle.GetRectangleLeft(rectangle, steps);
        public Rectangle GetRectangleRight(int steps) => ChristianTools.Helpers.MyRectangle.GetRectangleRight(rectangle, steps);

        public List<Tile> tiles;
        public bool isGrounded => !CanMoveDown((int)gravity);

        public Rigidbody(Rectangle rectangle, Vector2 force = new Vector2(), float gravity = 0)
        {
            this.rotationDegree = 0;
            this.force = force;
            this.rectangle = rectangle;
            this.gravity = gravity;
            //this.friction = new Vector2(0, 0);
        }

        public void Update()
        {
            Point pointInMap = new Point(rectangle.Center.X / 16, rectangle.Center.Y / 16);
            Tile[,] surroundingElements = Other.GetSurroundingElements(ChristianGame.GetScene?.map?.mainTiles, pointInMap);
            this.tiles = ChristianTools.Helpers.Other.FlattenArray(surroundingElements).Where(x => x != null).ToList();

            
            Move_Y((int)force.Y);
            Move_X((int)force.X);

            Move_Y((int)gravity);
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
                if (CanMoveRight(Math.Abs(X)) == true)
                {
                    SetCenterPosition(new Point(rectangle.Center.X + X, rectangle.Center.Y));
                }
                else if (CanMoveRight(Math.Abs(X)) == false)
                {
                    Tile tileRight = tiles.FirstOrDefault(x => x.rectangle.Intersects(GetRectangleRight(Math.Abs(X))));
                    int dif = rectangle.Right - tileRight.rectangle.X;

                    dif = Math.Clamp(dif, 0, scFct); // fix a problem that jump on corners
                    SetCenterPosition(new Point(rectangle.Center.X - dif, rectangle.Center.Y));
                }
            }
            else if (X < 0)
            {
                if (CanMoveLeft(Math.Abs(X)) == true)
                {
                    SetCenterPosition(new Point(rectangle.Center.X + X, rectangle.Center.Y));
                }
                else if (CanMoveLeft(Math.Abs(X)) == false)
                {
                    Tile tileLeft = tiles.FirstOrDefault(x => x.rectangle.Intersects(GetRectangleLeft(Math.Abs(X))));
                    int dif = tileLeft.rectangle.Right - rectangle.X;

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
            if (Y > 0) // down
            {
                if (CanMoveDown(Math.Abs(Y)) == true)
                {
                    SetCenterPosition(new Point(rectangle.Center.X, rectangle.Center.Y + Y));
                }
                else if (CanMoveDown(Math.Abs(Y)) == false)
                {
                    Tile tileDown = tiles.Where(x => x.rectangle.Intersects(GetRectangleDown(Math.Abs(Y)))).FirstOrDefault();
                    int dif = rectangle.Bottom - tileDown.rectangle.Y;

                    //dif = Math.Clamp(dif, 0, Y); // fix a problem that jump on corners
                    SetCenterPosition(new Point(rectangle.Center.X, rectangle.Center.Y - dif));
                }
            }
            else if (Y < 0)
            {
                if (CanMoveUp(Math.Abs(Y)) == true)
                {
                    SetCenterPosition(new Point(rectangle.Center.X, rectangle.Center.Y + Y));
                }
                else if (CanMoveUp(Math.Abs(Y)) == false)
                {
                    Tile tileUp = tiles.FirstOrDefault(x => x.rectangle.Intersects(GetRectangleUp(Math.Abs(Y))));
                    int dif = tileUp.rectangle.Bottom - rectangle.Y;

                    //dif = Math.Clamp(dif, 0, Y); // fix a problem that jump on corners
                    SetCenterPosition(new Point(rectangle.Center.X, rectangle.Center.Y + dif));
                }
            }
        }

        public void SetCenterPosition(Point newCenterPosition)
        {
            rectangle = ChristianTools.Helpers.MyRectangle.CreateRectangle(newCenterPosition, rectangle.Width, rectangle.Height);
        }


        public bool CanMoveRight(int steps)
        {
            if (tiles == null)
                return true;

            int tilesRight = tiles.Count(x => x.rectangle.Intersects(GetRectangleRight(Math.Abs(steps))));
            return tilesRight == 0 ? true : false;
        }

        public bool CanMoveLeft(int steps)
        {
            if (tiles == null)
                return true;

            int tilesLeft = tiles.Count(x => x.rectangle.Intersects(GetRectangleLeft(Math.Abs(steps))));
            return tilesLeft == 0 ? true : false;
        }


        public bool CanMoveDown(int steps)
        {
            if (tiles == null)
                return true;

            int tilesDown = tiles.Count(x => x.rectangle.Intersects(GetRectangleDown(Math.Abs(steps))));

            if ((tilesDown == 0) == false)
            {
                int bla = 0;
            }
            return tilesDown == 0 ? true : false;
        }

        public bool CanMoveUp(int steps)
        {
            if (tiles == null)
                return true;

            int tilesUp = tiles.Count(x => x.rectangle.Intersects(GetRectangleUp(Math.Abs(steps))));
            return tilesUp == 0 ? true : false;
        }
    }
}