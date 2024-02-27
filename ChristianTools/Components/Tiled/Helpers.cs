using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace ChristianTools.Components.Tiled
{
    public class Helpers
    {
        /// <summary>
        /// Read Map JSON file
        /// </summary>
        /// <param name="tiledMapName">File name of the Map -> without the extension (.json)</param>
        public static T Read_Tiled_JsonSerialization<T>(string tiledMapName)
        {
            ///Remember: First compile project, it will generate a "bin" folder inside default "Content" folder, then, manualy add the files (Just copy and paste)
            /// Will not be necessary to change properties of each file
            /// /Users/christianlehnhoff/Repositories/GitHub/ChristianLe87/MonoGame/MyCoolGame/CrossPlatform/Content/bin/Android/Content/Tree.png
            /// --> Remember to add the file to not ignore on Git


            // For iOS, always set Poroperties to "always copy" and use this
            if (System.OperatingSystem.IsIOS()) tiledMapName = Path.Combine("bin", "iOS", "Content", tiledMapName);

            string absolutePath = Path.Combine("Content" /*contentManager.RootDirectory*/, $"{tiledMapName}.json");

            TextReader textWriter = new StreamReader(absolutePath);
            string fileContents = textWriter.ReadToEnd();
            textWriter.Close();

            T gameData = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(fileContents);

            return gameData;
        }
        
        public static List<Tile> GetTiles(Components.Tiled.Tilemap.LayerId layerId, Tilemap tilemap, Tileset tileset)
        {
            
            List<Tile> result = new List<Tile>();
            {
                List<Tilemap.Layers> tiledLayer = tilemap.layers.Where(x => x.id == layerId && x.visible == true).ToList();
                List<Tilemap.Chunks> tiledChunks = tiledLayer.Select(x => x.chunks).FirstOrDefault().ToList();

                foreach (Tilemap.Chunks chunk in tiledChunks)
                {
                    int[,] map = ChristianTools.Helpers.Other.ToMultidimentional(chunk.data, chunk.width, chunk.height);
                    result = GetTilesFromChunks(map, layerId, new Point(chunk.x, chunk.y), tileset);
                }
            }
            return result;

            
            // === Helpers ===
            List<Tile> GetTilesFromChunks(int[,] map, Tilemap.LayerId layerId, Point mapTopLeftCorner, Tileset tileset)
            {
                // Tileset
                int[,] tilesetMultidimentional = GetTilesetMultidimentional();
                
                // Tilemap
                List<Tile> tiles = GetTilesFromAtrlasBasedOnImageCode(map, tilesetMultidimentional, mapTopLeftCorner);

                return tiles;
            }

            
            int[,] GetTilesetMultidimentional()
            {
                int[,] tilesetMultidimentional;
                {
                    int[] tilesetFlat = new int[tileset.tilecount];
                    for (int i = 0; i < tileset.tilecount; i++)
                    {
                        tilesetFlat[i] = i + 1;
                    }

                    tilesetMultidimentional = ChristianTools.Helpers.Other.ToMultidimentional(tilesetFlat, tileset.columns, tileset.tilecount / tileset.columns);
                }
                return tilesetMultidimentional;
            }


            List<Tile> GetTilesFromAtrlasBasedOnImageCode(int[,] map, int[,] tilesetMultidimentional, Point mapTopLeftCorner)
            {
                List<Tile> tiles = new List<Tile>();
                {
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
                }

                return tiles;
            }

            
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
    }
}