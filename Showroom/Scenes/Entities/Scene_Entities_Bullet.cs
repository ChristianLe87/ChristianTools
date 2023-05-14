using System;
using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Showroom_Shared
{
    public class Scene_Entities_Bullet : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<ILight> lights { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Camera camera { get; private set; }
        public Map map { get; private set; }

        public DxUpdateSystem dxUpdateSystem { get; private set; }
        public DxDrawSystem dxDrawSystem { get; }

        Vector2 centerPosition = new Point(ChristianGame.Default.canvasWidth / 2, ChristianGame.Default.canvasHeight / 2).ToVector2();

        public void Initialize(Vector2? playerPosition = null)
        {
            this.UIs = new List<IUI>()
            {
                new Label(
                    rectangle: new Rectangle(10, 10, 250, 50),
                    spriteFont: WK.Font.font_7,
                    text: "Click somewhere",
                    textAlignment: Label.TextAlignment.Midle_Center,
                    tag: ""
                ),
                new Button(
                    rectangle: new Rectangle (0, 470, 230, 30),
                    text: "<- Entities",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "goToEntities",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Entities)
                ),
            };

            this.entities = new List<IEntity>();
            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => SceneUpdateSystem(lastInputState, inputState);
        }

        public void SceneUpdateSystem(InputState lastInputState, InputState inputState)
        {
            if (lastInputState.Mouse_LeftButton == ButtonState.Released && inputState.Mouse_LeftButton == ButtonState.Pressed)
            {
                Bullet bullet = new Bullet(
                    texture2D: ChristianTools.Helpers.Texture.CreateCircleTexture(Color.White, 10),
                    centerPosition: centerPosition,
                    direction: inputState.Mouse_Position().ToVector2(),
                    steps: 3,
                    timeToDeactivate: new TimeSpan(0, 0, 2)
                );
                entities.Add(bullet);
            }
        }
    }
}