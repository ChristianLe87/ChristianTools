using System;
using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Tools;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Scene_Menu : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; }
        public Camera camera { get; }
        public Map map { get; }

        public Scene_Menu()
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
                    defaultTexture: WK.Image.LightGray,
                    mouseOverTexture: WK.Image.Gray,
                    spriteFont: WK.Font.font_14,
                    fontColor: Color.Pink,
                    tag: "goToComponents",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Components)
                ),
                new Button(
                    rectangle: new Rectangle (10, 50, 230, 30),
                    text: "Components_Entities",
                    defaultTexture: WK.Image.LightGray,
                    mouseOverTexture: WK.Image.Gray,
                    spriteFont: WK.Font.font_14,
                    fontColor: Color.Pink,
                    tag: "goToEntities",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Entities)
                ),
                new Button(
                    rectangle: new Rectangle (10, 90, 230, 30),
                    text: "Components_Helpers",
                    defaultTexture: WK.Image.LightGray,
                    mouseOverTexture: WK.Image.Gray,
                    spriteFont: WK.Font.font_14,
                    fontColor: Color.Pink,
                    tag: "goToHelpers",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Helpers)
                ),
                new Button(
                    rectangle: new Rectangle (10, 130, 230, 30),
                    text: "Components_Tools",
                    defaultTexture: WK.Image.LightGray,
                    mouseOverTexture: WK.Image.Gray,
                    spriteFont: WK.Font.font_14,
                    fontColor: Color.Pink,
                    tag: "goToTools",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Tools)
                ),
                new Button(
                    rectangle: new Rectangle (10, 170, 230, 30),
                    text: "Components_UI",
                    defaultTexture: WK.Image.LightGray,
                    mouseOverTexture: WK.Image.Gray,
                    spriteFont: WK.Font.font_14,
                    fontColor: Color.Pink,
                    tag: "goToUI",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.UI)
                ),
            };
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            foreach (IUI ui in UIs)
                ui.Update(lastInputState, inputState);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IUI ui in UIs)
                ui.Draw(spriteBatch);
        }
    }
}