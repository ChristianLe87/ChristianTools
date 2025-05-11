namespace ChristianTools.Helpers.Tiled
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
            if (System.OperatingSystem.IsIOS())
                tiledMapName = Path.Combine("bin", "iOS", "Content", tiledMapName);

            string absolutePath = Path.Combine("Content", $"{tiledMapName}.json");
            T gameData;

            using (TextReader textWriter = new StreamReader(absolutePath))
            {
                string fileContents = textWriter.ReadToEnd();
                gameData = JsonSerializer.Deserialize<T>(fileContents);
            }

            return gameData;
        }

        /// <summary>
        /// From all scenes
        /// </summary>
        /// <returns>Key: ScenePath, Val: Object</returns>
        public static List<KeyValuePair<string, TiledMap.TiledObject>> GetAll_FromTo_Objects()
        {
            List<KeyValuePair<string, TiledMap.TiledObject>> mapsDictionary = new List<KeyValuePair<string, TiledMap.TiledObject>>();

            // For each map
            foreach (string eachMap in ChristianGame.WK.Maps.Values)
            {
                TiledMap tiledMap = ChristianTools.Helpers.Tiled.Helpers.Read_Tiled_JsonSerialization<TiledMap>(eachMap);
                Map map = new ChristianTools.Components.Map(tiledMap);

                var mapObject = map.triggerTiles?.Where(x => x.name.Contains("From ") || x.name.Contains("To ")).ToList();

                if (mapObject != null)
                {
                    foreach (var obj in mapObject)
                    {
                        mapsDictionary.Add(new KeyValuePair<string, TiledMap.TiledObject>(eachMap, obj));
                    }
                }
            }

            return mapsDictionary;
        }
    }
}
