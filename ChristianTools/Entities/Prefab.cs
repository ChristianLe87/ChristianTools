using System;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static ChristianTools.Components.Animation;

namespace ChristianTools.Entities
{

    /// <summary>
    /// Something with a texture and a rigidbody
    /// </summary>
    public class Entity : IEntity
    {
        public bool isActive { get; set; }
        public string tag { get; private set; }
        public Rigidbody rigidbody { get; }
        public int health { get; }
        public ExtraComponents extraComponents { get; set; }
        public Animation animation { get; }
        public CharacterState characterState { get; set; }

        public DxEntityInitializeSystem dxEntityInitializeSystem { get; set; }
        public DxEntityUpdateSystem dxEntityUpdateSystem { get; set; }
        public DxEntityDrawSystem dxEntityDrawSystem { get; set; }

        public Entity(Texture2D texture2D, Vector2 centerPosition, bool isActive = true, string tag = "", DxEntityInitializeSystem dxInitializeSystem = null, DxEntityUpdateSystem dxUpdateSystem = null, DxEntityDrawSystem dxDrawSystem = null)
        {
            this.animation = new Animation(texture2D);
            this.rigidbody = new Rigidbody(centerPosition, texture2D.Width, texture2D.Height, Vector2.Zero, Vector2.Zero);
            this.isActive = isActive;
            this.tag = tag;
            this.dxEntityUpdateSystem = dxUpdateSystem;
            this.dxEntityDrawSystem = dxDrawSystem;

            if (dxInitializeSystem != null)
                dxInitializeSystem();
        }

        /*public void Update(InputState lastInputState, InputState inputState)
        {
        }*/

        /*public void Draw(SpriteBatch spriteBatch)
        {
        }*/
    }
}