using System;
using ChristianTools.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Helpers.Hybrids
{
    public class ZeroZeroPoint
    {
        public IRigidbody rigidbody { get; set; }
        public Animation animation { get; }
        public bool isActive { get; set; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
        public string tag { get; }
        public Guid guid { get; }

        // ToDo: Make this private (maybe use rigidbody to mesure the W and H)
        public Texture2D texture2D_X;
        public Texture2D texture2D_Y;

        public ZeroZeroPoint()
        {
            this.rigidbody = new Rigidbody(new Rectangle());
            this.animation = new Animation(new Rectangle());
            this.isActive = true;
            this.tag = "";
            this.guid = Guid.NewGuid();

            texture2D_X = ChristianTools.Helpers.Texture.CreateColorTexture(Color.Red, 2, 200);
            texture2D_Y = ChristianTools.Helpers.Texture.CreateColorTexture(Color.Green, 200, 2);
        }
    }
}