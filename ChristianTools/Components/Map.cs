using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace ChristianTools.Components
{
    public class Map
    {
        //public List<Tile> backgroundLayer;
        public List<Tile> mainLayer { get; private set; }
        //public List<Tile> collidersLayer;
        //public List<Tile> frontLayer;

        //public List<Tile> shadowsLayer;
        //public List<Tile> lightsLayer;

        public Map(Tiled tiled)
        {
            this.mainLayer = GetTiles(Tiled.LayerId.Main, tiled);
        }

        private List<Tile> GetTiles(Components.Tiled.LayerId layerId, Tiled tiled)
        {
            List<Tile> result = new List<Tile>();

            List<Tiled.Layers> tiledLayer = tiled.layers.Where(x => x.id == layerId && x.visible == true).ToList();
            List<Tiled.Chunks> tiledChunks = tiledLayer.Select(x => x.chunks).FirstOrDefault().ToList();
            
            foreach (Tiled.Chunks chunk in tiledChunks)
            {
                int[,] map = Helpers.Other.ToMultidimentional(chunk.data, chunk.width, chunk.height);
                
                result = GetTilesFromChunks(map, layerId, new Point(chunk.x, chunk.y));
            }
            
            return result;
        }

        private List<Tile> GetTilesFromChunks(int[,] map, Tiled.LayerId layerId, Point mapTopLeftCorner)
        {
            List<Tile> tiles = new List<Tile>();

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

                    Tile tile = new Tile(
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