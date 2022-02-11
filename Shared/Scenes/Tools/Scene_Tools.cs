using System;
using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Tools;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Scene_Tools : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<Light> lights { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Camera camera { get; private set; }
        public Map map { get; private set; }

        public DxUpdateSystem dxUpdateSystem { get; }
        public DxDrawSystem dxDrawSystem { get; private set; }

        Texture2D subAtlas_1;
        Texture2D subAtlas_2;
        Texture2D subAtlas_3;
        Texture2D subAtlas_4;

        Texture2D circle_1;
        Texture2D circle_2;
        Texture2D circle_3;
        Texture2D circle_4;

        Texture2D triangle_Up;
        Texture2D triangle_Down;
        Texture2D triangle_Right;
        Texture2D triangle_Left;

        Texture2D fontMap;
        Texture2D fontMap_Green;
        Texture2D fontMap_Red;

        Texture2D textureNormal;
        Texture2D textureFlippedHorizontal;


        public void Initialize(Vector2? playerPosition = null)
        {
            subAtlas_1 = Tools.Texture.CropTexture(
                originalTexture: Tools.Texture.GetTexture("MyAtlasTexture"),
                extractRectangle: new Rectangle(0, 0, 50, 50)
            );
            subAtlas_2 = Tools.Texture.CropTexture(
                originalTexture: Tools.Texture.GetTexture("MyAtlasTexture"),
                extractRectangle: new Rectangle(50, 0, 50, 50)
            );
            subAtlas_3 = Tools.Texture.CropTexture(
                originalTexture: Tools.Texture.GetTexture("MyAtlasTexture"),
                extractRectangle: new Rectangle(0, 50, 50, 50)
            );
            subAtlas_4 = Tools.Texture.CropTexture(
                originalTexture: Tools.Texture.GetTexture("MyAtlasTexture"),
                extractRectangle: new Rectangle(50, 50, 50, 50)
            );

            circle_1 = Tools.Texture.CreateCircleTexture(Color.Green, 3);
            circle_2 = Tools.Texture.CreateCircleTexture(Color.Green, 4);
            circle_3 = Tools.Texture.CreateCircleTexture(Color.Green, 25);
            circle_4 = Tools.Texture.CreateCircleTexture(Color.Green, 26);

            triangle_Up = Tools.Texture.CreateTriangle(
                color: Color.Red,
                Width: 40,
                Height: 40,
                pointDirection: Tools.Texture.PointDirection.Up
            );
            triangle_Down = Tools.Texture.CreateTriangle(
                color: Color.Red,
                Width: 40,
                Height: 40,
                pointDirection: Tools.Texture.PointDirection.Down
            );
            triangle_Right = Tools.Texture.CreateTriangle(
                color: Color.Red,
                Width: 40,
                Height: 40,
                pointDirection: Tools.Texture.PointDirection.Right
            );
            triangle_Left = Tools.Texture.CreateTriangle(
                color: Color.Red,
                Width: 40,
                Height: 40,
                pointDirection: Tools.Texture.PointDirection.Left
            );

            fontMap = Tools.Texture.GetTexture("MyFont_130x28_PNG");

            fontMap_Green = Tools.Texture.ReColorTexture(fontMap, Color.Green);
            fontMap_Red = Tools.Texture.ReColorTexture(fontMap, Color.Red);

            textureNormal = Tools.Texture.GetTexture("MyAtlasTexture");
            textureFlippedHorizontal = Tools.Texture.FlipHorizontal(textureNormal);

            this.UIs = new List<IUI>()
            {
                new Button(
                    rectangle: new Rectangle(0, 470, 230, 30),
                    text: "<- Menu",
                    defaultTexture: WK.Texture.LightGray,
                    mouseOverTexture: WK.Texture.Gray,
                    spriteFont: WK.Font.font_7,
                    tag: "goToMenu",
                    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Menu)
                )
            };

            this.dxDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
        }

        private void DrawSystem(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(subAtlas_1, new Vector2(200, 200), Color.White);
            spriteBatch.Draw(subAtlas_2, new Vector2(275, 200), Color.White);
            spriteBatch.Draw(subAtlas_3, new Vector2(200, 275), Color.White);
            spriteBatch.Draw(subAtlas_4, new Vector2(275, 275), Color.White);

            spriteBatch.Draw(circle_1, new Vector2(25, 250), Color.White);
            spriteBatch.Draw(circle_2, new Vector2(35, 250), Color.White);
            spriteBatch.Draw(circle_3, new Vector2(45, 250), Color.White);
            spriteBatch.Draw(circle_4, new Vector2(100, 250), Color.White);

            spriteBatch.Draw(triangle_Up, new Vector2(50, 50), Color.White);
            spriteBatch.Draw(triangle_Down, new Vector2(50, 100), Color.White);
            spriteBatch.Draw(triangle_Right, new Vector2(50, 150), Color.White);
            spriteBatch.Draw(triangle_Left, new Vector2(50, 200), Color.White);

            spriteBatch.Draw(fontMap_Green, new Vector2(200, 20), Color.White);
            spriteBatch.Draw(fontMap_Red, new Vector2(200, 80), Color.White);

            spriteBatch.Draw(textureNormal, new Vector2(50, 350), Color.White);
            spriteBatch.Draw(textureFlippedHorizontal, new Vector2(200, 350), Color.White);
        }
    }
}