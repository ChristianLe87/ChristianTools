using System.Collections.Generic;
using ChristianTools.Helpers;
using ChristianTools.Helpers.Enums_Interfaces_Delegates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Showroom_CrossPlatform;
using Showroom_Shared.Helpers;
using Showroom_Shared.Scenes;

namespace Showroom_Shared
{
    public class Game1 : ChristianGame
    {
        //private List<IScene> scenes = GetScenes();
        public Game1() : base("UIs", new WK())
        {
            ChristianGame.scenes = new Dictionary<string, IScene>()
            {
                { "Menu", new Scene_Menu() },
                { "UIs", new Scene_UI() },
                { "SceneEntitiesBullet", new Scene_Entities_Bullet() }
            };
        }
    }
}
