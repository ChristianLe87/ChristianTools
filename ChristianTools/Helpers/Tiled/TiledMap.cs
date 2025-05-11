using System.Text.Json.Serialization;

namespace ChristianTools.Helpers.Tiled
{
    public class TiledMap
    {
        public int compressionlevel { get; set; }
        public int height { get; set; }
        public bool infinite { get; set; }
        public Layers[] layers { get; set; }
        public int nextlayerid { get; set; }
        public int nextobjectid { get; set; }
        public string orientation { get; set; }
        public string renderorder { get; set; }
        public string tiledversion { get; set; }
        public int tileheight { get; set; }
        public Tilesets[] tilesets { get; set; }
        public int tilewidth { get; set; }
        public string type { get; set; }
        public string version { get; set; }
        public int width { get; set; }

        public class Layers
        {
            public int[] data { get; set; }
            public int height { get; set; }
            public int width { get; set; }
            public LayerDepth id { get; set; }
            public string name { get; set; }
            public int opacity { get; set; }
            public string type { get; set; }
            public bool visible { get; set; }
            public int x { get; set; }
            public int y { get; set; }

            [JsonPropertyName("objects")]
            public TiledObject[] tiledObjects { get; set; }
        }

        public class TiledObject
        {
            public int gid { get; set; }
            public float height { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public float rotation { get; set; }
            public string type { get; set; }
            public bool visible { get; set; }
            public float width { get; set; }
            public float x { get; set; }
            public float y { get; set; }

            public Rectangle rectangle => new Rectangle((int)x, (int)(y - height), (int)width, (int)height);
        }

        public class Tilesets
        {
            public int firstgid { get; set; }
            public string source { get; set; }
        }
    }
}