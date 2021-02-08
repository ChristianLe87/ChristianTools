using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using zTools;
using zUI;

namespace Showroom_dotNet5
{
    public class Scene_Tools : IScene
    {
        Texture2D subAtlas_1;
        Texture2D subAtlas_2;
        Texture2D subAtlas_3;
        Texture2D subAtlas_4;

        Texture2D circle_1;
        Texture2D circle_2;
        Texture2D circle_3;
        Texture2D circle_4;

        Texture2D triangle_1;
        Texture2D triangle_2;
        Texture2D triangle_3;
        Texture2D triangle_4;

        Button goToMenu;

        public Scene_Tools()
        {
            Initialize();
        }

        public void Initialize()
        {
            subAtlas_1 = Tools.Texture.CropTexture(
                            graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                            originalTexture2D: Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, "MyAtlasTexture"),
                            extractRectangle: new Rectangle(0, 0, 50, 50)
                         );
            subAtlas_2 = Tools.Texture.CropTexture(
                            graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                            originalTexture2D: Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, "MyAtlasTexture"),
                            extractRectangle: new Rectangle(50, 0, 50, 50)
                         );
            subAtlas_3 = Tools.Texture.CropTexture(
                            graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                            originalTexture2D: Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, "MyAtlasTexture"),
                            extractRectangle: new Rectangle(0, 50, 50, 50)
                         );
            subAtlas_4 = Tools.Texture.CropTexture(
                            graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                            originalTexture2D: Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, "MyAtlasTexture"),
                            extractRectangle: new Rectangle(50, 50, 50, 50)
                         );

            circle_1 = Tools.Texture.CreateCircleTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 3);
            circle_2 = Tools.Texture.CreateCircleTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 4);
            circle_3 = Tools.Texture.CreateCircleTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 25);
            circle_4 = Tools.Texture.CreateCircleTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 26);


            triangle_1 = zTools.Tools.Texture.CreateTriangle(
                                                        graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                                                        color: Color.Red,
                                                        Width: 40,
                                                        Height: 40
            );

            triangle_2 = zTools.Tools.Texture.CreateTriangle(
                                                        graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                                                        color: Color.Red,
                                                        Width: 40,
                                                        Height: 40
            );

            triangle_3 = zTools.Tools.Texture.CreateTriangle(
                                                        graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                                                        color: Color.Red,
                                                        Width: 40,
                                                        Height: 40
            );

            triangle_4 = zTools.Tools.Texture.CreateTriangle(
                                                        graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                                                        color: Color.Red,
                                                        Width: 40,
                                                        Height: 40
            );

            goToMenu = new Button(
                            rectangle: new Rectangle(0, WK.Default.Height - 50, 100, 50),
                            text: "Menu",
                            defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                            mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                            spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                            fontColor: Color.Black,
                            ButtonID: "goToMenu"
            );
        }

        public void Update()
        {
            goToMenu.Update(goToMenu_Delegate);

            void goToMenu_Delegate()
            {
                Game1.ChangeToScene(WK.Scene.Scene_Menu);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(subAtlas_1, new Vector2(200, 200), Color.White);
            spriteBatch.Draw(subAtlas_2, new Vector2(275, 200), Color.White);
            spriteBatch.Draw(subAtlas_3, new Vector2(200, 275), Color.White);
            spriteBatch.Draw(subAtlas_4, new Vector2(275, 275), Color.White);

            spriteBatch.Draw(circle_1, new Vector2(25, 250), Color.White);
            spriteBatch.Draw(circle_2, new Vector2(35, 250), Color.White);
            spriteBatch.Draw(circle_3, new Vector2(45, 250), Color.White);
            spriteBatch.Draw(circle_4, new Vector2(100, 250), Color.White);

            spriteBatch.Draw(triangle_1, new Vector2(50, 50), Color.White);
            spriteBatch.Draw(triangle_2, new Vector2(50, 100), Color.White);
            spriteBatch.Draw(triangle_3, new Vector2(50, 150), Color.White);
            spriteBatch.Draw(triangle_4, new Vector2(50, 200), Color.White);

            goToMenu.Draw(spriteBatch);
        }


    }
}
