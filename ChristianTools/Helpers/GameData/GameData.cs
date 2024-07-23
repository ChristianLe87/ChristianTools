namespace ChristianTools.Helpers
{
    public class GameData
    {
        private Dictionary<string, object> gameData = new Dictionary<string, object>();

        public GameData(Dictionary<string, object> gameData)
        {
            this.gameData = gameData;
        }
    
        public Dictionary<string, object> GetAll()
        {
            return gameData;
        }
    
        public T GetData<T>(string key)
        {
            return (T)gameData[key];
        }

        public void SetData<T>(string key, T value)
        {
            if (gameData.ContainsKey(key))
                gameData[key] = value;
            else
                gameData.Add(key, value);
        }
    }
}