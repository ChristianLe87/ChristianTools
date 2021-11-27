using System;
using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Showroom_dotNet5
{
    public class Scene_ToolsOthers : IScene
    {
        public Camera camera { get; private set; }
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Map map { get; private set; }

        public Scene_ToolsOthers()
        {
            Initialize();
        }

        public void Initialize()
        {
            // create line that go from (x: -250, y: 0) to (x: 250, y: 0)
            // and line that go from (x: 0, y: -250) to (x: 0, y: 250)

            // Set camera to point (X: 0, Y: 0)

            // create triangle on (x:0, y:0) face right (x: 250, y:0)
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            // on click, rotate triangle to face mouse
            // shoot bullet direction of mouse click
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}