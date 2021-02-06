using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using zAssets;
using zTools;
using zUI;

namespace Showroom_dotNet5
{
    public class Scene_Triangle : IScene
    {
        Texture2D triangle;
        Button goToMenu;

        public Scene_Triangle()
        {
            Initialize();
        }

        public void Initialize()
        {
            triangle = zTools.Tools.Texture.CreateTriangle(
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
            spriteBatch.Draw(triangle, new Rectangle(WK.Default.Width / 2, WK.Default.Height / 2, triangle.Width, triangle.Height), Color.White);
            goToMenu.Draw(spriteBatch);
        }


    }
}
