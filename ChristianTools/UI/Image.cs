using System;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.UI
{
	public class Image : IUI
	{
        public Rectangle rectangle { get; private set; }
        public string tag { get; }

        public Texture2D texture;
        Camera camera;

        public Image(Texture2D texture, Vector2 centerPosition, Camera camera, string tag = "")
        {
            this.camera = camera;
            this.rectangle = Tools.Tools.GetRectangle.Rectangle(centerPosition, texture);
            this.texture = texture;
            this.tag = tag;
        }

        public Image(Texture2D texture, Rectangle rectangle, string tag = "")
        {
            this.rectangle = rectangle;
            this.texture = texture;
            this.tag = tag;
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(rectangle.Location + new Point(camera.rectangle.X, camera.rectangle.Y), rectangle.Size), Color.White);
        }
    }
}