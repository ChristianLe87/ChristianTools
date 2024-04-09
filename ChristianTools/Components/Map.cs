namespace ChristianTools.Components
{
    public class Map
    {
        public Tile[,] backgroundTiles { get; private set; }
        public Tile[,] mainTiles { get; private set; }
        public Tile[,] collidersTiles { get; private set; }
        public Tile[,] frontTiles { get; private set; }
        public string tag { get; }

        public Map(Tile[,] backgroundTiles = null, Tile[,] mainTiles = null, Tile[,] collidersTiles = null, Tile[,] frontTiles = null, string tag = "")
        {
            this.backgroundTiles = backgroundTiles ?? new Tile[,] { };
            this.mainTiles = mainTiles ?? new Tile[,] { };
            this.collidersTiles = collidersTiles ?? new Tile[,] { };
            this.frontTiles = frontTiles ?? new Tile[,] { };
            this.tag = tag;
        }

        public Map(TiledMap tiledMap)
        {
            int[,] backgroundTilesData = tiledMap.layers.Where(x => x.id == LayerDepth.Background).Select(x => ChristianTools.Helpers.Other.ToMultidimentional(x.data, x.width, x.height)).First();
            this.backgroundTiles = Tile.FromInt_ToTile(backgroundTilesData, LayerDepth.Background);

            int[,] mainData = tiledMap.layers.Where(x => x.id == LayerDepth.Main).Select(x => ChristianTools.Helpers.Other.ToMultidimentional(x.data, x.width, x.height)).First();
            this.mainTiles = Tile.FromInt_ToTile(mainData, LayerDepth.Main);

            int[,] collidersTilesData = tiledMap.layers.Where(x => x.id == LayerDepth.Colliders).Select(x => ChristianTools.Helpers.Other.ToMultidimentional(x.data, x.width, x.height)).First();
            this.collidersTiles = Tile.FromInt_ToTile(collidersTilesData, LayerDepth.Colliders);

            int[,] frontTilesData = tiledMap.layers.Where(x => x.id == LayerDepth.Front).Select(x => ChristianTools.Helpers.Other.ToMultidimentional(x.data, x.width, x.height)).First();
            this.frontTiles = Tile.FromInt_ToTile(frontTilesData, LayerDepth.Front);
        }
    }
}