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

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            foreach (var re in rectangles)
            {
                //spriteBatch.Draw(sprite, new Rectangle(0, 0, 10, 10), new Rectangle(0,0,sprite.Width, sprite.Height), Color.White);

                // Calculate the source rectangle of the current frame.
                //Rectangle source = new Rectangle(FrameIndex * Animation.Texture.Height, 0, Animation.Texture.Height, Animation.Texture.Height);

                // Draw the current frame.
                spriteBatch.Draw(
                            texture: sprite,
                            position: position,//new Vector2(100, 100),
                            sourceRectangle: new Rectangle(0,0,45,64),
                            color: Color.White
                            );
            }
            
        }
    }
}