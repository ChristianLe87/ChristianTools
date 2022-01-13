using System.Collections.Generic;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace ChristianTools.Components
{
    public class Map
    {
        public List<ITile> tiles;

        public Map()
        {
            this.tiles = new List<ITile>();
        }

        public Map(Dictionary<int, Texture2D> textures, int[,] map)
        {
            this.tiles = new List<ITile>();

            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int element = 0; element < map.GetLength(1); element++)
                {
                    if (textures[map[row, element]] != null)
                    {
                        Tile tile = new Tile(
                            texture: textures[map[row, element]],
                            rectangle: new Rectangle(x: element * textures[map[row, element]].Width, y: row * textures[map[row, element]].Height, textures[map[row, element]].Width, textures[map[row, element]].Height),
                            tag: ""
                        );

                        tiles.Add(tile);
                    }
                }
            }
        }
    }
}