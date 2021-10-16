﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using zTools;
using zTopView_RPG;
using zUI;

namespace Showroom_dotNet5
{
    public class Scene_Camera : IScene
    {


        Button goToMenu;
        Label label;
        Player player;
        public Camera camera { get; private set; }

        public Scene_Camera()
        {
            Initialize();
        }

        public void Initialize()
        {
            goToMenu = new Button(
                rectangle: new Rectangle(0, WK.Default.Window.Pixels.Height - 50, 100, 50),
                text: "Menu",
                defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Font.Font_14), WK.Font.chars),
                fontColor: Color.Black,
                ButtonID: "goToMenu");


            label = new Label(
                rectangle: new Rectangle(50, 50, 100, 30),
                spriteFont: Tools.Font.GenerateFont(
                        texture2D: Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, "MyFont_PNG_130x28"),
                        chars: new char[,]
                        {
                                { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
                                { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },
                                { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0' },
                                { ',', ':', ';', '?', '.', '!', ' ','\'','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0' }
                        }
                ),
                text: "Test camera",
                textAlignment: Label.TextAlignment.Midle_Center, Color.Black, lineSpacing: 7 + 2
            );

            player = new Player(Tools.Texture.CreateColorTexture(graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice, color: Color.Pink));

            camera = new Camera(WK.Default.Window.Pixels.Width, WK.Default.Window.Pixels.Height);
        }

        public void Update()
        {
            goToMenu.Update(() => Game1.ChangeToScene(WK.Scene.Scene_Menu));
            player.Update();
            camera.Update(player.CenterPosition);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            label.Draw(spriteBatch);
            player.Draw(spriteBatch);
            goToMenu.Draw(spriteBatch);
        }
    }
}