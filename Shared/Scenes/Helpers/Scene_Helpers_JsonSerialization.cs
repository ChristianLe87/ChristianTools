using System;
using System.Collections.Generic;
using System.Linq;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Scene_Helpers_JsonSerialization : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; }
        public Camera camera { get; }
        public Map map { get; }

        public DxSceneUpdateSystem dxSceneUpdateSystem { get; private set; }
        public DxSceneDrawSystem dxSceneDrawSystem { get; }

        public void Initialize(Vector2? playerPosition = null)
        {
            this.UIs = new List<IUI>()
            {
                new Label(
                    rectangle: new Rectangle(250, 10, 230, 30),
                    spriteFont: WK.Font.font_7,
                    text: "Score:",
                    textAlignment: Label.TextAlignment.Midle_Center,
                    tag: ""
                ),
                new Button(
                    rectangle: new Rectangle (10, 10, 230, 30),
                    text: "Save",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "save",
                    OnClickAction: () => JsonSerialization.Update<GameData>(Game1.gameData, ChristianGame.Default.GameDataFileName)
                ),
                new Button(
                    rectangle: new Rectangle (10, 50, 230, 30),
                    text: "+",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "plus",
                    OnClickAction: () => Game1.gameData.score++
                ),
                new Button(
                    rectangle: new Rectangle (10, 90, 230, 30),
                    text: "-",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "minus",
                    OnClickAction: () => Game1.gameData.score--
                ),
                new Button(
                    rectangle: new Rectangle (0, 470, 230, 30),
                    text: "<- Helpers",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "goToComponents",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Helpers)
                ),
            };
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            Label label = UIs.OfType<Label>().First();
            label.UpdateText($"Score: {Game1.gameData.score}");
        }
    }
}