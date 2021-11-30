using System;
using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using static ChristianTools.Components.Animation;

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

        MyCharacter myCharacter;

        public Scene_Components_Animation()
        {
            Initialize();
        }

        public void Initialize()
        {
            this.myCharacter = new MyCharacter();

            this.UIs = new List<IUI>()
            {
                new Button(
                    rectangle: new Rectangle (0, 470, 230, 30),
                    text: "<- Components",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "goToComponents",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Components),
                    camera
                ),
            };
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            myCharacter.Update(lastInputState, inputState);

            foreach (var ui in UIs)
                ui.Update(lastInputState, inputState);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            myCharacter.Draw(spriteBatch);

            foreach (var ui in UIs)
                ui.Draw(spriteBatch);
        }


        class MyCharacter
        {
            Animation animation;
            CharacterState characterState;

            public MyCharacter()
            {
                this.characterState = CharacterState.IdleLeft;

                Dictionary<CharacterState, Texture2D[]> animations = new Dictionary<CharacterState, Texture2D[]>()
                {
                    { CharacterState.IdleLeft, new Texture2D[] { WK.Texture.Player.IdleLeft_Multiply } },
                    { CharacterState.IdleRight, new Texture2D[] { WK.Texture.Player.IdleRight_Multiply } },
                    { CharacterState.WalkLeft, new Texture2D[] { WK.Texture.Player.WalkLeft1_Multiply, WK.Texture.Player.WalkLeft2_Multiply } },
                    { CharacterState.WalkRight, new Texture2D[] { WK.Texture.Player.WalkRight1_Multiply, WK.Texture.Player.WalkRight2_Multiply } },
                    { CharacterState.JumpLeft, new Texture2D[] { WK.Texture.Player.JumpLeft_Multiply } },
                    { CharacterState.JumpRight, new Texture2D[] { WK.Texture.Player.JumpRight_Multiply } },
                };

                this.animation = new Animation(animations: animations, framesPerTexture: 16);
            }

            public void Update(InputState lastInputState, InputState inputState)
            {
                if (inputState.Right)
                {
                    characterState = CharacterState.WalkRight;
                }
                else if (inputState.Left)
                {
                    characterState = CharacterState.WalkLeft;
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

                animation.Update();
            }

            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(animation.GetTexture(characterState), new Vector2(WK.Default.Width / 2, WK.Default.Height / 2), Color.White);
            }
        }
    }

    
}