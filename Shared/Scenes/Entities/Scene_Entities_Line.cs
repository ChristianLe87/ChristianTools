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
        public List<Light> lights { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Camera camera { get; private set; }
        public Map map { get; private set; }

        public DxUpdateSystem dxUpdateSystem { get; private set; }
        public DxDrawSystem dxDrawSystem { get; }

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
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Entities)
                ),
            };

            this.entities = new List<IEntity>()
            {
                new Line(
                    start: new Point(ChristianGame.Default.canvasWidth/2, ChristianGame.Default.canvasHeight/2),
                    end: new Point(ChristianGame.Default.canvasWidth/2, ChristianGame.Default.canvasHeight/2),
                    thickness: 5,
                    texture2D: WK.Texture.Red,
                    tag: "line1"
                ),
            };

            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem(lastInputState, inputState);
        }

        private void UpdateSystem(InputState lastInputState, InputState inputState)
        {
            Line line = entities.OfType<Line>().First();
            line.UpdatePoints(start: null, end: inputState.Mouse_Position());
        }
    }
}