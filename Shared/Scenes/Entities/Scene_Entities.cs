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
        public List<Light> lights { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Camera camera { get; private set; }
        public Map map { get; private set; }

        public DxSceneUpdateSystem dxSceneUpdateSystem { get; private set; }
        public DxSceneDrawSystem dxSceneDrawSystem { get; private set; }

        public void Initialize(Vector2? playerPosition = null)
        {
            this.camera = new Camera();

            this.UIs = new List<IUI>()
            {
                new Button(
                    rectangle: new Rectangle (10, 10, 230, 30),
                    text: "Entities_Bullet",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "goToEntities_Bullet",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Entities_Bullet)
                ),
                new Button(
                    rectangle: new Rectangle (10, 50, 230, 30),
                    text: "Entities_Line",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "goToEntities_Line",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Entities_Line)
                ),
                new Button(
                    rectangle: new Rectangle (10, 90, 230, 30),
                    text: "Entities_Prefab",
                    defaultTexture: WK.Texture.Red,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "goToEntities_Prefab",
                    OnClickAction: null
                ),
                new Button(
                    rectangle: new Rectangle (0, 470, 230, 30),
                    text: "<- Menu",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "goToMenu",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Menu)
                ),
            };
        }
    }
}