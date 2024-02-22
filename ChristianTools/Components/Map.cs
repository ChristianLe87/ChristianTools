using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace ChristianTools.Components
{
    //public interface ITile{}

    public class MyTile
    {
        public Rectangle worldRectangle { get; private set; }
        public int image { get; private set; }
        public Tiled.LayerId layerId { get; private set; }

        public MyTile(Rectangle worldRectangle, int image, Tiled.LayerId layerId)
        {
            this.worldRectangle = worldRectangle;
            this.image = image;
            this.layerId = layerId;
        }
    }

    public class Map
    {
        //public List<MyTile> backgroundLayer;
        public List<MyTile> mainLayer { get; private set; }
        //public List<MyTile> collidersLayer;
        //public List<MyTile> frontLayer;

        //public List<MyTile> shadowsLayer;
        //public List<MyTile> lightsLayer;

        public Map(Tiled tiled)
        {
            this.mainLayer = GetTiles(Tiled.LayerId.Main, tiled);
        }

        private List<MyTile> GetTiles(Components.Tiled.LayerId layerId, Tiled tiled)
        {
            List<MyTile> result = new List<MyTile>();

            List<Tiled.Layers> tiledLayer = tiled.layers.Where(x => x.id == layerId && x.visible == true).ToList();
            List<Tiled.Chunks> tiledChunks = tiledLayer.Select(x => x.chunks).FirstOrDefault().ToList();
            
            foreach (Tiled.Chunks chunk in tiledChunks)
            {
                int[,] map = Helpers.Other.ToMultidimentional(chunk.data, chunk.width, chunk.height);
                
                result = GetTilesFromChunks(map, layerId, new Point(chunk.x, chunk.y));
            }
            
            return result;
        }

        private List<MyTile> GetTilesFromChunks(int[,] map, Tiled.LayerId layerId, Point mapTopLeftCorner)
        {
            List<MyTile> tiles = new List<MyTile>();

            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int element = 0; element < map.GetLength(1); element++)
                {
                    int AssetSize_x_ScaleFactor = ChristianGame.WK.TileSize * ChristianGame.WK.ScaleFactor;
                    Rectangle rectangle = new Rectangle(
                        x: (element * ChristianGame.WK.TileSize) + (mapTopLeftCorner.X * AssetSize_x_ScaleFactor),
                        y: (row * ChristianGame.WK.TileSize) + (mapTopLeftCorner.Y * AssetSize_x_ScaleFactor),
                        width: ChristianGame.WK.TileSize,
                        height: ChristianGame.WK.TileSize
                    );

                    MyTile tile = new MyTile(
                        worldRectangle: rectangle,
                        image: map[row, element],
                        layerId: layerId
                    );

                    tiles.Add(tile);
                }
            }

            return tiles;
        }

        /*private List<IShadow> GetShadows(int[,] map, Point mapTopLeftCorner)
        {
            List<IShadow> shadows = new List<IShadow>();

            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int element = 0; element < map.GetLength(1); element++)
                {
                    int AssetSize_x_ScaleFactor = ChristianGame.Default.AssetSize * ChristianGame.Default.ScaleFactor;

                    Shadow shadow = new Shadow(
                        rectangle: new Rectangle(
                            x: (element * AssetSize_x_ScaleFactor) + (mapTopLeftCorner.X * AssetSize_x_ScaleFactor),
                            y: (row * AssetSize_x_ScaleFactor) + (mapTopLeftCorner.Y * AssetSize_x_ScaleFactor),
                            width: AssetSize_x_ScaleFactor,
                            height: AssetSize_x_ScaleFactor
                        ),
                        tag: ""
                    );

                    shadows.Add(shadow);
                }
            }

            return shadows;
        }*/

        /*private List<IShadow> GetShadows(Tiled tiled)
        {
            List<IShadow> shadows = new List<IShadow>();

            foreach (var layer in tiled.layers)
            {
                foreach (var chunk in layer.chunks)
                {
                    int[,] map = Helpers.Other.ToMultidimentional(chunk.data, chunk.width, chunk.height);

                    shadows.AddRange(GetShadows(map, new Point(chunk.x, chunk.y)));
                }
            }

            return shadows;
        }*/
    }
}