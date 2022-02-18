﻿using System;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Shared
{
    public class Scene_Others_Tiled : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<Light> lights { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Camera camera { get; private set; }
        public Map map { get; private set; }

        public DxUpdateSystem dxUpdateSystem { get; private set; }
        public DxDrawSystem dxDrawSystem { get; private set; }

        public void Initialize(Vector2? playerPosition = null)
        {
            Tiled tiled_JSON = Tiled_JsonSerialization.Read<Tiled>("Map1");

            this.map = new Map(WK.Texture.Tiles.Tiles1.tileTextures, tiled_JSON);
        }
    }
}