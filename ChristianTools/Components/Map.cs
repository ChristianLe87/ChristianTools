namespace ChristianTools.Components
{
    public class Map
    {
        public Tile[,] backgroundTiles { get; private set; }
        public Tile[,] mainTiles { get; private set; }
        public Tile[,] collidersTiles { get; private set; }
        public Tile[,] frontTiles { get; private set; }

        public TiledMap.TiledObject[] otherEntities { get; private set; }
        public TiledMap.TiledObject[] triggerTiles { get; private set; }
        public string tag { get; }

        public Map(Tile[,] backgroundTiles = null, Tile[,] mainTiles = null, Tile[,] collidersTiles = null, Tile[,] frontTiles = null, TiledMap.TiledObject[] otherEntitieTiles = null, TiledMap.TiledObject[] triggerTiles = null, string tag = "")
        {
            this.backgroundTiles = backgroundTiles ?? new Tile[,] { };
            this.mainTiles = mainTiles ?? new Tile[,] { };
            this.collidersTiles = collidersTiles ?? new Tile[,] { };
            this.frontTiles = frontTiles ?? new Tile[,] { };

            this.otherEntities = otherEntitieTiles ?? new TiledMap.TiledObject[] { };
            this.triggerTiles = triggerTiles ?? new TiledMap.TiledObject[] { };
            this.tag = tag;
        }

        public Map(TiledMap tiledMap)
        {
            // 1_Background_Layer
            int[,] backgroundTilesData = tiledMap.layers.Where(x => x.id == LayerDepth.Background).Select(x => ChristianTools.Helpers.Other.ToMultidimentional(x.data, x.width, x.height)).First();
            this.backgroundTiles = Tile.FromInt_ToTile(backgroundTilesData, LayerDepth.Background);

            // 2_Main_Layer
            int[,] mainData = tiledMap.layers.Where(x => x.id == LayerDepth.Main).Select(x => ChristianTools.Helpers.Other.ToMultidimentional(x.data, x.width, x.height)).First();
            this.mainTiles = Tile.FromInt_ToTile(mainData, LayerDepth.Main);

            // 3_Colliders_Layer (Other colliders added programaticly like NPCs or other temporal barriers)
            int[,] collidersTilesData = tiledMap.layers.Where(x => x.id == LayerDepth.Colliders).Select(x => ChristianTools.Helpers.Other.ToMultidimentional(x.data, x.width, x.height)).First();
            this.collidersTiles = Tile.FromInt_ToTile(collidersTilesData, LayerDepth.Colliders);

            // 4_Front_Layer
            int[,] frontTilesData = tiledMap.layers.Where(x => x.id == LayerDepth.Front).Select(x => ChristianTools.Helpers.Other.ToMultidimentional(x.data, x.width, x.height)).First();
            this.frontTiles = Tile.FromInt_ToTile(frontTilesData, LayerDepth.Front);

            // 5_OtherEntities_Layer
            this.otherEntities = tiledMap.layers.Where(x => x.id == LayerDepth.OtherEntities).Select(x => x.tiledObjects).FirstOrDefault();

            // 6_Triggers_Layer
            this.triggerTiles = tiledMap.layers.Where(x => x.id == LayerDepth.Triggers).Select(x => x.tiledObjects).FirstOrDefault();
        }
    }
}