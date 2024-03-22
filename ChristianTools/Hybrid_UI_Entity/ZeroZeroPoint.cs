using System;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Entities
{
    public class ZeroZeroPoint : IEntity, IUI
    {
        public IRigidbody rigidbody { get; set; }
        public Animation animation { get; }
        public bool isActive { get; set; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
        public string tag { get; }
        public Guid guid { get; }

        private Texture2D texture2D_X;
        private Texture2D texture2D_Y;

        public ZeroZeroPoint()
        {
            this.rigidbody = new Rigidbody(new Rectangle());
            this.animation = new Animation(new Rectangle());
            this.isActive = true;
            this.tag = "";
            this.guid = Guid.NewGuid();
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);

            texture2D_X = ChristianTools.Helpers.Texture.CreateColorTexture(Color.Red, 2, 200);
            texture2D_Y = ChristianTools.Helpers.Texture.CreateColorTexture(Color.Green, 200, 2);
        }

        private void DrawSystem(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D_X, new Rectangle(-texture2D_X.Width / 2, -texture2D_X.Height / 2, texture2D_X.Width, texture2D_X.Height), Color.White);
            spriteBatch.Draw(texture2D_Y, new Rectangle(-texture2D_Y.Width / 2, -texture2D_Y.Height / 2, texture2D_Y.Width, texture2D_Y.Height), Color.White);
        }
    }
}