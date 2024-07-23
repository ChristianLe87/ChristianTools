using System;
using Foundation;
using UIKit;
using Showroom;

namespace iOS
{
    [Register("AppDelegate")]
    class Program : UIApplicationDelegate
    {
        private static Game1 game;

        internal static void RunGame()
        {
            game = new Game1(new WK(), new GameDataSystem());
            game.Run();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            UIApplication.Main(args, null, typeof(Program));
        }

        public override void FinishedLaunching(UIApplication app)
        {
            RunGame();
        }
    }


    public class GameDataSystem : IGameDataSystem
    {
        public GameData GetFromDevice()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            NSUserDefaults userDefaults = NSUserDefaults.StandardUserDefaults;

            foreach (var key in userDefaults.ToDictionary())
            {
                result.Add(key.Key.ToString(), key.Value);
            }

            return new GameData(result);
        }

        public void SaveInDevice(GameData gameData)
        {
            NSUserDefaults userDefaults = Foundation.NSUserDefaults.StandardUserDefaults;
            
            foreach (KeyValuePair<string, object> keyValue in gameData.GetAll())
            {
                string typeString = keyValue.Value.GetType().ToString();

                switch (typeString)
                {
                    case "System.String":
                        userDefaults.SetString((string)keyValue.Value, keyValue.Key);
                        break;
                    case "System.Int64":
                        userDefaults.SetDouble((long)keyValue.Value, keyValue.Key);
                        break;
                    case "System.Int32":
                        userDefaults.SetInt((int)keyValue.Value, keyValue.Key);
                        break;
                    case "System.Int16":
                        userDefaults.SetInt((short)keyValue.Value, keyValue.Key);
                        break;
                    case "System.Boolean":
                        userDefaults.SetBool((bool)keyValue.Value, keyValue.Key);
                        break;
                    case "System.Single":
                        userDefaults.SetFloat((float)keyValue.Value, keyValue.Key);
                        break;
                    case "System.Double":
                        userDefaults.SetDouble((double)keyValue.Value, keyValue.Key);
                        break;
                    default:
                        userDefaults.SetString(keyValue.Value.ToString(), keyValue.Key);
                        break;
                }
            }
            
            userDefaults.Synchronize();
        }
    }
}