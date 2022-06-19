﻿using System;
using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using ChristianTools.Tools;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Showroom_Shared
{
    public class Scene_Components_Camera : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<ILight> lights { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Camera camera { get; private set; }
        public Map map { get; private set; }

        public DxUpdateSystem dxUpdateSystem { get; }
        public DxDrawSystem dxDrawSystem { get; }

        Vector2 position;
        Texture2D texture2D;

        public void Initialize(Vector2? playerPosition = null)
        {
            this.position = new Vector2(ChristianGame.Default.canvasWidth / 2, ChristianGame.Default.canvasHeight / 2);
            this.camera = new Camera();
            this.texture2D = WK.Texture.Red;

            this.UIs = new List<IUI>()
            {
                new Button(
                    rectangle: new Rectangle (0, 470, 230, 30),
                    text: "<- Components",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "goToComponents",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Components)
                ),
                 new Button(
                    rectangle: new Rectangle (100, 100, 100, 100),
                    text: "test me",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "test",
                    OnClickAction: null
                ),
                new Label(new Rectangle(10, 10, 200, 30), WK.Font.font_7, "Use \"Up\", \"Down\", \"Right\", \"Left\"\nto move camera", Label.TextAlignment.Midle_Left, "", WK.Texture.LightGray),
            };

            Texture2D Red = Tools.Texture.CreateColorTexture(Color.Red, Width: 50, Height: 50);
            this.entities = new List<IEntity>()
            {
                new Entity(Red, new Vector2(ChristianGame.Default.canvasWidth / 2, ChristianGame.Default.canvasHeight / 2),tag: "player", dxUpdateSystem: (InputState lastInputState, InputState inputState)=>UpdateSystem(lastInputState, inputState)),
            };
        }

        public void UpdateSystem(InputState lastInputState, InputState inputState)
        {
            if (inputState.Right)
                position.X++;
            else if (inputState.Left)
                position.X--;
            else if (inputState.Up)
                position.Y--;
            else if (inputState.Down)
                position.Y++;
        }
    }
}