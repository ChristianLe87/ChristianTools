using System.Collections.Generic;

namespace ChristianTools.Components
{
    public class Map
    {
        public Tile[,] backgroundTiles { get; private set; }
        public Tile[,] mainTiles { get; private set; }
        public Tile[,] collidersTiles { get; private set; }
        public Tile[,] frontTiles { get; private set; }

        public Map(Tile[,] backgroundTiles = null, Tile[,] mainTiles = null, Tile[,] collidersTiles = null, Tile[,] frontTiles = null)
        {
            this.backgroundTiles = backgroundTiles ?? new Tile[,] { };
            this.mainTiles = mainTiles ?? new Tile[,] { };
            this.collidersTiles = collidersTiles ?? new Tile[,] { };
            this.frontTiles = frontTiles ?? new Tile[,] { };
        }
    }
}