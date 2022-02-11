using System;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.UI
{
    public class Transition
    {
        /// <summary>
        /// When darkness slowly turns into a image (when game begins)
        /// </summary>
		public class FadeIn : IUI
        {
            public Rectangle rectangle { get; private set; }
            public string tag { get; private set; } = "";

            public Texture2D texture { get; private set; }
            Color color;
            byte fadeSpeed;
            public bool isActive { get; set; }
            public bool fadeFinish { get; private set; }

            public DxUpdateSystem dxUpdateSystem { get; }
            public DxDrawSystem dxDrawSystem { get; }

            public FadeIn(byte fadeSpeed = 10, bool isActive = true)
            {
                this.rectangle = ChristianGame.GetScene.camera.rectangle;

                this.fadeSpeed = (byte)fadeSpeed;

                this.color = Color.Black;

                this.texture = ChristianTools.Tools.Tools.Texture.CreateColorTexture(color);

                this.fadeFinish = false;

                this.isActive = isActive;

                this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem(lastInputState, inputState);
                this.dxDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
            }

            private void UpdateSystem(InputState lastInputState, InputState inputState)
            {
                if (fadeFinish == true)
                    return;


                color.A -= fadeSpeed;
                texture = ChristianTools.Tools.Tools.Texture.CreateColorTexture(color);

                if (color.A <= fadeSpeed)
                    fadeFinish = true;
            }

            private void DrawSystem(SpriteBatch spriteBatch)
            {
                if (color.A <= fadeSpeed)
                    return;

                spriteBatch.Draw(
                    texture,
                    new Rectangle(
                        new Point(
                            ChristianGame.GetScene.camera.rectangle.X,
                            ChristianGame.GetScene.camera.rectangle.Y
                        ),
                        new Point(
                            ChristianGame.viewport.Width,
                            ChristianGame.viewport.Height
                        )
                    ),
                    Color.White
                );

            }
        }

        /// <summary>
        /// When an image slowly turns into darkness (when film ends)
        /// </summary>
		public class FadeOut : IUI
        {
            public Rectangle rectangle { get; private set; }
            public string tag { get; private set; } = "";

            public Texture2D texture { get; private set; }
            Color color;
            byte fadeSpeed;

            public bool fadeFinish { get; private set; }
            public bool isActive { get; set; }

            public DxUpdateSystem dxUpdateSystem { get; }
            public DxDrawSystem dxDrawSystem { get; }

            public FadeOut(byte fadeSpeed = 10, bool isActive = true)
            {
                this.rectangle = ChristianGame.GetScene.camera.rectangle;

                this.fadeSpeed = (byte)fadeSpeed;

                this.color = Color.Black;
                this.color.A = 0;

                this.texture = ChristianTools.Tools.Tools.Texture.CreateColorTexture(color);

                this.fadeFinish = false;

                this.isActive = isActive;

                this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem(lastInputState, inputState);
                this.dxDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
            }

            private void UpdateSystem(InputState lastInputState, InputState inputState)
            {
                if (fadeFinish == true)
                    return;


                color.A += fadeSpeed;
                texture = ChristianTools.Tools.Tools.Texture.CreateColorTexture(color);

                if (color.A > (byte.MaxValue - fadeSpeed))
                    fadeFinish = true;
            }

            private void DrawSystem(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(
                    texture,
                    new Rectangle(
                        new Point(
                            ChristianGame.GetScene.camera.rectangle.X,
                            ChristianGame.GetScene.camera.rectangle.Y
                        ),
                        new Point(
                            ChristianGame.viewport.Width,
                            ChristianGame.viewport.Height
                        )
                    ),
                    Color.White
                );
            }
        }
    }
}