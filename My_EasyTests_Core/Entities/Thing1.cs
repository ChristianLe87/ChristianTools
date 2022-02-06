using System;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace My_EasyTests_Core
{
    public class Thing1 : IEntity
    {
        public Animation animation { get; private set; }
        public Rigidbody rigidbody { get; private set; }
        public CharacterState characterState { get; set; }
        public bool isActive { get; set; }
        public string tag { get; private set; }
        public int health { get; private set; }
        public DxEntityUpdateSystem dxEntityUpdateSystem { get; private set; }
        public DxEntityDrawSystem dxEntityDrawSystem { get; private set; }

        public Thing1(Vector2 centerPosition)
        {
            this.animation = new Animation(WK.Texture.Lightmask);
            this.rigidbody = new Rigidbody(centerPosition, this);
            this.isActive = true;

            this.dxEntityDrawSystem = (SpriteBatch spriteBatch) => EntityDrawSystem(spriteBatch);
        }

        private void EntityDrawSystem(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(animation.GetTexture(this.characterState), rigidbody.centerPosition, Color.White);
        }
    }
}