using System;
using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using ChristianTools.Tools;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Scene_Entities_Bullet : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; }
        public Camera camera { get; }
        public Map map { get; }

        public Scene_Entities_Bullet()
        {
            Initialize();
        }

        public void Initialize()
        {
            this.UIs = new List<IUI>()
            {
                new Label(
                    rectangle: new Rectangle(10, 10, 250, 50),
                    spriteFont: WK.Font.font_7,
                    text: "Click somewhere",
                    textAlignment: Label.TextAlignment.Midle_Center,
                    tag: "",
                    camera: camera
                ),
                new Button(
                    rectangle: new Rectangle (0, 470, 230, 30),
                    text: "<- Entities",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "goToEntities",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Entities),
                    camera: camera
                ),
            };

            this.entities = new List<IEntity>();
        }

        public void Update(InputState lastInputState, InputState inputState)
        {

            if(lastInputState.Mouse_LeftButton == ButtonState.Released && inputState.Mouse_LeftButton == ButtonState.Pressed)
            {
                Bullet bullet = new Bullet(
                    texture2D: Tools.Texture.CreateCircleTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.White, 10),
                    centerPosition: WK.Default.Center.ToVector2(),
                    direction: inputState.Mouse_Position().ToVector2(),
                    steps: 3,
                    timeToDeactivate: new TimeSpan(0, 0, 2)
                );

                entities.Add(bullet);
            }


            foreach (var ui in UIs)
                ui.Update(lastInputState, inputState);

            foreach (var entity in entities)
                entity.Update(lastInputState, inputState);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var ui in UIs)
                ui.Draw(spriteBatch);

            foreach (var entity in entities)
                entity.Draw(spriteBatch);
        }
    }
}