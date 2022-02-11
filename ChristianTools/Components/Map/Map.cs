using System.Collections.Generic;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace ChristianTools.Components
{
    public class Map
    {
        public List<ITile> tiles;
        public List<Light> lights;
        public List<IShadow> shadows;

        public Map()
        {
            this.tiles = new List<ITile>();
            this.lights = new List<Light>();
            this.shadows = new List<IShadow>();
        }

        public Map(Dictionary<int, Texture2D> textures, int[,] map, List<Light> lights = null)
        {
            this.tiles = PopulateTiles(textures, map);
            this.lights = lights;
            this.shadows = PopulateShadows(map);
        }



        private List<ITile> PopulateTiles(Dictionary<int, Texture2D> textures, int[,] map)
        {
            List<ITile> tiles = new List<ITile>();

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

            return tiles;
        }


        private List<IShadow> PopulateShadows(int[,] map)
        {
            List<IShadow> shadows = new List<IShadow>();

            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int element = 0; element < map.GetLength(1); element++)
                {
                    int AssetSize_x_ScaleFactor = ChristianGame.Default.AssetSize * ChristianGame.Default.ScaleFactor;


                    Shadow shadow = new Shadow(
                        rectangle: new Rectangle(x: element * AssetSize_x_ScaleFactor, y: row * AssetSize_x_ScaleFactor, AssetSize_x_ScaleFactor, AssetSize_x_ScaleFactor),
                        tag: ""
                    );

                    shadows.Add(shadow);
                }
            }

            return shadows;
        }
    }
}