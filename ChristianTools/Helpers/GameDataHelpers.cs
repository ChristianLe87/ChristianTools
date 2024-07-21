
#if ANDROID
using Android.App;
using Android.Content;
#endif

namespace ChristianTools.Helpers;

public static class GameDataHelpers
{
    private static Environment.SpecialFolder specialFolder = Environment.SpecialFolder.InternetCache;


    public static void SetGameData(Dictionary<string, object> data)
    {
#if ANDROID
            {
                // Guardar datos en SharedPreferences
                ISharedPreferences sharedPreferences = Application.Context.GetSharedPreferences(ChristianGame.WK.GameDataFileName, FileCreationMode.Private);
                ISharedPreferencesEditor editor = sharedPreferences.Edit();

                foreach (KeyValuePair<string, object> keyValue in data)
                {
                    string typeString = keyValue.Value.GetType().ToString();

                    switch (typeString)
                    {
                        case "System.String":
                            editor.PutString(keyValue.Key, (string)keyValue.Value);
                            break;
                        case "System.Int32":
                            editor.PutInt(keyValue.Key, (int)keyValue.Value);
                            break;
                        case "System.Boolean":
                            editor.PutBoolean(keyValue.Key, (bool)keyValue.Value);
                            break;
                        case "System.Single":
                            editor.PutFloat(keyValue.Key, (float)keyValue.Value);
                            break;
                        case "System.Double":
                            editor.PutFloat(keyValue.Key, (float)(double)keyValue.Value);
                            break;
                        case "System.DateTime":
                            editor.PutLong(keyValue.Key, ((DateTime)keyValue.Value).Ticks);
                            break;
                        default:
                            // Handle other data types here
                            break;
                    }
                }

                editor.Apply();
            }
#else
        {
            if (GameDataHelpers._Folder.Exist() == true)
            {
                if (GameDataHelpers._File.Exist(ChristianGame.WK.GameDataFileName) == false)
                {
                    GameDataHelpers._File.Create(data, "MyTestData");
                }
            }
            else
            {
                GameDataHelpers._Folder.Create();
                GameDataHelpers._File.Create(data, ChristianGame.WK.GameDataFileName);
            }
        }
#endif
    }


    public static Dictionary<string, object> GetGameData()
    {
#if ANDROID
            {
                ISharedPreferences sharedPreferences = Application.Context.GetSharedPreferences(ChristianGame.WK.GameDataFileName, FileCreationMode.Private);
                return sharedPreferences.All.ToDictionary();
            }
#else
        {
            return GameDataHelpers._File.Read(ChristianGame.WK.GameDataFileName);
        }
#endif
    }


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