using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using zAssets;
using zTools;
using zUI;

namespace Showroom_dotNet5
{
    public class Scene_Shoot : IScene
    {
        List<Bullet> bullets;
        MouseState lastMouseState;
        Button goToMenu;

        public Scene_Shoot()
        {
            Initialize();
        }
        public void Initialize()
        {
            bullets = new List<Bullet>();

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
            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released)
            {
                Vector2 mousePosition = mouseState.Position.ToVector2();

                Console.WriteLine($"X: {mousePosition.X} Y: {mousePosition.Y}");

                Bullet bullet = new Bullet(
                            texture2D: Tools.Texture.CreateCircleTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 10),
                            start: new Vector2(WK.Default.Width / 2, WK.Default.Height / 2),
                            direction: mousePosition,
                            steps: 3,
                            autoDestroyTime: new TimeSpan(0, 0, 2)
                );

                bullets.Add(bullet);
            }

            lastMouseState = mouseState;

            bullets = bullets.Where(x => x.isActive == true).ToList();
            foreach (var bullet in bullets) bullet.Update();

            goToMenu.Update(goToMenu_Delegate);

            void goToMenu_Delegate()
            {
                Game1.ChangeToScene(WK.Scene.Scene_Menu);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var bullet in bullets) bullet.Draw(spriteBatch);

            goToMenu.Draw(spriteBatch);
        }
    }
}
