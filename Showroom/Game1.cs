using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ChristianTools;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Showroom.Scenes;

namespace Showroom
{
    public class Game1 : ChristianGame
    {
        public Game1() : base(GetScenes(), startScene: "Menu", new WK())
        {
        }
        
        private static Dictionary<string, IScene> GetScenes(){
            Dictionary<string, IScene> scenes = new Dictionary<string, IScene>()
            {
                { "Menu", new Scene_Menu() },
                { "UIs", new Scene_UI() },
                //{ "SceneEntitiesBullet", new Scene_Entities_Bullet() }
            };
            
            return scenes;
        }
    }
}