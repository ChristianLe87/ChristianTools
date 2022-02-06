﻿using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace My_EasyTests_Core
{
    public class SceneGame : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Camera camera { get; private set; }
        public Map map { get; private set; }
        public DxSceneUpdateSystem dxSceneUpdateSystem { get; private set; }
        public DxSceneDrawSystem dxSceneDrawSystem { get; private set; }

        public List<Point> lights;

        public void Initialize(Vector2? playerPosition = null)
        {
            playerPosition = new Vector2(200, 200);

            this.entities = new List<IEntity>()
            {
                //new Tree(new Vector2(200, 200)),
                new Player(playerPosition.Value),
                //new Thing1(new Vector2(500, 200))
            };

            this.map = new Map(WK.Texture.Tiles.tileTextures, WK.Map.map0);

            this.lights = new List<Point>()
            {
                playerPosition.Value.ToPoint()
            };
        }
    }
}