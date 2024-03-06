namespace ChristianTools.Components.Tiled
{
    /*public class Helpers
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
            if (System.OperatingSystem.IsIOS()) tiledMapName = Path.Combine("bin", "iOS", "Content", tiledMapName);

            string absolutePath = Path.Combine("Content", $"{tiledMapName}.json");

            TextReader textWriter = new StreamReader(absolutePath);
            string fileContents = textWriter.ReadToEnd();
            textWriter.Close();

            T gameData = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(fileContents);

            return gameData;
        }
    }*/
}