using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using ChristianTools.Components.Tiled;

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

        public Map(string tilemapFile, string tilesetFile)
        {
            Tilemap tilemap = ChristianTools.Components.Tiled.Helpers.Read_Tiled_JsonSerialization<Tilemap>(tilemapFile);
            Tileset tileset = ChristianTools.Components.Tiled.Helpers.Read_Tiled_JsonSerialization<Tileset>(tilesetFile);
            
            this.mainLayer = GetTiles(Tilemap.LayerId.Main, tilemap, tileset);
        }

        private List<Tile> GetTiles(Components.Tiled.Tilemap.LayerId layerId, Tilemap tilemap, Tileset tileset)
        {
            List<Tile> result = new List<Tile>();

            List<Tilemap.Layers> tiledLayer = tilemap.layers.Where(x => x.id == layerId && x.visible == true).ToList();
            List<Tilemap.Chunks> tiledChunks = tiledLayer.Select(x => x.chunks).FirstOrDefault().ToList();
            
            foreach (Tilemap.Chunks chunk in tiledChunks)
            {
                int[,] map = Helpers.Other.ToMultidimentional(chunk.data, chunk.width, chunk.height);
                result = GetTilesFromChunks(map, layerId, new Point(chunk.x, chunk.y), tileset);
            }
            
            return result;
        }

        private List<Tile> GetTilesFromChunks(int[,] map, Tilemap.LayerId layerId, Point mapTopLeftCorner, Tileset tileset)
        {
            // Tileset
            int[,] tilesetMultidimentional;
            {
                int[] tilesetFlat = new int[tileset.tilecount];
                for (int i = 0; i < tileset.tilecount; i++)
                {
                    tilesetFlat[i] = i + 1;
                }

                tilesetMultidimentional = ChristianTools.Helpers.Other.ToMultidimentional(tilesetFlat, tileset.columns, tileset.tilecount / tileset.columns);
            }



            // Tilemap
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
                        imageFromAtlas: GetImageFromAtrlasBasedOnImageCode(tilesetMultidimentional, map[row, element]),
                        layerId: layerId
                    );

                    tiles.Add(tile);
                }
            }

            return tiles;

            // Helpers
            Rectangle GetImageFromAtrlasBasedOnImageCode(int[,] tilesetMultidimentional, int imageCode)
            {
                int filas = tilesetMultidimentional.GetLength(0);
                int columnas = tilesetMultidimentional.GetLength(1);

                for (int i = 0; i < filas; i++)
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        if (tilesetMultidimentional[i, j] == imageCode)
                        {
                            return new Rectangle(i * tileset.tilewidth, j * tileset.tileheight, tileset.tilewidth, tileset.tileheight);
                        }
                    }
                }
                
                return new Rectangle();
            }
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