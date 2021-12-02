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
                new Prefab(
                    texture2D: Tools.Texture.CreateTriangle(Game1.graphicsDeviceManager.GraphicsDevice, Color.Pink, 100, 100, Tools.Texture.PointDirection.Right),
                    centerPosition: WK.Default.Center.ToVector2(),
                    dxUpdateSystem: (InputState lastInputState, InputState inputState, Prefab prefab) => {

                        // Set rotation
                        double angleInRadians = Tools.MyMath.GetAngleInRadians(
                            Point1_Start: prefab.rigidbody.centerPosition,
                            Point1_End: new Vector2(prefab.rigidbody.centerPosition.X + WK.Default.Width, prefab.rigidbody.centerPosition.Y),
                            Point2_Start: prefab.rigidbody.centerPosition,
                            Point2_End: inputState.Mouse_Position().ToVector2()
                        );
                        double angleInDegrees = Tools.MyMath.RadianToDegree(angleInRadians);

                        prefab.rigidbody.SetAngleRotation((float)angleInDegrees);


                        // Set position
                        if (inputState.Left)
                            prefab.rigidbody.Move_X(-1);
                        else if (inputState.Right)
                            prefab.rigidbody.Move_X(1);

                        if (inputState.Up)
                            prefab.rigidbody.Move_Y(-1);
                        else if (inputState.Down)
                            prefab.rigidbody.Move_Y(1);
                    },
                    dxDrawSystem: (SpriteBatch spriteBatch, Prefab prefab) => {
                        Systems.DrawWithRotation(spriteBatch, prefab);
                    }
                ),
            };
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            if (UIs != null)
                foreach (var ui in UIs)
                    ui.Update(lastInputState, inputState);

            if (entities != null)
                foreach (var entity in entities)
                    entity.Update(lastInputState, inputState);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (UIs != null)
                foreach (var ui in UIs)
                    ui.Draw(spriteBatch);

            if (entities != null)
                foreach (var entity in entities)
                    entity.Draw(spriteBatch);
        }
    }
}