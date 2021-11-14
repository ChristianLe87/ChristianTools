using System;
using System.Collections.Generic;
using System.Linq;
using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using zAssets;
using zTools;
using ChristianTools.UI;

namespace Showroom_dotNet5
{
    public class Scene_Shoot : IScene
    {
        public Camera camera { get; }

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
                             rectangle: new Rectangle(0, WK.Default.Window.Pixels.Height - 50, 100, 50),
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
                Point mousePosition = mouseState.Position;

                Console.WriteLine($"X: {mousePosition.X} Y: {mousePosition.Y}");

                Bullet bullet = new Bullet(
                            texture2D: Tools.Texture.CreateCircleTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 10),
                            start: WK.Default.Window.Pixels.Center,
                            direction: mousePosition,
                            steps: 3,
                            autoDestroyTime: new TimeSpan(0, 0, 2)
                );

                bullets.Add(bullet);
            }

            lastMouseState = mouseState;

            bullets = bullets.Where(x => x.isActive == true).ToList();
            foreach (var bullet in bullets) bullet.Update();

            goToMenu.Update(() => Game1.ChangeToScene(WK.Scene.Scene_Menu));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var bullet in bullets) bullet.Draw(spriteBatch);

            goToMenu.Draw(spriteBatch);
        }
    }
}
