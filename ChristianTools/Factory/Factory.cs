using System;
using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools
{
    public partial class Factory
    {

    }

    public partial class Factory
    {
        public class SceneMenu : IScene
        {
            public GameState gameState { get; private set; }
            public List<IEntity> entities { get; set; }
            public List<IUI> UIs { get; set; }
            public List<SoundEffect> soundEffects { get; private set; }
            public Camera camera { get; private set; }
            public Map map { get; private set; }

            public DxUpdateSystem dxUpdateSystem { get; }
            public DxDrawSystem dxDrawSystem { get; }
            public List<ILight> lights { get; set; }

            SpriteFont spriteFont;
            string gameSceneName;

            public SceneMenu(SpriteFont spriteFont, string gameSceneName)
            {
                this.spriteFont = spriteFont;
                this.gameSceneName = gameSceneName;
            }

            public void Initialize(Vector2? playerPosition = null)
            {
                Texture2D lightGray = Tools.Tools.Texture.CreateColorTexture(Color.LightGray);
                Texture2D gray = Tools.Tools.Texture.CreateColorTexture(Color.Gray);

                this.UIs = new List<IUI>()
                {
                    new Label(new Rectangle(), spriteFont, "SceneMenu", Label.TextAlignment.Top_Left, ""),

                    new Button(new Rectangle(100, 100, 100, 100), "Play", lightGray, gray, spriteFont, "", ButtonPlaySystem),
                };
            }

            private void ButtonPlaySystem()
            {
                ChristianGame.ChangeToScene(gameSceneName);
            }
        }
    }
}