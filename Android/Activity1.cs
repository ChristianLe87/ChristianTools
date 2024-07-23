using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Showroom;

namespace Android
{
    [Activity(
        Label = "@string/app_name",
        MainLauncher = true,
        Icon = "@drawable/icon",
        AlwaysRetainTaskState = true,
        LaunchMode = LaunchMode.SingleInstance,
        ScreenOrientation = ScreenOrientation.Portrait, //.FullUser,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize
    )]
    public class Activity1 : AndroidGameActivity
    {
        private Game1 _game;
        private View _view;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _game = new Game1(new WK(), new GameDataSystem());
            _view = _game.Services.GetService(typeof(View)) as View;

            SetContentView(_view);
            _game.Run();
        }
    }

    public class GameDataSystem : IGameDataSystem
    {
        public GameData GetFromDevice()
        {
            ISharedPreferences sharedPreferences = Application.Context.GetSharedPreferences(ChristianGame.WK.GameDataFileName, FileCreationMode.Private);
            GameData gameData = new GameData(sharedPreferences.All.ToDictionary());
            return gameData;
        }

        public void SaveInDevice(GameData gameData)
        {
            // Guardar datos en SharedPreferences
            ISharedPreferences sharedPreferences = Application.Context.GetSharedPreferences(ChristianGame.WK.GameDataFileName, FileCreationMode.Private);
            ISharedPreferencesEditor editor = sharedPreferences.Edit();

            foreach (KeyValuePair<string, object> keyValue in gameData.GetAll())
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
                        throw new Exception($"Type: '{typeString}' not supported by ChristianTools");
                        break;
                }
            }
            
            editor.Apply();
        }
    }
}