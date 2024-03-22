using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace ChristianTools.Components
{
    public class Tile
    {
        public Rectangle worldRectangle { get; private set; }
        public Rectangle imageFromAtlas { get; private set; }
        public int layerId { get; private set; }
        public string tag { get; private set; }
        public bool isActive { get; set; }

        public Tile(Rectangle worldRectangle, Rectangle imageFromAtlas, int layerId, string tag = "", bool isActive = true)
        {
            this.worldRectangle = worldRectangle;
            this.layerId = layerId;
            this.imageFromAtlas = imageFromAtlas;
            this.tag = tag;
            this.isActive = isActive;
        }

        public static Tile[,] FromInt_ToTile(int[,] intMap)
        {
            Tile[,] result = new Tile[intMap.GetLength(0), intMap.GetLength(1)];

            for (int row = 0; row < intMap.GetLength(0); row++)
            {
                for (int col = 0; col < intMap.GetLength(1); col++)
                {
                    int layerId = intMap[row, col];
                    if (layerId != 0)
                    {
                        Tile tile = new Tile(worldRectangle: new Rectangle(col * 16, row * 16, 16, 16), imageFromAtlas: new Rectangle(0, 0, 16, 16), layerId: layerId);
                        result[row, col] = tile;
                    }
                }
            }

            return result;
        }
    }
}
