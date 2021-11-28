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
using ChristianTools.Helpers;
using ChristianTools.Components;
using Microsoft.Xna.Framework.Audio;
using ChristianTools.Entities;

namespace Showroom_dotNet5
{
    public class Scene_Shoot : IScene
    {
        public Camera camera { get; private set; }
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Map map { get; private set; }

        public Scene_Shoot()
        {
            Initialize();
        }
        public void Initialize()
        {
            this.UIs = new List<IUI>()
            {
                new Button(
                    rectangle: new Rectangle(0, WK.Default.Height - 50, 100, 50),
                    text: "Menu",
                    defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                    mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                    spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                    fontColor: Color.Black,
                    tag: "goToMenu"
                ),
            };

            entities = new List<IEntity>();

        }
        public void Update(InputState lastInputState, InputState inputState)
        {
            if (inputState.Mouse_LeftButton == ButtonState.Pressed && lastInputState.Mouse_LeftButton == ButtonState.Released)
            {
                Vector2 mousePosition = inputState.Mouse_Position.ToVector2();

                Console.WriteLine($"X: {mousePosition.X} Y: {mousePosition.Y}");

                Bullet bullet = new Bullet(
                    texture2D: Tools.Texture.CreateCircleTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 10),
                    centerPosition: WK.Default.Center.ToVector2(),
                    direction: mousePosition,
                    steps: 3,
                    autoDestroyTime: new TimeSpan(0, 0, 2)
                );

                entities.Add(bullet);
            }

            List<Bullet> bullets = entities.OfType<Bullet>().Where(x => x.isActive == true).ToList();
            foreach (var bullet in bullets)
                bullet.Update();

            Button goToMenu = UIs.OfType<Button>().Where(x => x.tag == "goToMenu").First();
            goToMenu.Update(inputState, lastInputState, () => Game1.ChangeToScene(WK.Scene.Menu));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(entities != null)
                foreach (var entity in entities)
                    entity.Draw(spriteBatch);

            foreach (var ui in UIs)
                ui.Draw(spriteBatch);
        }
    }
}
