using System;
using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Scene_Components_Camera : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; }
        public Camera camera { get; private set; }
        public Map map { get; }

        Vector2 position;

        public Scene_Components_Camera()
        {
            Initialize();
        }

        public void Initialize()
        {
            this.position = new Vector2(WK.Default.Width / 2, WK.Default.Height / 2);
            this.camera = new Camera(Game1.spriteBatch.GraphicsDevice.Viewport);

            this.UIs = new List<IUI>()
            {
                new Button(
                    rectangle: new Rectangle (0, 470, 230, 30),
                    text: "Components",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_14,
                    fontColor: Color.Pink,
                    tag: "goToComponents",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Components),
                    camera: camera
                ),
                new Label(new Rectangle(10, 10, 100, 50), WK.Font.font_14, "Use \"Up\", \"Down\", \"Right\", \"Left\"\nto move camera", Label.TextAlignment.Midle_Left, Color.Pink, ""),
            };
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            if (inputState.Right)
                position.X++;
            else if (inputState.Left)
                position.X--;
            else if (inputState.Up)
                position.Y--;
            else if (inputState.Down)
                position.Y++;

            camera.Update(position);

            foreach (var ui in UIs)
                ui.Update(lastInputState, inputState);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var ui in UIs)
                ui.Draw(spriteBatch);
        }
    }
}