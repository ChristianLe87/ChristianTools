using System;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;

namespace ChristianTools.Systems
{
    public partial class Systems
    {
        public partial class Update
        {
            public static void Camera(Camera camera, Vector2 targetPosition)
            {
                camera.rectangle = new Rectangle(
                    x: (int)(targetPosition.X - camera.viewport.Width / 2),
                    y: (int)targetPosition.Y - camera.viewport.Height / 2,
                    width: camera.viewport.Width,
                    height: camera.viewport.Height
                );

                camera.transform = Matrix.CreateTranslation(new Vector3(-camera.rectangle.X, -camera.rectangle.Y, 0));
            }
        }
    }
}