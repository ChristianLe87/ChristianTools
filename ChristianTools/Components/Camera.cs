using System;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Components
{
    public class Camera
    {
        public Rectangle rectangle { get; set; }
        public Matrix transform { get; set; }
        public Viewport viewport { get; }
        int zoom = 1;

        public Camera()
        {
            this.viewport = ChristianGame.viewport;
            transform = Matrix.CreateScale(new Vector3(zoom, zoom, 0)) * Matrix.CreateTranslation(Vector3.Zero);//-center.X, -center.Y, 0);
            rectangle = new Rectangle(0, 0, viewport.Width, viewport.Height);
        }

        [Obsolete("-> Use ChristianTools.Systems.Systems.Update.Camera", true)]
        public void Update(Vector2 targetPosition)
        {
            throw new Exception("-> Use ChristianTools.Systems.Systems.Update.Camera");
        }
    }
}