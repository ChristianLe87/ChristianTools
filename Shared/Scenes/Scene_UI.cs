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
        public Scene_UI()
        {
        }

        public GameState gameState => throw new NotImplementedException();

        public List<IEntity> entities { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IUI> UIs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<SoundEffect> soundEffects => throw new NotImplementedException();

        public Camera camera => throw new NotImplementedException();

        public Map map => throw new NotImplementedException();

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            throw new NotImplementedException();
        }
    }
}
