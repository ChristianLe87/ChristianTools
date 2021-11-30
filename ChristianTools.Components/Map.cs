using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Components
{
    public class Map
    {
        public List<Tile> tiles;
        public delegate void DxOnUpdate();

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
    public class Bla
    {
        public void blaMap(int[,] level)
        {
         



            /*
            Tile[,] tiles = new Tile[level.GetLength(0), level.GetLength(1)];

            for (int row = 0; row < level.GetLength(0); row++)
            {
                for (int element = 0; element < level.GetLength(1); element++)
                {
                    switch (level[row, element])
                    {
                        case 05:
                            tiles[row, element] = new Tile(WK.Texture.Tiles._05_Multiply, new Rectangle(x: element * WK.Texture.Tiles._05_Multiply.Width, y: row * WK.Texture.Tiles._05_Multiply.Height, WK.Texture.Tiles._05_Multiply.Width, WK.Texture.Tiles._05_Multiply.Height), tag: "05");
                            break;
                        default:
                            //Texture2D texture = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Transparent, WK.Texture.Tiles._05_Multiply.Width, WK.Texture.Tiles._05_Multiply.Height);
                            //tiles[row, element] = new Tile(texture, new Rectangle(x: element * texture.Width, y: row * texture.Height, texture.Width, texture.Height), tag: "00");
                            break;
                    }
                }
            }*/
        }
    }
}