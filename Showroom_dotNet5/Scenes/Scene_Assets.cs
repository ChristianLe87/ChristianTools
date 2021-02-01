using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using zAssets;
using zTools;
using zUI;

namespace Showroom_dotNet5
{
    public class Scene_Assets : IScene
    {
        List<Bullet> Bullets_at_45_degrees = new List<Bullet>();
        List<Bullet> Bullets_at_90_degrees = new List<Bullet>();

        Button goToMenu;

        public Scene_Assets()
        {
            Initialize();
        }

        public void Initialize()
        {
            Bullets_at_45_degrees = new List<Bullet>()
            {
                // up_Left
                new Bullet(
                            texture2D: Tools.Texture.CreateCircleTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Black, 10),
                            start: new Vector2(WK.Default.Width / 2, WK.Default.Height / 2),
                            direction: new Vector2(0, 0),
                            steps: 1,
                            autoDestroyTime: new TimeSpan(0,0,0,2,0)
                ),
                // down_right
                new Bullet(
                            texture2D: Tools.Texture.CreateCircleTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 10),
                            start: new Vector2(WK.Default.Width / 2, WK.Default.Height / 2),
                            direction: new Vector2(WK.Default.Width, WK.Default.Height),
                            steps: 1,
                            autoDestroyTime: new TimeSpan(0,0,0,2,0)
                ),
                // up_right
                new Bullet(
                            texture2D: Tools.Texture.CreateCircleTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Pink, 10),
                            start: new Vector2(WK.Default.Width / 2, WK.Default.Height / 2),
                            direction: new Vector2(WK.Default.Width, 0),
                            steps: 1,
                            autoDestroyTime: new TimeSpan(0,0,0,2,0)
                ),
                // down_left
                new Bullet(
                            texture2D: Tools.Texture.CreateCircleTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Blue, 10),
                            start: new Vector2(WK.Default.Width / 2, WK.Default.Height / 2),
                            direction: new Vector2(0, WK.Default.Height),
                            steps: 1,
                            autoDestroyTime: new TimeSpan(0,0,0,2,0)
                )
            };

            Bullets_at_90_degrees = new List<Bullet>()
            {
                // Left
                new Bullet(
                            texture2D: Tools.Texture.CreateCircleTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Black, 10),
                            start: new Vector2(WK.Default.Width / 2, WK.Default.Height / 2),
                            direction: new Vector2(0, WK.Default.Height / 2),
                            steps: 1,
                            autoDestroyTime: new TimeSpan(0,0,0,2,0)
                ),
                // Right
                new Bullet(
                            texture2D: Tools.Texture.CreateCircleTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 10),
                            start: new Vector2(WK.Default.Width / 2, WK.Default.Height / 2),
                            direction: new Vector2(WK.Default.Width, WK.Default.Height / 2),
                            steps: 1,
                            autoDestroyTime: new TimeSpan(0,0,0,2,0)
                ),
                // Up
                new Bullet(
                            texture2D: Tools.Texture.CreateCircleTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Pink, 10),
                            start: new Vector2(WK.Default.Width / 2, WK.Default.Height / 2),
                            direction: new Vector2(WK.Default.Width / 2, 0),
                            steps: 1,
                            autoDestroyTime: new TimeSpan(0,0,0,2,0)
                ),
                // down
                new Bullet(
                            texture2D: Tools.Texture.CreateCircleTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Blue, 10),
                            start: new Vector2(WK.Default.Width / 2, WK.Default.Height / 2),
                            direction: new Vector2(WK.Default.Width / 2, WK.Default.Height),
                            steps: 1,
                            autoDestroyTime: new TimeSpan(0,0,0,2,0)
                )
            };

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
            foreach (var bullet in Bullets_at_45_degrees) bullet.Update();
            foreach (var bullet in Bullets_at_90_degrees) bullet.Update();

            goToMenu.Update(goToMenu_Delegate);

            void goToMenu_Delegate()
            {
                Game1.ChangeToScene(WK.Scene.Scene_Menu);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var bullet in Bullets_at_45_degrees) bullet.Draw(spriteBatch);
            foreach (var bullet in Bullets_at_90_degrees) bullet.Draw(spriteBatch);

            goToMenu.Draw(spriteBatch);
        }
    }
}
