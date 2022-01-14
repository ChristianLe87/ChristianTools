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

        public Texture2D texture { get; }
        Camera camera;
        public bool isActive { get; set; }

        public DxUiUpdateSystem dxUiUpdateSystem { get; }
        public DxUiDrawSystem dxUiDrawSystem { get; }

        public Image(Texture2D texture, Vector2 centerPosition, string tag = "")
        {
            this.camera = ChristianGame.GetScene.camera;// != null ? ChristianGame.GetScene.camera: null;
            this.rectangle = Tools.Tools.GetRectangle.Rectangle(centerPosition, texture);
            this.texture = texture;
            this.tag = tag;

            this.dxUiDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
            this.isActive = true;
        }

        public Image(Texture2D texture, Rectangle rectangle, string tag = "")
        {
            this.rectangle = rectangle;
            this.texture = texture;
            this.tag = tag;

            this.dxUiDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
            this.isActive = true;
        }

        private void DrawSystem(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(rectangle.Location + new Point(camera.rectangle.X, camera.rectangle.Y), rectangle.Size), Color.White);
        }
    }
}