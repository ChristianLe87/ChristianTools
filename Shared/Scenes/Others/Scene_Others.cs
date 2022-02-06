using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Shared
{
    public class Scene_Others : IScene
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

        public Scene_Others()
        {
            Initialize();
        }

        public void Initialize(Vector2? playerPosition = null)
        {
            this.UIs = new List<IUI>()
            {
                new Label(
                    rectangle: new Rectangle(260, 10, 230, 30),
                    spriteFont: WK.Font.font_7,
                    "Others",
                    Label.TextAlignment.Midle_Center,
                    ""
                ),
                new Button(
                    rectangle: new Rectangle(10, 10, 230, 30),
                    text: "PunchHole",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "goToPunchHole",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Others_PunchHole)
                ),
                 new Button(
                    rectangle: new Rectangle(10, 50, 230, 30),
                    text: "Lights",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "goToLights",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Scene_Others_Lights)
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