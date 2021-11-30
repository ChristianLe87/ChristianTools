using System;
using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Scene_Components_Map : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; }
        public Camera camera { get; private set; }
        public Map map { get; private set; }

        public Scene_Components_Map()
        {
            Initialize();
        }

        public void Initialize()
        {
            Dictionary<int, Texture2D> textures = new Dictionary<int, Texture2D>()
            {
                {0, null },
                {1, WK.Texture.DarkRed},
                {2, WK.Texture.Gray},
                {3, WK.Texture.Green}
            };

            this.map = new Map(textures, WK.Map.map1, WK.Default.ScaleFactor);
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            if (UIs != null)
                foreach (var ui in UIs)
                    ui.Update(lastInputState, inputState);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(UIs != null)
                foreach (var ui in UIs)
                    ui.Draw(spriteBatch);

            map.Draw(spriteBatch);
        }
    }
}