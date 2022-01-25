using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using ChristianTools.Tools;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Shared
{
    public class Scene_Systems_DrawSystems : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; }
        public Camera camera { get; private set; }
        public Map map { get; }

        public DxSceneUpdateSystem dxSceneUpdateSystem { get; private set; }
        public DxSceneDrawSystem dxSceneDrawSystem { get; }

        public Scene_Systems_DrawSystems()
        {
            Initialize();
        }

        public void Initialize(Vector2? playerPosition = null)
        {
            this.UIs = new List<IUI>()
            {
                new Button(
                    rectangle: new Rectangle (0, 470, 230, 30),
                    text: "<- Systems",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "goToSystems",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Systems)
                ),
            };

            Entity entity = new Entity(null, new Vector2());
            entity = new Entity(
                texture2D: Tools.Texture.CreateTriangle(Color.Pink, 100, 100, Tools.Texture.PointDirection.Right),
                centerPosition: new Vector2(ChristianGame.Default.canvasWidth / 2, ChristianGame.Default.canvasHeight / 2),
                dxUpdateSystem: (InputState lastInputState, InputState inputState) => {
                    // Set rotation
                    double angleInDegrees = Tools.MyMath.GetAngleInDegree(entity.rigidbody.centerPosition, inputState.Mouse_Position().ToVector2());

                    entity.rigidbody.rotationDegree = (float)angleInDegrees;


                    // Set position
                    if (inputState.Left)
                        entity.rigidbody.Move_X(-1);
                    else if (inputState.Right)
                        entity.rigidbody.Move_X(1);

                    if (inputState.Up)
                        entity.rigidbody.Move_Y(-1);
                    else if (inputState.Down)
                        entity.rigidbody.Move_Y(1);
                }
            );

            this.entities = new List<IEntity>()
            {
                entity
            };
        }

        /*private void UpdateEntity(InputState lastInputState, InputState inputState)
        {
            // Set rotation
            double angleInDegrees = Tools.MyMath.GetAngleInDegree(.rigidbody.centerPosition, inputState.Mouse_Position().ToVector2());

            entity.rigidbody.rotationDegree = (float)angleInDegrees;


            // Set position
            if (inputState.Left)
                entity.rigidbody.Move_X(-1);
            else if (inputState.Right)
                entity.rigidbody.Move_X(1);

            if (inputState.Up)
                entity.rigidbody.Move_Y(-1);
            else if (inputState.Down)
                entity.rigidbody.Move_Y(1);
        }*/
    }
}