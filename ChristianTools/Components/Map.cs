using System.Collections.Generic;

namespace ChristianTools.Components
{
    public class Map
    {
        public List<Tile> backgroundTiles { get; private set; }
        public List<Tile> mainTiles { get; private set; }
        public List<Tile> collidersTiles { get; private set; }
        public List<Tile> frontTiles { get; private set; }
        
        public Map(List<Tile> backgroundTiles = null, List<Tile> mainTiles = null, List<Tile> collidersTiles = null, List<Tile> frontTiles = null)
        {
            this.backgroundTiles = backgroundTiles ?? new List<Tile>();
            this.mainTiles = mainTiles ?? new List<Tile>();
            this.collidersTiles = collidersTiles ?? new List<Tile>();
            this.frontTiles = frontTiles ?? new List<Tile>();
        }
    }
}