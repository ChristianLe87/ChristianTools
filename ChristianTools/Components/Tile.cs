using ChristianTools.Helpers;
using Microsoft.Xna.Framework;

namespace ChristianTools.Components
{
    public class Tile
    {
        public Rectangle rectangle { get; private set; }
        public Rectangle imageFromAtlas { get; private set; }
        public ChristianTools.Helpers.LayerDepth layerDepth { get; private set; }
        public string tag { get; private set; }
        public bool isActive { get; set; }

        public Tile(Rectangle worldRectangle, Rectangle imageFromAtlas, Helpers.LayerDepth layerDepth, string tag = "", bool isActive = true)
        {
            this.rectangle = worldRectangle;
            this.layerDepth = layerDepth;
            this.imageFromAtlas = imageFromAtlas;
            this.tag = tag;
            this.isActive = isActive;
        }

        public static Tile[,] FromInt_ToTile(int[,] intMap, LayerDepth layerDepth)
        {
            Tile[,] result = new Tile[intMap.GetLength(0), intMap.GetLength(1)];

            for (int row = 0; row < intMap.GetLength(0); row++)
            {
                for (int col = 0; col < intMap.GetLength(1); col++)
                {
                    int tileValue = intMap[row, col];
                    if (tileValue != 0)
                    {
                        Tile tile = new Tile(
                            worldRectangle: new Rectangle(col * 16, row * 16, 16, 16),
                            imageFromAtlas: GetRectangleBaseOnTileValue(tileValue), // new Rectangle(0, 0, 16, 16),
                            layerDepth: layerDepth
                        );

                        result[row, col] = tile;
                    }
                }
            }

            return result;
        }


        public static Rectangle GetRectangleBaseOnTileValue(int tileValue)
        {
            Rectangle atlasTilesetRectangle = ChristianGame.atlasTileset.Bounds;

            int width = atlasTilesetRectangle.Width / ChristianGame.WK.TileSize;
            int height = atlasTilesetRectangle.Height / ChristianGame.WK.TileSize;


            // populate array from 1 to ... 100?
            int[,] atlasTilesetMap = new int[width, height];
            int count = 1;
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    atlasTilesetMap[row, col] = count;
                    count++;
                }
            }


            // Get coordinate of number on array
            for (int i = 0; i < atlasTilesetMap.GetLength(0); i++)
            {
                for (int j = 0; j < atlasTilesetMap.GetLength(1); j++)
                {
                    if (atlasTilesetMap[i, j] == tileValue)
                    {
                        return new Rectangle(j * 16, i * 16, 16, 16);
                    }
                }
            }

            // default return
            return Rectangle.Empty;
        }
    }
}
