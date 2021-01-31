using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using zAssets;
using zTools;
using zUI;

namespace Showroom_dotNet5
{
    public class Scene_Assets : IScene
    {
        Bullet bullet;
        Button goToMenu;

        public Scene_Assets()
        {
            Initialize();
        }

        public void Initialize()
        {
            bullet = new Bullet(start: new Vector2(0, 400), direction: new Vector2(300, 700));
            goToMenu = new Button(
                            rectangle: new Rectangle(50, 400, 100, 50),
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
            bullet.Update();
            goToMenu.Update(goToMenu_Delegate);


            void goToMenu_Delegate(){
                Game1.ChangeToScene(WK.Scene.Scene_Menu);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            bullet.Draw(spriteBatch);
            goToMenu.Draw(spriteBatch);
        }
    }
}
