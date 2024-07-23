
namespace ChristianTools.Helpers
{
    public static class GameDataHelpers
    {
        private static Environment.SpecialFolder specialFolder = Environment.SpecialFolder.InternetCache;
        
        public static class _Folder
        {
            public static bool Exist(string FolderName = "ChristianGames")
            {
                string specialFolderPath = Environment.GetFolderPath(specialFolder);
                return System.IO.Directory.Exists(Path.Combine(specialFolderPath, FolderName));
            }

            public static void Create(string FolderName = "ChristianGames")
            {
                string specialFolderPath = Environment.GetFolderPath(specialFolder);
                System.IO.Directory.CreateDirectory(Path.Combine(specialFolderPath, FolderName));
            }
        }

        public static class _File
        {
            public static bool Exist(string gameDataFileName, string FolderName = "ChristianGames")
            {
                string specialFolderPath = Environment.GetFolderPath(specialFolder);
                string absolutePath = Path.Combine(specialFolderPath, FolderName, $"{gameDataFileName}.json");

                return File.Exists(absolutePath);
            }


            /// <summary>
            /// Create GameData file
            /// </summary>
            /// <param name="gameDataFileName">File name of the GameData -> without the extension</param>
            public static void Create(Dictionary<string, object> gameData, string gameDataFileName, string FolderName = "ChristianGames")
            {
                string specialFolderPath = Environment.GetFolderPath(specialFolder);
                string absolutePath = Path.Combine(specialFolderPath, FolderName, $"{gameDataFileName}.json");
                string gameDataJson = JsonSerializer.Serialize(gameData);
                File.WriteAllText(absolutePath, gameDataJson);
            }

            public static Dictionary<string, object> Read(string gameDataFileName, string FolderName = "ChristianGames")
            {
                Dictionary<string, object> gameData = new Dictionary<string, object>();

                string specialFolderPath = Environment.GetFolderPath(specialFolder);
                string absolutePath = Path.Combine(specialFolderPath, FolderName, $"{gameDataFileName}.json");


                using (TextReader textWriter = new StreamReader(absolutePath))
                {
                    string fileContents = textWriter.ReadToEnd();
                    gameData = JsonSerializer.Deserialize<Dictionary<string, object>>(fileContents);
                }

                return gameData;
            }
        }
    }
}