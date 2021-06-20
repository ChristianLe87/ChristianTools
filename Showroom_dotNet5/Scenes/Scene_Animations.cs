using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using zAssets;

namespace Showroom_dotNet5
{
    public class Scene_Animations : IScene
    {
        Player player;

        public Scene_Animations()
        {
            Initialize();
        }

        public void Initialize()
        {
            // animations
            Dictionary<AnimationState, Animation> animations = new Dictionary<AnimationState, Animation>()
            {
                { AnimationState.RunLeft, new Animation(zTools.Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Image.RunLeft_64x450_PNG), 10, 0.5f) },
            };


            this.player = new Player(
                                    centerPoint: new Point(200, 200),
                                    animations: animations
                                    );
        }

        public void Update()
        {
            //throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
        }
    }
}
