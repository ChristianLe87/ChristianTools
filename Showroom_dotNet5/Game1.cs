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
                { WK.Scene.Scene_Menu, new Scene_Menu() },
                { WK.Scene.Scene_UI, new Scene_UI() },
                { WK.Scene.Scene_Physics, new Scene_Physics() },
                { WK.Scene.Scene_Shoot, new Scene_Shoot() },
                { WK.Scene.Scene_Tools, new Scene_Tools() },
                { WK.Scene.Scene_Assets, new Scene_Assets() },
                { WK.Scene.Scene_Dialogue, new Scene_Dialogue() },
                { WK.Scene.Scene_Camera, new Scene_Camera() },
                { WK.Scene.Scene_Playground_1, new Scene_Playground_1() },
                { WK.Scene.Scene_Playground_2, new Scene_Playground_2() },
                { WK.Scene.Scene_Animations, new Scene_Animations() },
            };

            base.SetupScenes(scenes, WK.Scene.Scene_Menu);
        }
    }
}