using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using zAssets;
using zTools;
using ChristianTools.UI;

namespace Showroom_dotNet5
{
    public class Scene_Menu : IScene
    {
        public Camera camera { get; }

        Button goToUI;
        Button goToShoot;
        Button goToTools;
        Button goToAnimations;
        Line line1;

        Button goToAssets;
        Button goToDialogue;
        Button goToPhysics;
        Button goToCamera;
        Line line2;

        Button GoToPlayground1;
        Button GoToPlayground2;

        public Scene_Menu()
        {
            Initialize();
        }

        public void Initialize()
        {
            // Column 1
            goToUI = new Button(
                            rectangle: new Rectangle(50, 50, 100, 50),
                            text: "UI",
                            defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                            mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                            spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                            fontColor: Color.Black,
                            ButtonID: "goToUI"
            );

            goToShoot = new Button(
                            rectangle: new Rectangle(50, 150, 100, 50),
                            text: "Shoot",
                            defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                            mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                            spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                            fontColor: Color.Black,
                            ButtonID: "goToShoot"
            );

            goToTools = new Button(
                            rectangle: new Rectangle(50, 250, 100, 50),
                            text: "Tools",
                            defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                            mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                            spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                            fontColor: Color.Black,
                            ButtonID: "goToTools"
            );

            goToAnimations = new Button(
                            rectangle: new Rectangle(50, 350, 100, 50),
                            text: "Animations",
                            defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                            mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                            spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                            fontColor: Color.Black,
                            ButtonID: "goToAnimations"
            );

            // Column 2
            goToAssets = new Button(
                            rectangle: new Rectangle(200, 50, 100, 50),
                            text: "Assets",
                            defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                            mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                            spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                            fontColor: Color.Black,
                            ButtonID: "goToAssets"
            );

            goToDialogue = new Button(
                            rectangle: new Rectangle(200, 150, 100, 50),
                            text: "Dialogue",
                            defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                            mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                            spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                            fontColor: Color.Black,
                            ButtonID: "goToDialogue"
            );

            goToPhysics = new Button(
                            rectangle: new Rectangle(200, 250, 100, 50),
                            text: "Physics",
                            defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                            mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                            spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                            fontColor: Color.Black,
                            ButtonID: "goToPhysics"
            );

            goToCamera = new Button(
                rectangle: new Rectangle(200, 350, 100, 50),
                text: "Camera",
                defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                fontColor: Color.Black,
                ButtonID: "goToCamera"
);

            // Column 3
            GoToPlayground1 = new Button(
                            rectangle: new Rectangle(350, 50, 100, 50),
                            text: "Playground1",
                            defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                            mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                            spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                            fontColor: Color.Black,
                            ButtonID: "GoToPlayground1"
            );

            GoToPlayground2 = new Button(
                rectangle: new Rectangle(350, 150, 100, 50),
                text: "Playground2",
                defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                fontColor: Color.Black,
                ButtonID: "GoToPlayground2"
);

            // Lines
            line1 = new Line(
                start: new Point(175, 0),
                end: new Point(175, 500),
                thickness: 2,
                texture2D: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Black)
            );


            line2 = new Line(
                start: new Point(325, 0),
                end: new Point(325, 500),
                thickness: 2,
                texture2D: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Black)
            );
        }

        public void Update()
        {
            goToUI.Update(() => Game1.ChangeToScene(WK.Scene.Scene_UI));
            goToShoot.Update(() => Game1.ChangeToScene(WK.Scene.Scene_Shoot));
            goToTools.Update(() => Game1.ChangeToScene(WK.Scene.Scene_Tools));
            goToAnimations.Update(() => Game1.ChangeToScene(WK.Scene.Scene_Animations));

            goToAssets.Update(() => Game1.ChangeToScene(WK.Scene.Scene_Assets));
            goToDialogue.Update(() => Game1.ChangeToScene(WK.Scene.Scene_Dialogue));
            goToPhysics.Update(() => Game1.ChangeToScene(WK.Scene.Scene_Physics));
            goToCamera.Update(() => Game1.ChangeToScene(WK.Scene.Scene_Camera));

            GoToPlayground1.Update(()=>Game1.ChangeToScene(WK.Scene.Scene_Playground_1));
            GoToPlayground2.Update(() => Game1.ChangeToScene(WK.Scene.Scene_Playground_2));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            goToUI.Draw(spriteBatch);
            goToShoot.Draw(spriteBatch);
            goToTools.Draw(spriteBatch);
            goToAnimations.Draw(spriteBatch);

            goToAssets.Draw(spriteBatch);
            goToDialogue.Draw(spriteBatch);
            goToPhysics.Draw(spriteBatch);
            goToCamera.Draw(spriteBatch);

            GoToPlayground1.Draw(spriteBatch);
            GoToPlayground2.Draw(spriteBatch);

            line1.Draw(spriteBatch);
            line2.Draw(spriteBatch);
        }
    }
}
