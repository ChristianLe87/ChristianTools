﻿using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Showroom_Shared
{
    public class Scene_Components_Animation : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<ILight> lights { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Camera camera { get; private set; }
        public Map map { get; private set; }

        public DxUpdateSystem dxUpdateSystem { get; }
        public DxDrawSystem dxDrawSystem { get; }

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

            public DxUpdateSystem dxUpdateSystem { get; }
            public DxDrawSystem dxDrawSystem { get; }

            public MyCharacter()
            {
                this.isActive = true;
                this.characterState = CharacterState.IdleLeft;

                var animationsRight = WK.Texture.Player.animationsRight;
                var animationsLeft = WK.Texture.Player.animationsLeft;

                Dictionary<CharacterState, Texture2D[]> animations = new Dictionary<CharacterState, Texture2D[]>();
                foreach (var right in animationsRight)
                    animations.Add(right.Key, right.Value);

                foreach (var left in animationsLeft)
                    animations.Add(left.Key, left.Value);


                this.animation = new Animation(animations);
                this.rigidbody = new Rigidbody(new Vector2(300, 300), this);

                this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem(inputState);
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