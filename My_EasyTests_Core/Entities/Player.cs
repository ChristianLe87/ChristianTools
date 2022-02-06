using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Systems;
using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace My_EasyTests_Core
{
    public class Player : IEntity
    {
        public Animation animation { get; private set; }
        public Rigidbody rigidbody { get; private set; }
        public CharacterState characterState { get; set; }
        public bool isActive { get; set; }
        public string tag { get; private set; }
        public int health { get; private set; }
        public DxEntityUpdateSystem dxEntityUpdateSystem { get; private set; }
        public DxEntityDrawSystem dxEntityDrawSystem { get; private set; }

        public Player(Vector2 centerPosition)
        {
            this.animation = new Animation(WK.Texture.Player);
            this.rigidbody = new Rigidbody(centerPosition, this);
            this.isActive = true;

            this.dxEntityUpdateSystem = (InputState lastInputState, InputState inputState) => Systems.Update.Player.Basic_XY_Movement(inputState, this);
        }
    }
}