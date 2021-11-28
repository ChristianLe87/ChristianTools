using System.Collections.Generic;
using ChristianTools.Helpers;

namespace Showroom_dotNet5
{
    public static class Program
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
        public Game1() : base(gameDataFileName: "Monogame_ChristianTools_DataFile")
        {

            Dictionary<string, IScene> scenes = new Dictionary<string, IScene>()
            {
                { WK.Scene.Menu, new Scene_Menu() },
                { WK.Scene.UI, new Scene_UI() },
                { WK.Scene.Physics, new Scene_Physics() },
                { WK.Scene.Shoot, new Scene_Shoot() },
                { WK.Scene.Tools, new Scene_Tools() },
                { WK.Scene.Assets, new Scene_Assets() },
                { WK.Scene.Dialogue, new Scene_Dialogue() },
                { WK.Scene.Camera, new Scene_Camera() },
                { WK.Scene.Playground_1, new Scene_Playground_1() },
                { WK.Scene.Playground_2, new Scene_Playground_2() },
                { WK.Scene.Animations, new Scene_Animations() },
            };

            base.SetupScenes(scenes, WK.Scene.Menu);
        }
    }
}