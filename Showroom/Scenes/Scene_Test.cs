using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Vector2 = System.Numerics.Vector2;

namespace Showroom.Scenes
{
    public class Scene_Test : IScene
    {
        public List<IEntity> entities { get; set; }
        
        public List<IUI> UIs { get; set; }
        public Map map { get; set; }
        public Camera camera { get; set; }
        public DxUpdateSystem dxUpdateSystem { get; set; }
        public DxDrawSystem dxDrawSystem { get; set; }
        
        
        public void Initialize()
        {
            // entities
            {
                this.entities = new List<IEntity>()
                {
                    //new Entity_Numbers(new Point(40, 40), WK.AtlasReferences._1),
                    new Entity_Platformer_Player(new Rectangle(40, 40, 16, 16), WK.AtlasReferences._1, "player", force: new Vector2(0, 1)),
                };
            }

            // UI
            {
                this.UIs = new List<IUI>()
                {
                    new Button(
                        rectangle: new Rectangle(10, 460, 230, 30),
                        text: "Go to menu",
                        defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                        mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                        OnClickAction: () => Game1.ChangeToScene("Scene_Menu")
                    ),
                };
            }


            // Map
            {
                int[,] mainIntTiles = new int[,]
                {
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                };

                Tile[,] mainTileTiles = Tile.FromInt_ToTile(mainIntTiles);

                this.map = new Map(mainTiles: mainTileTiles);
            }
            
  
            // Camera
            {
                //this.camera = new Camera();
            }
        }
    }
}