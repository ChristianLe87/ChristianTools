using System;
using System.Collections.Generic;
using ChristianTools;
using ChristianTools.Components;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Showroom;

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
                    new Entity_WASD(MyRectangle.CreateRectangle(new Point(40, 40), 16, 16), WK.AtlasReferences._1, "player"),
                    new Entity_Numbers(new Rectangle(16, 16, 16, 16), WK.AtlasReferences._2),

                    
                    // TL
                    new Entity_Numbers(MyRectangle.CreateRectangle(centerPosition: new Point(8, 8),16,16),animationRectangle: WK.AtlasReferences._1, tag: "TL"),
                    // TR
                    new Entity_Numbers(MyRectangle.CreateRectangle(centerPosition: new Point(ChristianGame.WK.canvasWidth - 8, 8),16,16), animationRectangle: WK.AtlasReferences._3),
                    // DL
                    new Entity_Numbers(MyRectangle.CreateRectangle(centerPosition: new Point(8, ChristianGame.WK.canvasHeight - 8),16,16), animationRectangle: WK.AtlasReferences._7),
                    // DR
                    new Entity_Numbers(MyRectangle.CreateRectangle(centerPosition: new Point(ChristianGame.WK.canvasWidth - 8, ChristianGame.WK.canvasHeight - 8),16,16), animationRectangle: WK.AtlasReferences._9),
                    // center
                    new Entity_Numbers(MyRectangle.CreateRectangle(centerPosition: new Point(ChristianGame.WK.canvasWidth / 2, ChristianGame.WK.canvasHeight / 2),16,16), animationRectangle: WK.AtlasReferences._5)

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
                int[,] mainTilesArray = new int[,]
                {
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    //{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    //{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    //{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    //{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    //{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    //{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                };
                
                var mainTiles = ChristianTools.Components.Tile.FromMultidimentionalArrayToList(mainTilesArray);

                var MyBlaTile = new Tile(new Rectangle(0, 0, 16, 16), WK.AtlasReferences._9, 1);
                mainTiles.Add(MyBlaTile);
                
                
                this.map = new Map(mainTiles: mainTiles);
            }
            
  
            // Camera
            {
                //this.camera = new Camera();
            }
            
        }
    }
}