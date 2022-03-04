using System;
using System.Collections.Generic;
using System.Linq;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;

namespace ChristianTools.Components
{
    public class Rigidbody
    {
        public double rotationDegree { get; set; }

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

        public bool isGrounded(int scaleFactor) => (CanMoveDown(scaleFactor) == false);

        IEntity entity;
        public Rigidbody(Vector2 centerPosition, IEntity entity, Vector2? force = null)
        {
            this.entity = entity;
            this.force = force == null ? Vector2.Zero : force.Value;
            this.centerPosition = centerPosition;
        }

        Rectangle baseRectangle;
        public Rigidbody(Rectangle rectangle, Vector2? force = null)
        {
            this.baseRectangle = rectangle;
            this.force = force == null ? Vector2.Zero : force.Value;
            this.centerPosition = rectangle.Center.ToVector2();
        }


        public void Update()
        {
            //List<ITile> tiles = ChristianGame.GetScene.map.tiles.Where(x => x.isActive == true).ToList();

            // Force
            Move_X(force.X);
            Move_Y(force.Y);
        }

        /// <summary>
        /// Move on X, if tiles, dont move
        /// </summary>
        /// <param name="X"></param>
        public void Move_X(float X)
        {
            List<ITile> tiles = ChristianGame.GetScene.map?.tiles.Where(x => x.layerID == Tiled.LayerId.Main && x.isActive == true).ToList();
            
            int scFct = (int)Math.Abs(X);

            if (X > 0) // Right
            {
                if (CanMoveRight(scFct) == true)
                {
                    centerPosition = new Vector2(centerPosition.X + X, centerPosition.Y);
                }
                else if (CanMoveRight(scFct) == false)
                {
                    ITile tileRight = tiles.FirstOrDefault(x => x.rigidbody.rectangleLeft(scFct).Intersects(rectangle));
                    int dif = rectangle.Right - tileRight.rigidbody.rectangle.X;

                    dif = Math.Clamp(dif, 0, scFct); // fix a problem that jump on corners
                    centerPosition = new Vector2(centerPosition.X - dif, centerPosition.Y);
                }
            }
            else if (X < 0)
            {
                if (CanMoveLeft(scFct) == true)
                {
                    centerPosition = new Vector2(centerPosition.X + X, centerPosition.Y);
                }
                else if (CanMoveLeft(scFct) == false)
                {
                    ITile tileLeft = tiles.FirstOrDefault(x => x.rigidbody.rectangleRight(scFct).Intersects(rectangle));
                    int dif = tileLeft.rigidbody.rectangle.Right - rectangle.X;

                    dif = Math.Clamp(dif, 0, scFct); // fix a problem that jump on corners
                    centerPosition = new Vector2(centerPosition.X + dif, centerPosition.Y);
                }
            }


        }

        /// <summary>
        /// Move on Y, if tiles, dont move
        /// </summary>
        /// <param name="Y"></param>
        public void Move_Y(float Y)
        {
            List<ITile> tiles = ChristianGame.GetScene.map?.tiles.Where(x => x.layerID == Tiled.LayerId.Main && x.isActive == true).ToList();
            
            int scFct = (int)Math.Abs(Y);

            if (Y > 0) // down
            {
                if (CanMoveDown(scFct) == true)
                {
                    centerPosition = new Vector2(centerPosition.X, centerPosition.Y + Y);
                }
                else if (CanMoveDown(scFct) == false)
                {
                    ITile tileDown = tiles.FirstOrDefault(x => x.rigidbody.rectangleUp(scFct).Intersects(rectangle));
                    int dif = rectangle.Bottom - tileDown.rigidbody.rectangle.Y;

                    dif = Math.Clamp(dif, 0, scFct); // fix a problem that jump on corners
                    centerPosition = new Vector2(centerPosition.X, centerPosition.Y - dif);
                }
            }
            else if (Y < 0)
            {
                if (CanMoveUp(scFct) == true)
                {
                    centerPosition = new Vector2(centerPosition.X, centerPosition.Y + Y);
                }
                else if (CanMoveUp(scFct) == false)
                {
                    ITile tileUp = tiles.FirstOrDefault(x => x.rigidbody.rectangleDown(scFct).Intersects(rectangle));
                    int dif = tileUp.rigidbody.rectangle.Bottom - rectangle.Y;

                    dif = Math.Clamp(dif, 0, scFct); // fix a problem that jump on corners
                    centerPosition = new Vector2(centerPosition.X, centerPosition.Y + dif);
                }
            }
        }



        public bool CanMoveRight(int scaleFactor)
        {
            List<ITile> tiles = ChristianGame.GetScene.map?.tiles.Where(x => x.layerID == Tiled.LayerId.Main && x.isActive == true).ToList();

            if (tiles == null)
                return true;

            int tilesRight = tiles.Count(x => x.rigidbody.rectangleLeft(scaleFactor).Intersects(rectangle));
            return tilesRight == 0 ? true : false;
        }

        public bool CanMoveLeft(int scaleFactor)
        {
            List<ITile> tiles = ChristianGame.GetScene.map?.tiles.Where(x => x.layerID == Tiled.LayerId.Main && x.isActive == true).ToList();

            if (tiles == null)
                return true;

            int tilesLeft = tiles.Count(x => x.rigidbody.rectangleRight(scaleFactor).Intersects(rectangle));
            return tilesLeft == 0 ? true : false;
        }


        public bool CanMoveDown(int scaleFactor)
        {
            List<ITile> tiles = ChristianGame.GetScene.map?.tiles.Where(x => x.layerID == Tiled.LayerId.Main && x.isActive == true).ToList();

            if (tiles == null)
                return true;

            int tilesDown = tiles.Count(x => x.rigidbody.rectangleUp(scaleFactor).Intersects(rectangle));
            return tilesDown == 0 ? true : false;
        }

        public bool CanMoveUp(int scaleFactor)
        {
            List<ITile> tiles = ChristianGame.GetScene.map?.tiles.Where(x => x.layerID == Tiled.LayerId.Main && x.isActive == true).ToList();

            if (tiles == null)
                return true;

            int tilesUp = tiles.Count(x => x.rigidbody.rectangleDown(scaleFactor).Intersects(rectangle));
            return tilesUp == 0 ? true : false;
        }
    }
}