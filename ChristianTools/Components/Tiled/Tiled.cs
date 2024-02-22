using System;
using System.IO;
using Microsoft.Xna.Framework.Content;

namespace ChristianTools.Components
{
    public class Tiled
    {
        public int compressionlevel { get;  set; }
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
            public LayerId id { get; set; }
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

        public enum LayerId
        {
            Background = 1,
            Main = 2,
            Colliders = 3,
            Front = 4,
        }
        
        
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
    }
}