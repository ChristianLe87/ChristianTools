using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using zAssets;
using zTools;

namespace Showroom_dotNet5
{
    public class Scene_Shoot : IScene
    {
        List<Bullet> bullets;
        MouseState lastMouseState;

        public Scene_Shoot()
        {
            Initialize();
        }
        public void Initialize()
        {
            bullets = new List<Bullet>();
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
                            steps: 1
                );

                bullets.Add(bullet);
            }

            lastMouseState = mouseState;

            foreach (var bullet in bullets) bullet.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var bullet in bullets) bullet.Draw(spriteBatch);
        }
    }
}
