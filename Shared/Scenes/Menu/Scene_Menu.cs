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
        public Camera camera { get; private set; }
        public Map map { get; }

        public DxSceneInitializeSystem dxSceneInitializeSystem { get; }
        public DxSceneUpdateSystem dxSceneUpdateSystem { get; private set; }
        public DxSceneDrawSystem dxSceneDrawSystem { get; }

        public void Initialize(Vector2? playerPosition = null)
        {
            //this.camera = new Camera(Game1.spriteBatch.GraphicsDevice.Viewport);

            this.UIs = new List<IUI>()
            {
                new Label(
                    rectangle: new Rectangle(260, 10, 230, 30),
                    spriteFont: WK.Font.font_7,
                    "Menu",
                    Label.TextAlignment.Midle_Center,
                    "",
                    camera
                    //texture: WK.Texture.LightGray
                ),
                new Button(
                    rectangle: new Rectangle (10, 10, 230, 30),
                    text: "Components",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "goToComponents",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Components),
                    camera
                ),
                new Button(
                    rectangle: new Rectangle (10, 50, 230, 30),
                    text: "Entities",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "goToEntities",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Entities),
                    camera
                ),
                new Button(
                    rectangle: new Rectangle (10, 90, 230, 30),
                    text: "Helpers",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "goToHelpers",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Helpers),
                    camera
                ),
                new Button(
                    rectangle: new Rectangle (10, 130, 230, 30),
                    text: "Tools",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "goToTools",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Tools),
                    camera
                ),
                new Button(
                    rectangle: new Rectangle (10, 170, 230, 30),
                    text: "UI",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "goToUI",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.UI),
                    camera
                ),
                new Button(
                    rectangle: new Rectangle (10, 210, 230, 30),
                    text: "Systems",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "goToSystems",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Systems),
                    camera
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