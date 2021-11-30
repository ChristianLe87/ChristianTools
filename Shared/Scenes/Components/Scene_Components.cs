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
    public class Scene_Components : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; }
        public Camera camera { get; private set; }
        public Map map { get; }

        public Scene_Components()
        {
            Initialize();
        }

        public void Initialize()
        {
            this.UIs = new List<IUI>()
            {
                new Button(
                    rectangle: new Rectangle (10, 10, 230, 30),
                    text: "Components_Animation",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_14,
                    tag: "goToComponents_Animation",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Components_Animation),
                    camera
                ),
                new Button(
                    rectangle: new Rectangle (10, 50, 230, 30),
                    text: "Components_Camera",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_14,
                    tag: "goToComponents_Camera",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Components_Camera),
                    camera
                ),
                new Button(
                    rectangle: new Rectangle (10, 90, 230, 30),
                    text: "Components_Map",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_14,
                    tag: "goToComponents_Map",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Components_Map),
                    camera
                ),
                new Button(
                    rectangle: new Rectangle (10, 130, 230, 30),
                    text: "Components_Rigidbody",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_14,
                    tag: "goToComponents_Rigidbody",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Components_Rigidbody),
                    camera
                ),
                new Button(
                    rectangle: new Rectangle (0, 470, 230, 30),
                    text: "<- Menu",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_14,
                    tag: "goToMenu",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Menu),
                    camera: camera
                ),
            };
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
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