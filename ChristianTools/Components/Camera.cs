using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChristianTools.Components
{
    public class Camera
    {
        public float Zoom { get; private set; }
        private Point position { get; set; }

        public Rectangle cameraView
        {
            get { return ChristianTools.Helpers.MyRectangle.CreateRectangle(position, ChristianGame.WK.canvasWidth, ChristianGame.WK.canvasHeight); }
        }

        public Matrix transform { get; private set; }

        public Camera()
        {
            Zoom = 1f;
            position = Point.Zero;// Vector2.Zero;
        }


        private void UpdateMatrix()
        {
            transform = Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0)) *
                        Matrix.CreateScale(Zoom) *
                        Matrix.CreateTranslation(new Vector3(ChristianGame.WK.canvasWidth * 0.5f, ChristianGame.WK.canvasWidth * 0.5f, 0));
        }

        public void MoveCamera(Point newPosition)
        {
            position = newPosition;
        }

        public void AdjustZoom(float zoomAmount)
        {
            Zoom += zoomAmount;
        }

        public void UpdateCamera()
        {
            UpdateMatrix();
        }
    }
}