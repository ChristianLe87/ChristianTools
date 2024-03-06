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
                if (CanMoveDown() == false)
                {
                    var tiles = ChristianGame.GetScene.map?.mainTiles?.Where(x => x.worldRectangle.Intersects(GetRectangleDown))?.ToList();
                    
                    if (tiles == null || tiles.Any())
                    {
                        var dif = tiles[0].worldRectangle.Y - rectangle.Bottom;

                        if (dif != 0)
                        {
                            rectangle = ChristianTools.Helpers.MyRectangle.MoveRectangle_Y(rectangle, dif);
                        }
                    }
                }
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
            var tiles = ChristianGame.GetScene.map?.mainTiles?.Where(x => x.worldRectangle.Intersects(GetRectangleDown))?.ToList();
            return tiles == null || !tiles.Any();
        }
        
        private bool CanMoveUp()
        {
            var tiles = ChristianGame.GetScene.map?.mainTiles?.Where(x => x.worldRectangle.Intersects(GetRectangleUp))?.ToList();
            return tiles == null || !tiles.Any();
        }
        
        private bool CanMoveRight()
        {
            var tiles = ChristianGame.GetScene.map?.mainTiles?.Where(x => x.worldRectangle.Intersects(GetRectangleRight))?.ToList();
            return tiles == null || !tiles.Any();
        }
        
        private bool CanMoveLeft()
        {
            var tiles = ChristianGame.GetScene.map?.mainTiles?.Where(x => x.worldRectangle.Intersects(GetRectangleLeft))?.ToList();
            return tiles == null || !tiles.Any();
        }
    }
}
