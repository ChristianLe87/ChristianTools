using System.Collections.Generic;
using ChristianTools;
using ChristianTools.Helpers;
using Showroom.Scenes;

namespace Showroom
{
    public class Game1 : ChristianGame
    {
        public Game1(WK wk) : base(GetScenes(), startScene: "Scene_Test", wk)
        {
        }

        private static Dictionary<string, IScene> GetScenes()
        {
            Dictionary<string, IScene> scenes = new Dictionary<string, IScene>()
            {
                { "Scene_Test", new Scene_Test() },
                { "Scene_Menu", new Scene_Menu() },
                { "Scene_UI", new Scene_UI() },
                { "Scene_Camera", new Scene_Camera() },
                { "Scene_Entities", new Scene_Entities() },
                { "Scene_Tiles", new Scene_Tiles() },
            };

            return scenes;
        }
    }
}