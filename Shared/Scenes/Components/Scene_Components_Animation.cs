using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Scene_Components_Animation : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; }
        public Camera camera { get; private set; }
        public Map map { get; }

        public DxSceneUpdateSystem dxSceneUpdateSystem { get; private set; }
        public DxSceneDrawSystem dxSceneDrawSystem { get; }

        public void Initialize(Vector2? playerPosition = null)
        {
            this.UIs = new List<IUI>()
            {
                new Button(
                    rectangle: new Rectangle (0, 470, 230, 30),
                    text: "<- Components",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "goToComponents",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Components)
                ),
            };

            this.entities = new List<IEntity>()
            {
                new MyCharacter()
            };
        }


        class MyCharacter : IEntity
        {
            public bool isActive { get; set; }
            public string tag { get; private set; }
            public Rigidbody rigidbody { get; }
            public int health { get; }
            public Animation animation { get; }
            public CharacterState characterState { get; set; }

            public DxEntityUpdateSystem dxEntityUpdateSystem { get; set; }
            public DxEntityDrawSystem dxEntityDrawSystem { get; set; }

            public MyCharacter()
            {
                this.isActive = true;
                this.characterState = CharacterState.IdleLeft;

                Dictionary<CharacterState, (Texture2D[], AnimationOption)> animations = new Dictionary<CharacterState, (Texture2D[], AnimationOption)>()
                {
                    { CharacterState.IdleLeft, (new Texture2D[] { WK.Texture.Player.IdleLeft_Multiply }, AnimationOption.Loop) },
                    { CharacterState.IdleRight, (new Texture2D[] { WK.Texture.Player.IdleRight_Multiply }, AnimationOption.Loop) },
                    { CharacterState.MoveLeft, (new Texture2D[] { WK.Texture.Player.WalkLeft1_Multiply }, AnimationOption.Loop) },
                    { CharacterState.MoveRight, (new Texture2D[] { WK.Texture.Player.WalkRight1_Multiply}, AnimationOption.Loop) },
                    { CharacterState.JumpLeft, (new Texture2D[] { WK.Texture.Player.JumpLeft_Multiply }, AnimationOption.Loop) },
                    { CharacterState.JumpRight, (new Texture2D[] { WK.Texture.Player.JumpRight_Multiply }, AnimationOption.Loop) },
                };

                this.animation = new Animation(animations: animations, framesPerTexture: 16);
                this.rigidbody = new Rigidbody(new Vector2(300, 300), this);

                this.dxEntityUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem(inputState);
            }


            public void UpdateSystem(InputState inputState)
            {
                if (inputState.Right)
                {
                    characterState = CharacterState.MoveRight;
                }
                else if (inputState.Left)
                {
                    characterState = CharacterState.MoveLeft;
                }
                else if (inputState.Jump)
                {
                    if (characterState.ToString().Contains("Left"))
                        characterState = CharacterState.JumpLeft;
                    else if (characterState.ToString().Contains("Right"))
                        characterState = CharacterState.JumpRight;
                }
                else
                {
                    if (characterState.ToString().Contains("Left"))
                        characterState = CharacterState.IdleLeft;
                    else if (characterState.ToString().Contains("Right"))
                        characterState = CharacterState.IdleRight;
                }
            }
        }
    }
}