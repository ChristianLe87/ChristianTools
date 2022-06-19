using System.Collections.Generic;
using System.Linq;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Components
{
    public class Map
    {
        public List<ITile> tiles;
        public List<ILight> lights;
        public List<IShadow> shadows;

        public Map()
        {
            this.tiles = new List<ITile>();
            this.lights = new List<ILight>();
            this.shadows = new List<IShadow>();
        }

        public Map(Dictionary<int, Texture2D> textures, Tiled tiled, List<ILight> lights = null)
        {
            this.tiles = GetTiles(textures, tiled);
            this.lights = lights;
            this.shadows = GetShadows(tiled);
        }

        public Map(Dictionary<int, Texture2D> textures, int[,] map, List<ILight> lights = null)
        {
            this.tiles = GetTiles(textures, map, Tiled.LayerId.Front, new Point());
            this.lights = lights;
            this.shadows = GetShadows(map, new Point(0, 0));
        }

        private List<ITile> GetTiles(Dictionary<int, Texture2D> textures, Tiled tiled)
        {
            List<ITile> tiles = new List<ITile>();


            foreach (Tiled.Layers layer in tiled.layers.Where(x => x.visible == true).ToList())
            {
                foreach (Tiled.Chunks chunk in layer.chunks)
                {
                    int[,] map = Tools.Tools.Other.ToMultidimentional(chunk.data, chunk.width, chunk.height);

                    tiles.AddRange(GetTiles(textures, map, layer.id, new Point(chunk.x, chunk.y)));
                }

            }

            return tiles;
        }

        private List<ITile> GetTiles(Dictionary<int, Texture2D> textures, int[,] map, Tiled.LayerId layerId, Point mapTopLeftCorner)
        {
            List<ITile> tiles = new List<ITile>();

            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int element = 0; element < map.GetLength(1); element++)
                {
                    if (textures[map[row, element]] != null)
                    {
                        int AssetSize_x_ScaleFactor = ChristianGame.Default.AssetSize * ChristianGame.Default.ScaleFactor;

                        Tile tile = new Tile(
                            texture: textures[map[row, element]],
                            rectangle: new Rectangle(
                                x: (element * textures[map[row, element]].Width) + (mapTopLeftCorner.X * AssetSize_x_ScaleFactor),
                                y: (row * textures[map[row, element]].Height) + (mapTopLeftCorner.Y * AssetSize_x_ScaleFactor),
                                width: textures[map[row, element]].Width,
                                height: textures[map[row, element]].Height
                            ),
                            layerId: layerId,
                            tag: ""
                        );

                        tiles.Add(tile);
                    }
                }
            }

            return tiles;
        }

        private List<IShadow> GetShadows(int[,] map, Point mapTopLeftCorner)
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
        }

        private List<IShadow> GetShadows(Tiled tiled)
        {
            List<IShadow> shadows = new List<IShadow>();

            foreach (var layer in tiled.layers)
            {
                foreach (var chunk in layer.chunks)
                {
                    int[,] map = Tools.Tools.Other.ToMultidimentional(chunk.data, chunk.width, chunk.height);

                    shadows.AddRange(GetShadows(map, new Point(chunk.x, chunk.y)));
                }
            }

            return shadows;
        }
    }
}