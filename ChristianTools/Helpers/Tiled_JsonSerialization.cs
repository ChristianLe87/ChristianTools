using System;
using Microsoft.Xna.Framework.Content;

namespace ChristianTools.Helpers
{
    public class Tiled
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

        public class Chunks
        {
            public int[] data { get; set; }
            public int height { get; set; }
            public int width { get; set; }
            public int x { get; set; }
            public int y { get; set; }
        }

        public class Layers
        {
            public Chunks[] chunks { get; set; }
            public int height { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int opacity { get; set; }
            public int startx { get; set; }
            public int starty { get; set; }
            public string type { get; set; }
            public bool visible { get; set; }
            public int width { get; set; }
            public int x { get; set; }
            public int y { get; set; }
        }

        public class Tilesets
        {
            public int firstgid { get; set; }
            public string source { get; set; }
        }
    }


    public class Tiled_JsonSerialization
    {
        /// <summary>
        /// Read Map JSON file
        /// </summary>
        /// <param name="tiledMapName">File name of the Map -> without the extension (.json)</param>
        public static T Read<T>(string tiledMapName)
        {
            ContentManager contentManager = ChristianGame.contentManager;

            string absolutePath = Path.Combine(contentManager.RootDirectory, $"{tiledMapName}.json");

            TextReader textWriter = new StreamReader(absolutePath);
            string fileContents = textWriter.ReadToEnd();
            textWriter.Close();

            T gameData = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(fileContents);

            return gameData;
        }
    }
}