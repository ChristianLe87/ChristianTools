using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using zWorldElements;

namespace Showroom_dotNet5
{
    /// <summary>
    /// Based on Monochroma tutorial
    /// https://www.moddb.com/games/monochroma/tutorials/road-to-monochroma-platformer-design-elements
    /// </summary>
    public class Scene_Playground_1 : IScene
    {
        WorldBlock ground;
        Ladder ladder;
        Slope slope_1;
        Slope slope_2;

        public Scene_Playground_1()
        {
            Initialize();
        }

        public void Initialize()
        {
            Texture2D groundTexture = zTools.Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 50 * 16, 2 * 16);
            this.ground = new WorldBlock(centerPoint: new Point(groundTexture.Width / 2, 7 * 16), texture2D: groundTexture);

            Texture2D ladderTexture = zTools.Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Brown, 16, 5 * 16);
            this.ladder = new Ladder(centerPoint: new Point(152, 16 * 3 + 8), texture2D: ladderTexture);

            Texture2D slopeTexture = zTools.Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Pink);
            this.slope_1 = new Slope(centerPoint: new Point(16*2+16, 20+40), texture2D: slopeTexture, slopeFace: SlopeFace.Right);
            this.slope_2 = new Slope(centerPoint: new Point(16 * 4 + 16, 20+60), texture2D: slopeTexture, slopeFace: SlopeFace.Left);
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ground.Draw(spriteBatch);
            ladder.Draw(spriteBatch);
            slope_1.Draw(spriteBatch);
            slope_2.Draw(spriteBatch);
        }
    }
}
