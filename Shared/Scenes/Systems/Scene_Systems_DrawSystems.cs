using System;
using System.Collections.Generic;
using System.Linq;
using ChristianTools.Components;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using ChristianTools.Systems;
using ChristianTools.Tools;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        public DxSceneInitializeSystem dxSceneInitializeSystem { get; }
        public DxSceneUpdateSystem dxSceneUpdateSystem { get; private set; }
        public DxSceneDrawSystem dxSceneDrawSystem { get; }

        public Scene_Systems_DrawSystems()
        {
        }

        public void Initialize()
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
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Systems),
                    camera: camera
                ),
            };

            this.entities = new List<IEntity>()
            {
                new Entity(
                    texture2D: Tools.Texture.CreateTriangle(Game1.graphicsDeviceManager.GraphicsDevice, Color.Pink, 100, 100, Tools.Texture.PointDirection.Right),
                    centerPosition: WK.Default.Center.ToVector2(),
                    dxUpdateSystem: (InputState lastInputState, InputState inputState, IEntity entity) => {

                        // Set rotation
                        
                        double angleInDegrees = Tools.MyMath.GetAngleInDegree(entity.rigidbody.centerPosition, inputState.Mouse_Position().ToVector2());

                        entity.rigidbody.SetAngleRotation((float)angleInDegrees);


                        // Set position
                        if (inputState.Left)
                            entity.rigidbody.Move_X(-1);
                        else if (inputState.Right)
                            entity.rigidbody.Move_X(1);

                        if (inputState.Up)
                            entity.rigidbody.Move_Y(-1);
                        else if (inputState.Down)
                            entity.rigidbody.Move_Y(1);
                    },
                    dxDrawSystem: (SpriteBatch spriteBatch, IEntity entity) => {
                        Systems.Draw.Entity(spriteBatch, entity);
                    }
                ),
            };
        }
    }
}