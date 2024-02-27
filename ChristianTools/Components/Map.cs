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
        public List<Tile> collidersLayer { get; private set; }
        //public List<Tile> frontLayer;

        //public List<Tile> shadowsLayer;
        //public List<Tile> lightsLayer;

        public Map(string tilemapFile, string tilesetFile)
        {
            Tilemap tilemap = ChristianTools.Components.Tiled.Helpers.Read_Tiled_JsonSerialization<Tilemap>(tilemapFile);
            Tileset tileset = ChristianTools.Components.Tiled.Helpers.Read_Tiled_JsonSerialization<Tileset>(tilesetFile);

            this.mainLayer = ChristianTools.Components.Tiled.Helpers.GetTiles(Tilemap.LayerId.Main, tilemap, tileset);
            this.collidersLayer = ChristianTools.Components.Tiled.Helpers.GetTiles(Tilemap.LayerId.Colliders, tilemap, tileset);
        }
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