using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using zTools;
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
        Slope slopeRight;
        Slope slopeLeft;

        public Scene_Playground_1()
        {
            Initialize();
        }

        public void Initialize()
        {
            Texture2D groundTexture = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 50 * 16, 2 * 16);
            this.ground = new WorldBlock(centerPoint: new Point(groundTexture.Width / 2, 7 * 16), texture2D: groundTexture);

            Texture2D ladderTexture = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Brown, 16, 5 * 16);
            this.ladder = new Ladder(centerPoint: new Point(152, 16 * 3 + 8), texture2D: ladderTexture);

            Texture2D slopeTexture = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Pink);
            this.slopeRight = new Slope(
                rectangle: new Rectangle().Create(centerPoint: new Point(WK.Default.Width / 2, WK.Default.Height / 2), Width: 100, Height: 100),
                texture2D: slopeTexture,
                slopeFace: SlopeOrientation.Right
            );
            this.slopeLeft = new Slope(
                rectangle: new Rectangle().Create(centerPoint: new Point(WK.Default.Width / 2, WK.Default.Height / 2), Width: 100, Height: 100),
                texture2D: slopeTexture,
                slopeFace: SlopeOrientation.Left
            );
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ground.Draw(spriteBatch);
            ladder.Draw(spriteBatch);
            slopeRight.Draw(spriteBatch);
            slopeLeft.Draw(spriteBatch);
        }
    }
}
