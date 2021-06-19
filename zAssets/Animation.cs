using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace zAssets
{
    public class Animation
    {
        public Texture2D sprite { get; private set; }
        int elementsInSprite;
        float delayPerPsrite;
        bool loop;
        public Rectangle rectangle { get => new Rectangle(0, 0, sprite.Width, sprite.Height); }
        AnimationState animationState;

    List<Rectangle> rectangles;

        public Animation(Texture2D sprite, int elementsInSprite, float delayPerPsrite, bool loop = false, AnimationState animationState = AnimationState.Idle)
        {
            this.sprite = sprite;
            this.elementsInSprite = elementsInSprite;
            this.delayPerPsrite = delayPerPsrite;
            this.loop = loop;
            this.animationState = animationState;


            this.rectangles = new List<Rectangle>();
            int eachWidth = sprite.Width / elementsInSprite;
            for (int i = 0; i < elementsInSprite; i++)
            {
                rectangles.Add(new Rectangle(i + eachWidth, 0, eachWidth, sprite.Height));
            }
        }

        public void Update()
        {
            if (loop)
            {

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var rectangle in rectangles)
            {
                spriteBatch.Draw(sprite, rectangle, Color.White);
            }
            
        }
    }
}