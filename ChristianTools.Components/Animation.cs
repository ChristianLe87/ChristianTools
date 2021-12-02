﻿using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Components
{
    public class Animation
    {
        Dictionary<CharacterState, Texture2D[]> animations;
        int framesPerTexture;
        Texture2D texture2D;

        public Animation(Texture2D texture2D)
        {
            this.texture2D = texture2D;
        }

        public Animation(Dictionary<CharacterState, Texture2D[]> animations, int framesPerTexture)
        {
            this.animations = animations;
            this.animationFrameCount = 0;
            this.framesPerTexture = 16;
        }
        public void Update()
        {
            animationFrameCount++;
        }


        public Texture2D GetTexture()
        {
            return texture2D;
        }

        int animationFrameCount;
        public Texture2D GetTexture(CharacterState characterState)
        {
            if(animations == null)
                return texture2D;

            if (animationFrameCount > framesPerTexture)
                animationFrameCount = 0;

            int element = animationFrameCount < framesPerTexture / animations[characterState].Length ? 0 : 1;

            if (animations[characterState].Length == 1)
                return animations[characterState][0];
            else
                return animations[characterState][element];
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
    }
}