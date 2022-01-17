using System.Collections.Generic;
using System.Linq;
using ChristianTools.Components;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Shared
{
    public class Scene_Entities_Line : IScene
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

            this.entities = new List<IEntity>()
            {
                new Line(
                    start: WK.Default.Center,
                    end: WK.Default.Center,
                    thickness: 5,
                    texture2D: WK.Texture.Red,
                    tag: "line1"
                ),
            };

            this.dxSceneUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem(lastInputState, inputState);
        }

        private void UpdateSystem(InputState lastInputState, InputState inputState)
        {
            Line line = entities.OfType<Line>().First();
            line.UpdatePoints(start: null, end: inputState.Mouse_Position());
        }
    }
}