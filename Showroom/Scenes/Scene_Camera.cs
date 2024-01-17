using System;
using System.Collections.Generic;
using System.Linq;
using ChristianTools;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.UI;
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
            this.UIs = new List<IUI>()
            {
                new Label(
                    rectangle: new Rectangle(260, 10, 230, 30),
                    "Camera",
                    textAlignment: Label.TextAlignment.Midle_Center
                ),
                new Button(
                    rectangle: new Rectangle(10, 10, 230, 30),
                    text: "Go to menu",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Game1.ChangeToScene("Scene_Menu")
                )
            };
            
            this.entities = new List<IEntity>()
            {
                new Tree(new Point(400, 50), new Rectangle(64, 32, 16, 16)),

                new MyEntity(position: new Point(8, 8), rectangleStripeFromAtlas: new Rectangle(64, 32, 16, 16)),
                new MyEntity(position: new Point(ChristianGame.WK.canvasWidth-8, 8), rectangleStripeFromAtlas: new Rectangle(80, 32, 16, 16)),
                new MyEntity(position: new Point(8, ChristianGame.WK.canvasHeight-8), rectangleStripeFromAtlas: new Rectangle(80, 32, 16, 16)),
                new MyEntity(position: new Point(ChristianGame.WK.canvasWidth-8, ChristianGame.WK.canvasHeight-8), rectangleStripeFromAtlas: new Rectangle(80, 32, 16, 16)),
                new MyEntity(position: new Point(ChristianGame.WK.canvasWidth/2, ChristianGame.WK.canvasHeight/2), rectangleStripeFromAtlas: new Rectangle(80, 32, 16, 16))
            };

            this.camera = new Camera();
            this.dxUpdateSystem = (InputState lastInputState, InputState inputState, IScene scene) => UpdateSystem(viewport, lastInputState, inputState);
        }

        public void UpdateSystem(Viewport viewport, InputState lastInputState, InputState inputState)
        {
            if (inputState.Mouse_LeftButton == ButtonState.Pressed)
            {
                Console.WriteLine("on world: " + inputState.Mouse_OnWorldPosition());
                Console.WriteLine("on window: " + inputState.Mouse_OnWindowPosition());
                Console.WriteLine(camera.Zoom);
            } 
            
            this.camera.MoveCamera(this.entities.OfType<Tree>().FirstOrDefault().rigidbody.rectangle.Center);
            this.camera.UpdateCamera();

            if (inputState.IsKeyboardKeyDown(Keys.P))
            {
                this.camera.AdjustZoom(0.01f);
            }
            else if (inputState.IsKeyboardKeyDown(Keys.Q))
            {
                this.camera.AdjustZoom(-0.01f);
            }

        }
    }
}