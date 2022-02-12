using ChristianTools.Components;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using ChristianTools.Tools;

namespace My_EasyTests_Core
{
    public class SceneGame : IScene
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
            int[] map1 = tiled_JSON.layers[0].chunks[0].data;

            int[,] chunk1 = Tools.Other.ToMultidimentional(map1, tiled_JSON.layers[0].chunks[0].width, tiled_JSON.layers[0].chunks[0].height);
            this.map = new Map(WK.Texture.Tiles.tileTextures, chunk1);
        }
    }
}