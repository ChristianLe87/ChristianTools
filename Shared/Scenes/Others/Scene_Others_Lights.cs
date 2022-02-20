using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

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

        public DxUpdateSystem dxUpdateSystem { get; }
        public DxDrawSystem dxDrawSystem { get; }

        public void Initialize(Vector2? playerPosition = null)
        {
            List<ILight> lights = new List<ILight>()
            {
                new Light(new Point(50, 100), Tools.Texture.CreateCircleTexture(Color.LightYellow, ChristianGame.Default.ScaleFactor*3)),
                new LightPlayer(new Point(200, 150), Tools.Texture.CreateCircleTexture(Color.LightYellow, (ChristianGame.Default.ScaleFactor*ChristianGame.Default.AssetSize)/2)),
                //new Light(new Point(300, 100), Tools.Texture.CreateCircleTexture(Color.LightYellow, ChristianGame.Default.ScaleFactor*3)),
                //new Light(new Point(600, 100), Tools.Texture.CreateCircleTexture(Color.LightYellow, ChristianGame.Default.ScaleFactor*3)),
                new Light(new Point(300, 500), Tools.Texture.CreateCircleTexture(Color.LightYellow, ChristianGame.Default.ScaleFactor*3)),
            };

            this.map = new Map(WK.Texture.Tiles.Tiles2.tileTextures, WK.Map.lights, lights);

            this.entities = new List<IEntity>()
            {
                new Entity(WK.Texture.Tree,new Vector2(100, 100)),
            };
        }
    }


    public class LightPlayer : ILight
    {
        public Rigidbody rigidbody { get; private set; }
        public Texture2D texture { get; private set; }
        public bool isActive { get; set; }

        public DxUpdateSystem dxUpdateSystem { get; }
        public DxDrawSystem dxDrawSystem { get; }

        public LightPlayer(Point centerPosition, Texture2D texture = null, bool isActive = true)
        {
            this.texture = texture;
            this.rigidbody = new Rigidbody(Tools.GetRectangle.Rectangle(centerPosition.ToVector2(), texture));
            this.isActive = isActive;

            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem(inputState);
        }

        private void UpdateSystem(InputState inputState)
        {
            if (inputState.Right)
                rigidbody.Move_X(5);
            else if (inputState.Left)
                rigidbody.Move_X(-5);

            if (inputState.Up)
                rigidbody.Move_Y(-5);
            else if (inputState.Down)
                rigidbody.Move_Y(5);
        }
    }
}