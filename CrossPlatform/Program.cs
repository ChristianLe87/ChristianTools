using Showroom;

namespace CrossPlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            using var game = new Showroom.Game1(new WK(), new GameDataSystem());
            game.Run();
        }
    }
    
    public class GameDataSystem:IGameDataSystem
    {
        public GameData GetFromDevice()
        {
            return new GameData(GameDataHelpers._File.Read(ChristianGame.WK.GameDataFileName));
        }

        public void SaveInDevice(GameData gameData)
        {
            if (GameDataHelpers._Folder.Exist() == true)
            {
                GameDataHelpers._File.Create(gameData.GetAll(), ChristianGame.WK.GameDataFileName);
            }
            else
            {
                GameDataHelpers._Folder.Create();
                GameDataHelpers._File.Create(gameData.GetAll(), ChristianGame.WK.GameDataFileName);
            }
        }
    }
}