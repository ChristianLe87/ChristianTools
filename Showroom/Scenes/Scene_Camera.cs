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

            Rectangle _1R = new Rectangle(16, 16, 16, 16);
            Rectangle _2R = new Rectangle(32, 16, 16, 16);
            Rectangle _3R = new Rectangle(64, 16, 16, 16);
            
            Rectangle _1B = new Rectangle(16, 32, 16, 16);
            Rectangle _2B = new Rectangle(32, 32, 16, 16);
            Rectangle _3B = new Rectangle(64, 32, 16, 16);
            
            Rectangle _1G = new Rectangle(16, 48, 16, 16);
            Rectangle _2G = new Rectangle(32, 48, 16, 16);
            Rectangle _3G = new Rectangle(64, 48, 16, 16);

            this.entities = new List<IEntity>()
            {
                new MyEntity(position: new Point(8, 8), rectangleStripeFromAtlas: _2B, tag: "player"),

                // TL
                new Entity(position: new Point(8, 8), rectangleStripeFromAtlas: _1R),
                // TR
                new Entity(position: new Point(ChristianGame.WK.canvasWidth - 8, 8), rectangleStripeFromAtlas: _3R),
                // DL
                new Entity(position: new Point(8, ChristianGame.WK.canvasHeight - 8), rectangleStripeFromAtlas:_1G),
                // DR
                new Entity(position: new Point(ChristianGame.WK.canvasWidth - 8, ChristianGame.WK.canvasHeight - 8), rectangleStripeFromAtlas: _3G),
                // center
                new Entity(position: new Point(ChristianGame.WK.canvasWidth / 2, ChristianGame.WK.canvasHeight / 2), rectangleStripeFromAtlas: new Rectangle(32, 32, 16, 16))
            };

            this.camera = new Camera();

            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Scene.UpdateSystem(lastInputState: lastInputState, inputState: inputState);
            this.dxDrawSystem = (SpriteBatch spriteBatch) => ChristianTools.Systems.Draw.Scene.DrawSystem(spriteBatch);
        }
    }
}