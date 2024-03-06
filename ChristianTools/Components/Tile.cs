using System;
using System.Collections.Generic;
using ChristianTools.Components.Tiled;
using Microsoft.Xna.Framework;

namespace ChristianTools.Components
{
    public class Tile
    {
        public Rectangle worldRectangle { get; private set; }
        public Rectangle imageFromAtlas { get; private set; }
        public int layerId { get; private set; } 
        public string tag { get; private set; }

        public Tile(Rectangle worldRectangle, Rectangle imageFromAtlas, int layerId, string tag ="")
        {
            this.worldRectangle = worldRectangle;
            this.layerId = layerId;
            this.imageFromAtlas = imageFromAtlas;
            this.tag = tag;
        }

        public static List<Tile> FromMultidimentionalArrayToList(int[,] multidimentionalMap)
        {
            List<Tile> result = new List<Tile>();
            
            for (int row = 0; row < multidimentionalMap.GetLength(0); row++)
            {
                for (int col = 0; col < multidimentionalMap.GetLength(1); col++)
                {
                    int layerId = multidimentionalMap[row, col];
                    if (layerId != 0)
                    {
                        Tile tile = new Tile(worldRectangle: new Rectangle(col * 16, row * 16, 16, 16), imageFromAtlas: new Rectangle(0, 0, 16, 16), layerId: layerId);
                        result.Add(tile);
                    }
                }
            }
            
            return result;
        }
    }
}