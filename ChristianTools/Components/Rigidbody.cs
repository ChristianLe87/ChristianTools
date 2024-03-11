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
        public Rectangle GetRectangleUp => MyRectangle.GetRectangleUp(rectangle, 3);
        public Rectangle GetRectangleDown => MyRectangle.GetRectangleDown(rectangle, 3);
        public Rectangle GetRectangleLeft => MyRectangle.GetRectangleLeft(rectangle, 3);
        public Rectangle GetRectangleRight => MyRectangle.GetRectangleRight(rectangle, 3);

        public Rigidbody(Rectangle rectangle, Vector2 force = new Vector2())
        {
            this.rotationDegree = 0;
            this.force = force;
            this.rectangle = rectangle;
        }

        public void Update()
        {
            // Force
            {
                if (force.X > 0 && CanMoveRight())
                    Move_X((int)force.X);
                else if (force.X < 0 && CanMoveLeft())
                    Move_X((int)force.X);


                if (force.Y > 0 && CanMoveDown())
                    Move_Y((int)force.Y);
                else if (force.Y < 0 && CanMoveUp())
                    Move_Y((int)force.Y);
            }

            // Clamp
            {
                if (CanMoveUp() == false)
                    ClampUp();
                
                if (CanMoveDown() == false)
                    ClampDown();
                
                if(CanMoveRight() == false)
                    ClampRight();
                
                if (CanMoveLeft() == false)
                    ClampLeft();
            }
        }

        public void Move_X(int X)
        {
            rectangle = ChristianTools.Helpers.MyRectangle.MoveRectangle_X(rectangle, X);
        }

        public void Move_Y(int Y)
        {
            rectangle = ChristianTools.Helpers.MyRectangle.MoveRectangle_Y(rectangle, Y);
        }

        public void SetCenterPosition(Point newCenterPosition)
        {
            rectangle = ChristianTools.Helpers.MyRectangle.CreateRectangle(newCenterPosition, rectangle.Width, rectangle.Height);
        }

        private bool CanMoveDown()
        {
            Tile[,] mainTiles = ChristianGame.GetScene.map?.mainTiles ?? new Tile[,] { };
            int tileIndex = rectangle.X / 16;

            List<Tile> tiles_before = FilterTiles(ChristianTools.Helpers.Other.GetColumn(mainTiles, tileIndex - 1));
            List<Tile> tiles_middl = FilterTiles(ChristianTools.Helpers.Other.GetColumn(mainTiles, tileIndex));
            List<Tile> tiles_after = FilterTiles(ChristianTools.Helpers.Other.GetColumn(mainTiles, tileIndex + 1));

            return tiles_before.Count == 0 && tiles_middl.Count == 0 && tiles_after.Count == 0;
        }
        
        private List<Tile> FilterTiles(Tile[] tiles)
        {
            return tiles?.Where(x => x != null && x.worldRectangle.Intersects(GetRectangleDown))?.ToList() ?? new List<Tile>();
        }

        private bool CanMoveUp()
        {
            //var tiles = ChristianGame.GetScene.map?.mainTiles?.Where(x => x.worldRectangle.Intersects(GetRectangleUp))?.ToList();
            //return tiles == null || !tiles.Any();
            return false;
        }

        private bool CanMoveRight()
        {
            //var tiles = ChristianGame.GetScene.map?.mainTiles?.Where(x => x.worldRectangle.Intersects(GetRectangleRight))?.ToList();
            //return tiles == null || !tiles.Any();
            return false;
        }

        private bool CanMoveLeft()
        {
            //var tiles = ChristianGame.GetScene.map?.mainTiles?.Where(x => x.worldRectangle.Intersects(GetRectangleLeft))?.ToList();
            //return tiles == null || !tiles.Any();
            return false;
        }

        private void ClampUp()
        {
            /*
            Tile tile = ChristianGame.GetScene.map?.mainTiles?.FirstOrDefault(x => x.worldRectangle.Intersects(GetRectangleUp));
            if (tile != null)
            {
                int dif = tile.worldRectangle.Bottom - rectangle.Y;
                if (dif != 0) rectangle = MyRectangle.MoveRectangle_Y(rectangle, dif);
            }
            */
        }
        
        private void ClampDown()
        {
            Tile tile = ChristianTools.Helpers.Other.FlattenArray(ChristianGame.GetScene.map?.mainTiles).Where(x => x != null).FirstOrDefault(x => x.worldRectangle.Intersects(GetRectangleDown));
            if (tile != null)
            {
                int dif = tile.worldRectangle.Y - rectangle.Bottom;
                if (dif != 0) rectangle = MyRectangle.MoveRectangle_Y(rectangle, dif);
            }
        }

        private void ClampRight()
        {
            /*
            Tile tile = ChristianGame.GetScene.map?.mainTiles?.FirstOrDefault(x => x.worldRectangle.Intersects(GetRectangleRight));
            if (tile != null)
            {
                int dif = tile.worldRectangle.X - rectangle.Right;
                if (dif != 0) rectangle = MyRectangle.MoveRectangle_X(rectangle, dif);
            }
            */
        }

        private void ClampLeft()
        {
            /*
            Tile tile = ChristianGame.GetScene.map?.mainTiles?.FirstOrDefault(x => x.worldRectangle.Intersects(GetRectangleLeft));
            if (tile != null)
            {
                int dif = tile.worldRectangle.Right - rectangle.X;
                if (dif != 0) rectangle = MyRectangle.MoveRectangle_X(rectangle, dif);
            }
            */
        }
    }
}