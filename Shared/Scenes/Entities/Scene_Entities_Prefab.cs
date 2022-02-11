using System;
using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Scene_Entities_Prefab : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<ILight> lights { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Camera camera { get; private set; }
        public Map map { get; private set; }

        public DxUpdateSystem dxUpdateSystem { get; }
        public DxDrawSystem dxDrawSystem { get; }

        public void Initialize(Vector2? playerPosition = null)
        {
        }
    }
}