using System;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Components
{
    public class Light : ILight
    {
        public Point centerPosition { get; private set; }
        public Texture2D texture { get; private set; }
        public bool isActive { get; set; }

        public DxUpdateSystem dxUpdateSystem { get; }
        public DxDrawSystem dxDrawSystem { get; }

        public Light(Point centerPosition, Texture2D texture = null, bool isActive = true)
        {
            this.centerPosition = centerPosition;
            this.texture = texture;
            this.isActive = isActive;
        }
    }
}