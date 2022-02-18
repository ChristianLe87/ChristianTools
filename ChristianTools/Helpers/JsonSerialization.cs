using System;
using System.IO;

namespace ChristianTools.Helpers
{
    public class GameData
    {
        public int score { get; set; } = 0;
        public string systemLanguage { get; set; } = "en";
        public int lifes { get; set; } = 3;
        public int coins { get; set; } = 0;
        public bool hammer_entity_isVisible { get; set; } = true;
        public bool hammer_ui_isVisible { get; set; } = false;
        public bool key1_entity_isVisible { get; set; } = true;
        public bool key1_ui_isVisible { get; set; } = false;
    }

    //Environment.GetFolderPath(Environment.SpecialFolder.InternetCache)
    //"/Users/christianlehnhoff/Library/Caches"
    public class JsonSerialization
    {
        public static string FolderName => "ChristianGames";

        public static bool FolderExist()
        {
            string UserLibraryCaches_Path = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
            return System.IO.Directory.Exists(Path.Combine(UserLibraryCaches_Path, FolderName));
        }

        public static void CreateFolder()
        {
            string UserLibraryCaches_Path = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
            System.IO.Directory.CreateDirectory(Path.Combine(UserLibraryCaches_Path, FolderName));
        }


        /// <summary>
        /// Check if GameData file exist
        /// </summary>
        /// <param name="gameDataFileName">File name of the GameData -> without the extension</param>
        public static bool FileExist(string gameDataFileName)
        {
            string UserLibraryCaches_Path = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
            string absolutePath = Path.Combine(UserLibraryCaches_Path, FolderName, $"{gameDataFileName}.json");

            return File.Exists(absolutePath);
        }

        /// <summary>
        /// Create GameData file
        /// </summary>
        /// <param name="gameDataFileName">File name of the GameData -> without the extension</param>
        public static void Create<T>(T gameData, string gameDataFileName)
        {
            string UserLibraryCaches_Path = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
            string absolutePath = Path.Combine(UserLibraryCaches_Path, FolderName, $"{gameDataFileName}.json");

            TextWriter textWriter = new StreamWriter(path: absolutePath, append: false);

            string contentsToWriteToFile = Newtonsoft.Json.JsonConvert.SerializeObject(gameData);

            textWriter.Write(contentsToWriteToFile);
            textWriter.Close();
        }

        /// <summary>
        /// Update GameData file
        /// </summary>
        /// <param name="gameDataFileName">File name of the GameData -> without the extension</param>
        public static void Update<T>(T gameData, string gameDataFileName)
        {
            Create(gameData, gameDataFileName);
        }

        /// <summary>
        /// Read GameData file
        /// </summary>
        /// <param name="gameDataFileName">File name of the GameData -> without the extension</param>
        public static T Read<T>(string gameDataFileName)
        {
            string UserLibraryCaches_Path = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
            string absolutePath = Path.Combine(UserLibraryCaches_Path, FolderName, $"{gameDataFileName}.json");

            TextReader textWriter = new StreamReader(absolutePath);
            string fileContents = textWriter.ReadToEnd();
            textWriter.Close();

            T gameData = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(fileContents);

            return gameData;
        }

        /// <summary>
        /// Delete GameData file
        /// </summary>
        /// <param name="gameDataFileName">File name of the GameData -> without the extension</param>
        public static void Delete(string gameDataFileName)
        {
            string UserLibraryCaches_Path = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
            string absolutePath = Path.Combine(UserLibraryCaches_Path, FolderName, $"{gameDataFileName}.json");

            File.Delete(absolutePath);
        }
    }
}