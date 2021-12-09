using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Components
{
    public class Animation
    {
        Dictionary<CharacterState, (Texture2D[], AnimationOption)> animations;

        int framesPerTexture;
        int frameCount;
        int frame;
        Texture2D texture2D;

        public Animation(Texture2D texture2D)
        {
            this.texture2D = texture2D;
        }

        public Animation(Dictionary<CharacterState, (Texture2D[], AnimationOption)> animations, int framesPerTexture = 16)
        {
            this.animations = animations;
            this.framesPerTexture = 50;// framesPerTexture;
            this.frameCount = 0;
            this.frame = 0;
        }
        public void Update()
        {
            frameCount++;
        }

        public Texture2D GetTexture(CharacterState characterState)
        {

            if (animations == null)
                return texture2D;


            if (frameCount >= framesPerTexture)
            {
                frameCount = 0;

                if (animations[characterState].Item2 == AnimationOption.Stop && frame == (animations[characterState].Item1.Length - 1))
                {
                    //frame++;
                }
                else// if(animations[characterState].Item2 == AnimationOption.Loop)
                {
                    frame++;
                }
                
            }
            else
            {
                frameCount++;
            }


            if (frame == animations[characterState].Item1.Length)
                frame = 0;


            return animations[characterState].Item1[frame];
        }

        public enum CharacterState
        {
            IdleRight,
            IdleLeft,
            WalkRight,
            WalkLeft,
            JumpRight,
            JumpLeft,
            HangRight,
            HangLeft,
            ShootRight,
            ShootLeft,
        }

        public enum AnimationOption
        {
            Loop,
            //Bounce,
            Stop,
        }
    }
}