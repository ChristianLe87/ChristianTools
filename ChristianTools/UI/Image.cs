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
        public bool isActive { get; set; }

        public DxUpdateSystem dxUpdateSystem { get; }
        public DxDrawSystem dxDrawSystem { get; }

        public Image(Texture2D texture, Vector2 centerPosition, string tag = "")
        {
            this.rectangle = Tools.Tools.GetRectangle.Rectangle(centerPosition, texture);
            this.texture = texture;
            this.tag = tag;

            this.dxDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
            this.isActive = true;
        }

        public Image(Texture2D texture, Rectangle rectangle, string tag = "")
        {
            this.rectangle = rectangle;
            this.texture = texture;
            this.tag = tag;

            this.dxDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
            this.isActive = true;
        }

        private void DrawSystem(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, rectangle, Color.White);


            {
                Rectangle tempRectangle;

                if (ChristianGame.GetScene.camera != null)
                    tempRectangle = new Rectangle((int)(rectangle.X + ChristianGame.GetScene.camera.rectangle.X), (int)(rectangle.Y + ChristianGame.GetScene.camera.rectangle.Y), rectangle.Width, rectangle.Height);
                else
                    tempRectangle = rectangle;

            
                    spriteBatch.Draw(texture, tempRectangle, Color.White);


                //label.dxUiDrawSystem(spriteBatch);
            }
        }
    }
}