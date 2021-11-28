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
    public class Scene_Entities : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; }
        public Camera camera { get; }
        public Map map { get; }

        public Scene_Entities()
        {
            Initialize();
        }

        public void Initialize()
        {
            this.UIs = new List<IUI>()
            {
                new Button(
                    rectangle: new Rectangle (10, 10, 230, 30),
                    text: "Entities_Bullet",
                    defaultTexture: WK.Texture.Red,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_14,
                    tag: "goToEntities_Bullet",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Entities_Bullet),
                    camera
                ),
                new Button(
                    rectangle: new Rectangle (10, 50, 230, 30),
                    text: "Entities_Line",
                    defaultTexture: WK.Texture.Red,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_14,
                    tag: "goToEntities_Line",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Entities_Line),
                    camera
                ),
                new Button(
                    rectangle: new Rectangle (10, 90, 230, 30),
                    text: "Entities_Prefab",
                    defaultTexture: WK.Texture.Red,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_14,
                    tag: "goToEntities_Prefab",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Entities_Prefab),
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