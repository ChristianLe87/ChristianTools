using System;
using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework.Graphics;

namespace Showroom_dotNet5
{
    public class Scene_ToolsOthers:IScene
    {
        public Camera camera { get; }
        public GameState gameState { get; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public Map map { get; }

        public Scene_ToolsOthers()
        {
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Update(InputState lastInputState, InputState inputState)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
