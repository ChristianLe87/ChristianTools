using System;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Entities
{
    /// <summary>
    /// Something with a texture and a rigidbody
    /// </summary>
    public class Prefab : IEntity
    {
        public bool isActive { get; set; }
        public string tag { get; private set; }
        public Rigidbody rigidbody { get; }
        public int health { get; }
        public Components.Components components { get; set; }

        public delegate void DxInitializeSystem();
        public delegate void DxUpdateSystem(InputState lastInputState, InputState inputState, Prefab prefab);
        public delegate void DxDrawSystem(SpriteBatch spriteBatch, Prefab prefab);

        DxInitializeSystem dxInitializeSystem;
        DxUpdateSystem dxUpdateSystem;
        DxDrawSystem dxDrawSystem;

        public Animation animation { get; }
        public Animation.CharacterState characterState { get; set; }

        public Prefab(Texture2D texture2D, Vector2 centerPosition, bool isActive = true, string tag = "", DxInitializeSystem dxInitializeSystem = null, DxUpdateSystem dxUpdateSystem = null, DxDrawSystem dxDrawSystem = null)
        {
            this.animation = new Animation(texture2D);
            this.rigidbody = new Rigidbody(centerPosition, texture2D.Width, texture2D.Height, Vector2.Zero, Vector2.Zero);
            this.isActive = isActive;
            this.tag = tag;
            this.dxUpdateSystem = dxUpdateSystem;
            this.dxDrawSystem = dxDrawSystem;

            if (dxInitializeSystem != null)
                dxInitializeSystem();
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            if(isActive == true)
            {
                if (dxUpdateSystem != null)
                    dxUpdateSystem(lastInputState, inputState, this);

                rigidbody.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isActive == true)
            {
                if (dxDrawSystem != null)
                    dxDrawSystem(spriteBatch, this);
                else
                    spriteBatch.Draw(animation.GetTexture(characterState), rigidbody.rectangle, Color.White);
            }
        }
    }
}