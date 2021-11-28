using System;
using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Scene_UI : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; }
        public Camera camera { get; }
        public Map map { get; }

        public Scene_UI()
        {
            Initialize();
        }

        public void Initialize()
        {
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            foreach (var ui in UIs)
                ui.Update(lastInputState, inputState);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var ui in UIs)
                ui.Draw(spriteBatch);
        }
    }
}