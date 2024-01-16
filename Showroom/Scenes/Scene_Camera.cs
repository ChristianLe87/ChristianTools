using System.Collections.Generic;
using System.Linq;
using ChristianTools;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Showroom.Scenes
{
    public class Scene_Camera : IScene
    {
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public Camera camera { get; set; }
        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }

        public void Initialize(Viewport viewport)
        {
            this.entities = new List<IEntity>()
            {
                new Tree(new Point(400, 50), new Rectangle(64, 32, 16, 16)),

                new MyEntity(position: new Point(8, 8), rectangleStripeFromAtlas: new Rectangle(64, 32, 16, 16)),
                new MyEntity(position: new Point(ChristianGame.WK.canvasWidth-8, 8), rectangleStripeFromAtlas: new Rectangle(80, 32, 16, 16)),
                new MyEntity(position: new Point(8, ChristianGame.WK.canvasHeight-8), rectangleStripeFromAtlas: new Rectangle(80, 32, 16, 16)),
                new MyEntity(position: new Point(ChristianGame.WK.canvasWidth-8, ChristianGame.WK.canvasHeight-8), rectangleStripeFromAtlas: new Rectangle(80, 32, 16, 16)),
                new MyEntity(position: new Point(ChristianGame.WK.canvasWidth/2, ChristianGame.WK.canvasHeight/2), rectangleStripeFromAtlas: new Rectangle(80, 32, 16, 16))
            };

            this.camera = new Camera(ChristianGame.graphicsDeviceManager.GraphicsDevice.Viewport);
            this.dxUpdateSystem = (InputState lastInputState, InputState inputState, IScene scene) => UpdateSystem(viewport, lastInputState, inputState);
        }

        public void UpdateSystem(Viewport viewport, InputState lastInputState, InputState inputState)
        {
            this.camera.MoveCamera(this.entities.OfType<Tree>().FirstOrDefault().rigidbody.rectangle.Center.ToVector2());
            this.camera.UpdateCamera(ChristianGame.graphicsDeviceManager.GraphicsDevice.Viewport);

            if (inputState.IsKeyboardKeyDown(Keys.P) && lastInputState.IsKeyboardKeyUp(Keys.P))
            {
                this.camera.AdjustZoom(1f);
            }
            else if (inputState.IsKeyboardKeyDown(Keys.Q))
            {
                this.camera.AdjustZoom(-0.01f);
            }

        }
    }
}