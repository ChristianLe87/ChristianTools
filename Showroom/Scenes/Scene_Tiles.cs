using System.Collections.Generic;
using System.IO;
using ChristianTools.Components;
using ChristianTools.Components.Tiled;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Showroom.Scenes
{
    public class Scene_Tiles : IScene
    {
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public Map map { get; set; }
        public Camera camera { get; set; }
        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }

        public void Initialize()
        {
            this.entities = new List<IEntity>()
            {
                //new Entity_Platformer_Player(new Point(24, 128)),
            };

            this.UIs = new List<IUI>()
            {
                // Back to menu
                new Button(rectangle: new Rectangle(10, 400, 100, 50), text: "<-- Back to menu", defaultTexture: null, mouseOverTexture: null, tag: "", OnClickAction: () => Game1.ChangeToScene("Scene_Menu")),
            };

            this.map = new Map(mainTiles: new List<Tile>() );

            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Scene.UpdateSystem(lastInputState: lastInputState, inputState: inputState);
            this.dxDrawSystem = (SpriteBatch spriteBatch) => ChristianTools.Systems.Draw.Scene.DrawSystem(spriteBatch);
        }
    }
}