using System.Collections.Generic;
using ChristianTools;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Showroom.Scenes
{
    public class Scene_Camera : IScene
    {
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public Camera camera { get; set; }
        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }

        private Texture2D testTexture1;
        private Texture2D testTexture2;
        private Texture2D testTexture3;

        public void Initialize()
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
            Rectangle _3R = new Rectangle(48, 16, 16, 16);

            Rectangle _1B = new Rectangle(16, 32, 16, 16);
            Rectangle _2B = new Rectangle(32, 32, 16, 16);
            Rectangle _3B = new Rectangle(48, 32, 16, 16);

            Rectangle _1G = new Rectangle(16, 48, 16, 16);
            Rectangle _2G = new Rectangle(32, 48, 16, 16);
            Rectangle _3G = new Rectangle(48, 48, 16, 16);

            this.entities = new List<IEntity>()
            {
                new Entity_WASD(centerPosition: new Point(8, 8), rectangleStripeFromAtlas: _2B, tag: "player"),

                // TL
                new Entity_Numbers(centerPosition: new Point(8, 8), rectangleStripeFromAtlas: _1R, tag: "TL"),
                // TR
                new Entity_Numbers(centerPosition: new Point(ChristianGame.WK.canvasWidth - 8, 8), rectangleStripeFromAtlas: _3R),
                // DL
                new Entity_Numbers(centerPosition: new Point(8, ChristianGame.WK.canvasHeight - 8), rectangleStripeFromAtlas: _1G),
                // DR
                new Entity_Numbers(centerPosition: new Point(ChristianGame.WK.canvasWidth - 8, ChristianGame.WK.canvasHeight - 8), rectangleStripeFromAtlas: _3G),
                // center
                new Entity_Numbers(centerPosition: new Point(ChristianGame.WK.canvasWidth / 2, ChristianGame.WK.canvasHeight / 2), rectangleStripeFromAtlas: new Rectangle(32, 32, 16, 16))
            };

            this.camera = new Camera(new Point(250,250));

            this.testTexture1 = ChristianTools.Helpers.Texture.CreateColorTexture(Color.Black, 500, 500);
            this.testTexture2 = ChristianTools.Helpers.Texture.CreateColorTexture(Color.White, 490, 490);
            this.testTexture3 = ChristianTools.Helpers.Texture.CreateColorTexture(Color.Green, 50, 50);

            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Scene.UpdateSystem(lastInputState: lastInputState, inputState: inputState);
            this.dxDrawSystem = (SpriteBatch spriteBatch) => DrawSystem_Test(spriteBatch);
        }

        private void DrawSystem_Test(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(testTexture1, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(testTexture2, new Vector2(5, 5), Color.White);
            spriteBatch.Draw(testTexture3, new Vector2(5, 5), Color.White);

            ChristianTools.Systems.Draw.Scene.DrawSystem(spriteBatch);
        }
    }
}