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

                // Components
                { WK.Scene.Components, new Scene_Components() },
                { WK.Scene.Components_Animation, new Scene_Components_Animation() },
                { WK.Scene.Components_Camera, new Scene_Components_Camera() },
                { WK.Scene.Components_Map, new Scene_Components_Map() },
                { WK.Scene.Components_Rigidbody, new Scene_Components_Rigidbody() },

                // Entities
                { WK.Scene.Entities, new Scene_Entities() },
                { WK.Scene.Entities_Bullet, new Scene_Entities_Bullet() },
                { WK.Scene.Entities_Prefab, new Scene_Entities_Prefab() },
                { WK.Scene.Entities_Line, new Scene_Entities_Line() },

                // Helpers
                { WK.Scene.Helpers, new Scene_Helpers() },
                { WK.Scene.Helpers_InputState, new Scene_Helpers_InputState() },
                { WK.Scene.Helpers_JsonSerialization, new Scene_Helpers_JsonSerialization() },

                // Tools
                { WK.Scene.Tools, new Scene_Tools() },

                // UI
                { WK.Scene.UI, new Scene_UI() },
            };

            base.SetupScenes(scenes, WK.Scene.Menu);
        }
    }
}