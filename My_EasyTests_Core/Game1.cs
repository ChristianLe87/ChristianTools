using ChristianTools.Helpers;

namespace My_EasyTests_Core
{
    class Program
    {
        static void Main()
        {
            using (var game = new Game1())
            {
                game.Run();
            }
        }
    }

    public class Game1 : ChristianGame
    {
        public Game1() : base(new WK.Default())
        {
            Dictionary<string, IScene> scenes = new Dictionary<string, IScene>()
            {
                { WK.Scene.Game, new SceneGame() }
            };

            base.SetupScenes(scenes, WK.Scene.Game);
        }
    }
}