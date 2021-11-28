using System;
using System.Collections.Generic;
using ChristianTools.Helpers;

namespace Shared
{
    public class Game1 : ChristianGame
    {
        public Game1() : base(gameDataFileName: WK.Default.gameDataFileName)
        {
            Dictionary<string, IScene> scenes = new Dictionary<string, IScene>()
            {
                { WK.Scene.Menu, new Scene_Menu() },
                { WK.Scene.Components, new Scene_Components() },
                { WK.Scene.Entities, new Scene_Entities() },
                { WK.Scene.Helpers, new Scene_Helpers() },
                { WK.Scene.Tools, new Scene_Tools() },
                { WK.Scene.UI, new Scene_UI() },
            };

            base.SetupScenes(scenes, WK.Scene.Menu);
        }
    }
}