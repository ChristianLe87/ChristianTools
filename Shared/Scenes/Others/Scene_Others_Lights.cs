using System;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using ChristianTools.Tools;
using ChristianTools.Entities;

namespace Shared
{
    public class Scene_Others_Lights : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Camera camera { get; private set; }
        public Map map { get; private set; }

        public DxSceneUpdateSystem dxSceneUpdateSystem { get; private set; }
        public DxSceneDrawSystem dxSceneDrawSystem { get; private set; }

        public void Initialize(Vector2? playerPosition = null)
        {
            List<Light> lights = new List<Light>()
            {
                new Light(new Point(50, 100), Tools.Texture.CreateCircleTexture(Color.LightYellow, ChristianGame.Default.ScaleFactor*3)),
                new Light(new Point(300, 100), Tools.Texture.CreateCircleTexture(Color.LightYellow, ChristianGame.Default.ScaleFactor*3)),
                new Light(new Point(600, 100), Tools.Texture.CreateCircleTexture(Color.LightYellow, ChristianGame.Default.ScaleFactor*3)),
                new Light(new Point(300, 500), Tools.Texture.CreateCircleTexture(Color.LightYellow, ChristianGame.Default.ScaleFactor*3)),
            };

            this.map = new Map(WK.Texture.Tiles.tileTextures, WK.Map.lights, lights);

            this.entities = new List<IEntity>()
            {
                new Entity(WK.Texture.Tree,new Vector2(100, 100))
            };
        }
    }
}