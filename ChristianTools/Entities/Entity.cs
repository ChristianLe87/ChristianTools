using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Entities
{
    /// <summary>
    /// Something with a texture and a rigidbody
    /// </summary>
    public class Entity : IEntity
    {
        public Rigidbody rigidbody { get; }
        public bool isActive { get; set; }
        public string tag { get; }
        public int health { get; }

        public Animation animation { get; }
        public CharacterState characterState { get; set; }

        public DxEntityUpdateSystem dxEntityUpdateSystem { get; private set; }
        public DxEntityDrawSystem dxEntityDrawSystem { get; private set; }

        public Entity(
            Texture2D texture2D, Vector2 centerPosition, bool isActive = true, string tag = "", Vector2? force = null, Vector2? gravity = null,
            DxEntityUpdateSystem dxUpdateSystem = null, DxEntityDrawSystem dxDrawSystem = null)
        {
            this.characterState = CharacterState.IdleRight;
            this.animation = new Animation(texture2D);
            this.rigidbody = new Rigidbody(
                centerPosition: centerPosition,
                entity: this,
                force: force
            );
            this.isActive = isActive;
            this.tag = tag;
            this.dxEntityUpdateSystem = dxUpdateSystem;
            this.dxEntityDrawSystem = dxDrawSystem;
        }
    }
}