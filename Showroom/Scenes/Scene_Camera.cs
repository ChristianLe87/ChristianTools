using System;
using System.Collections.Generic;
using System.Linq;
using ChristianTools;
using ChristianTools.Components;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Showroom.Scenes
{
    public class Scene_Camera : Scene
    {
        public override void Initialize()
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
                new MyEntity(position: new Point(8, 8), rectangleStripeFromAtlas: new Rectangle(64, 32, 16, 16), tag: "player"),

                new Entity(position: new Point(8, 8), rectangleStripeFromAtlas: new Rectangle(64, 32, 16, 16)),
                new Entity(position: new Point(ChristianGame.WK.canvasWidth - 8, 8), rectangleStripeFromAtlas: new Rectangle(80, 32, 16, 16)),
                new Entity(position: new Point(8, ChristianGame.WK.canvasHeight - 8), rectangleStripeFromAtlas: new Rectangle(80, 32, 16, 16)),
                new Entity(position: new Point(ChristianGame.WK.canvasWidth - 8, ChristianGame.WK.canvasHeight - 8), rectangleStripeFromAtlas: new Rectangle(80, 32, 16, 16)),
                new Entity(position: new Point(ChristianGame.WK.canvasWidth / 2, ChristianGame.WK.canvasHeight / 2), rectangleStripeFromAtlas: new Rectangle(80, 32, 16, 16))
            };

            this.camera = new Camera();

            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem(lastInputState: lastInputState, inputState: inputState);
            this.dxDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
        }
    }
}