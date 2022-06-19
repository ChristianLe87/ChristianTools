using System.Collections.Generic;
using System.Linq;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Tools;
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

            List<ILight> lights = new List<ILight>()
            {
                new Light(new Point(50, 100), Tools.Texture.CreateCircleTexture(Color.LightYellow, ChristianGame.Default.ScaleFactor*3)),
                new LightPlayer(new Point(200, 150), Tools.Texture.CreateCircleTexture(Color.LightYellow, ChristianGame.Default.ScaleFactor*ChristianGame.Default.AssetSize/3)),
                //new Light(new Point(300, 100), Tools.Texture.CreateCircleTexture(Color.LightYellow, ChristianGame.Default.ScaleFactor*3)),
                //new Light(new Point(600, 100), Tools.Texture.CreateCircleTexture(Color.LightYellow, ChristianGame.Default.ScaleFactor*3)),
                new Light(new Point(300, 500), Tools.Texture.CreateCircleTexture(Color.LightYellow, ChristianGame.Default.ScaleFactor*3)),
            };

            this.map = new Map(WK.Texture.Tiles.Tiles2.tileTextures, tiled_JSON, lights);

            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem();
            this.camera = new Camera();
        }

        private void UpdateSystem()
        {
            LightPlayer lightPlayer = map.lights.OfType<LightPlayer>().First();
            ChristianTools.Systems.Systems.Update.Camera(this.camera, lightPlayer.rigidbody.centerPosition);
        }
    }
}