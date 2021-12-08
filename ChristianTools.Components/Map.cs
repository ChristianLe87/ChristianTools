using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Components
{
    public class Map
    {
        public List<Tile> tiles;
        public delegate void DxOnUpdate();

        public Map()
        {
            this.tiles = new List<Tile>();
        }

        public Map(Dictionary<int, Texture2D> textures, int[,] map, int scaleFactor)
        {
            this.tiles = new List<Tile>();

            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int element = 0; element < map.GetLength(1); element++)
                {
                    if (textures[map[row, element]] != null)
                    {
                        Tile tile = new Tile(
                            texture: textures[map[row, element]],
                            rectangle: new Rectangle(x: element * textures[map[row, element]].Width, y: row * textures[map[row, element]].Height, textures[map[row, element]].Width, textures[map[row, element]].Height),
                            scaleFactor: scaleFactor,
                            tag: ""
                        );

                        tiles.Add(tile);
                    }
                }
            }
        }

        public void Update(DxOnUpdate dxOnUpdate)
        {
            dxOnUpdate();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in tiles)
                tile.Draw(spriteBatch);
        }
    }
}