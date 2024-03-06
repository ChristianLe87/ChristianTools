using System.Collections.Generic;
using System.Linq;
using ChristianTools;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;

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
                new Entity_Platformer_Player(new Rectangle(24, 128, 16, 16), WK.AtlasReferences._2, "player"),
            };

            this.UIs = new List<IUI>()
            {
                // Back to menu
                new Button(rectangle: new Rectangle(10, 400, 100, 50), text: "<-- Back to menu", defaultTexture: null, mouseOverTexture: null, tag: "", OnClickAction: () => Game1.ChangeToScene("Scene_Menu")),
            };

            
            int[,] mainTilesArray = new int[,]
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            };
                
            List<Tile> mainTiles = Tile.FromMultidimentionalArrayToList(mainTilesArray);
                
                
            this.map = new Map(mainTiles: mainTiles);
            
            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem();

        }

        private void UpdateSystem()
        {
            IEntity player = ChristianGame.GetScene.entities?.FirstOrDefault(x => x.tag == "player");
            camera?.FollowEntity(player);
        }
    }
}