using System;
using System.Collections.Generic;
using System.Linq;
using ChristianTools;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChristianTools.Entities
{
    public class Scene : IScene
    {
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public Camera camera { get; set; }
        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }

        public virtual void Initialize()
        {
            this.camera = new Camera();
            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Scene.UpdateSystem(lastInputState: lastInputState, inputState: inputState);
            this.dxDrawSystem = (SpriteBatch spriteBatch) => ChristianTools.Systems.Draw.Scene.DrawSystem(spriteBatch);
        }
    }
}