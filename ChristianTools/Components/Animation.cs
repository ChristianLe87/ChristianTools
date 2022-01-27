using System.Collections.Generic;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Components
{
    public class Animation
    {
        Dictionary<CharacterState, (Texture2D[], AnimationOption)> animations;

        int framesPerTexture;
        int framesCount;
        int frame;
        Texture2D texture2D;
        

        public Animation(Texture2D texture2D)
        {
            this.texture2D = texture2D;
            this.frame = 0;
        }

        public Animation(Dictionary<CharacterState, Texture2D[]> animations, int framesPerTexture = 6)
        {

            this.animations = new Dictionary<CharacterState, (Texture2D[], AnimationOption)>();


            foreach (var animation in animations)
                this.animations.Add(animation.Key, (animation.Value, AnimationOption.Loop));


            this.framesPerTexture = framesPerTexture;
            this.frame = 0;
        }

        public Animation(Dictionary<CharacterState, (Texture2D[], AnimationOption)> animations, int framesPerTexture = 6)
        {
            this.animations = animations;
            this.framesPerTexture = framesPerTexture;
            this.frame = 0;
        }

        public void Update()
        {
            framesCount++;
        }

        public Texture2D GetTexture(CharacterState characterState)
        {
            if (animations == null)
                return texture2D;


            if (framesCount > framesPerTexture)
            {
                framesCount = 0;
                frame++;
            }


            if (frame >= animations[characterState].Item1.Length)
                frame = 0;


            return animations[characterState].Item1[frame];
        }
    }
}