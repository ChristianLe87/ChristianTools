using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace zAssets
{
    /// <summary>
    /// Something with a texture and a rectangle
    /// </summary>
    public class Prefab: IEntity
    {
        Texture2D texture2D;
        public bool isActive { get; private set; }
        public string tag { get; private init; }
        public Rigidbody rigidbody { get; }
        public int health { get; }
        public delegate void DxOnUpdate();

        public Prefab(Texture2D texture2D, Vector2 centerPosition, bool isActive = true, string tag = "")
        {
            this.texture2D = texture2D;
            this.rigidbody = new Rigidbody(centerPosition, texture2D.Width, texture2D.Height, Vector2.Zero, Vector2.Zero);
            this.isActive = isActive;
            this.tag = tag;
        }

        public void Update(InputState lastInputState, InputState inputState, DxOnUpdate dxOnUpdate = null, bool isActive = true)
        {
            if(dxOnUpdate != null)
                dxOnUpdate();

            if (isActive != true)
                this.isActive = isActive;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(isActive)
                spriteBatch.Draw(texture2D, rigidbody.rectangle, Color.White);
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            throw new System.NotImplementedException();
        }
    }
}
