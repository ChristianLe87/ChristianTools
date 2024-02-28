using System.Collections.Generic;
using System.Linq;
using ChristianTools.Helpers;
using ChristianTools.Systems.Draw;
using Microsoft.Xna.Framework;

namespace ChristianTools.Components
{
     public class Rigidbody_Test : IRigidbody
    {
        public double rotationDegree { get; set; }
        public Vector2 force { get; set; }
        public Rectangle rectangle { get; set; }
        public Rectangle GetRectangleUp => ChristianTools.Helpers.MyRectangle.GetRectangleUp(rectangle);
        public Rectangle GetRectangleDown => ChristianTools.Helpers.MyRectangle.GetRectangleDown(rectangle);
        public Rectangle GetRectangleLeft => ChristianTools.Helpers.MyRectangle.GetRectangleLeft(rectangle);
        public Rectangle GetRectangleRight => ChristianTools.Helpers.MyRectangle.GetRectangleRight(rectangle);
        public Rectangle GetRectangleScaled => ChristianTools.Helpers.MyRectangle.ScaleRectangleSides(rectangle);

        public void InitializeRigidbody(Rectangle rectangle, Vector2 force = new Vector2())
        {
            this.rotationDegree = 0;
            this.force = force;
            this.rectangle = rectangle;
            
        }
        //public bool isGrounded(int scaleFactor) => (CanMoveDown(scaleFactor) == false);
        //Enums_Interfaces_Delegates.IEntity entity;


        public Rigidbody_Test(Rectangle rectangle, Vector2 force = new Vector2())
        {
            InitializeRigidbody(rectangle, force);
        }

        public void Update()
        {
            List<Tile> colliders = ChristianGame.scenes[ChristianGame.actualScene].map.mainTiles;

            List<Tile> tileColliders = colliders.Where(x => x.worldRectangle.Intersects(rectangle)).ToList();
            IEntity entityNumber = ChristianGame.scenes[ChristianGame.actualScene].entities.Where(x=>x.tag == "Entity_Numbers").First();

            // Down
            if (tileColliders.Count > 0)
            {
                if (tileColliders.FirstOrDefault().worldRectangle.Intersects(rectangle));
                {
                    var bla = 2;
                }
            }



            if (entityNumber.rigidbody.rectangle.Intersects(rectangle))
            {
                var bla = 0;
            }
            
            
            

            // Force
            Move_X((int)force.X);
            Move_Y((int)force.Y);
        }

        /// <summary>
        /// Move on X, if tiles, dont move
        /// </summary>
        /// <param name="X"></param>
        public void Move_X(int X)
        {
            int rX = rectangle.X + X;
            int rY = rectangle.Y;
            int rW = rectangle.Width;
            int rH = rectangle.Height;

            rectangle = new Rectangle(rX, rY, rW, rH);
        }


        /// <summary>
        /// Move on Y, if tiles, dont move
        /// </summary>
        /// <param name="Y"></param>
        public void Move_Y(int Y)
        {
            int rX = rectangle.X;
            int rY = rectangle.Y + Y;
            int rW = rectangle.Width;
            int rH = rectangle.Height;

            rectangle = new Rectangle(rX, rY, rW, rH);
        }


        public void SetCenterPosition(Point newCenterPosition)
        {
            rectangle = ChristianTools.Helpers.MyRectangle.CreateRectangle(newCenterPosition, rectangle.Width, rectangle.Height);
        }
    }
}