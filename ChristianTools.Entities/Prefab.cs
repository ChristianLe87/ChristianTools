using System;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Entities
{
    /// <summary>
    /// Something with a texture and a rectangle
    /// </summary>
    public class Prefab : IEntity
    {
        Texture2D texture2D;
        public bool isActive { get; set; }
        public string tag { get; private set; }
        public Rigidbody rigidbody { get; }
        public int health { get; }
        public delegate void DxOnUpdate();
        DxOnUpdate dxOnUpdate;

        public Prefab(Texture2D texture2D, Vector2 centerPosition, bool isActive = true, string tag = "", DxOnUpdate dxOnUpdate = null)
        {
            this.texture2D = texture2D;
            this.rigidbody = new Rigidbody(centerPosition, texture2D.Width, texture2D.Height, Vector2.Zero, Vector2.Zero);
            this.isActive = isActive;
            this.tag = tag;
            this.dxOnUpdate = dxOnUpdate;
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            if(isActive == true)
            {
                if (dxOnUpdate != null)
                    dxOnUpdate();

                rigidbody.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isActive == true)
                spriteBatch.Draw(texture2D, rigidbody.rectangle, Color.White);
        }
    }
}