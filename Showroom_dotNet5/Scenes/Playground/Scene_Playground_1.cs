using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using zAssets;
using zTools;
using zWorldElements;

namespace Showroom_dotNet5
{
    // Based on: https://www.moddb.com/games/monochroma/tutorials/road-to-monochroma-platformer-design-elements
    public class Scene_Playground_1 : IScene
    {
        Player player;
        List<IWorldElement> worldElements;

        InputState lastInputState;

        public Scene_Playground_1()
        {
            Initialize();
        }

        public void Initialize()
        {
            Texture2D groundTexture = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 50 * 16, 2 * 16);
            Texture2D worldBlockTexture = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 20,20);
            Texture2D ladderTexture = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Brown, 16, 5 * 16);
            Texture2D slopeTexture = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Pink);
            Texture2D playerTexture = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red, 16, 16);

            this.player = new Player(new Point(20,20), playerTexture);

            this.worldElements = new List<IWorldElement>()
            {
                new WorldBlock(centerPoint: new Point(groundTexture.Width / 2, 7 * 16), texture2D: groundTexture),
                new WorldBlock(centerPoint: new Point(40,50), texture2D: worldBlockTexture),

                new Ladder(centerPoint: new Point(152, 16 * 3 + 8), texture2D: ladderTexture),

                new Slope(
                    rectangle: new Rectangle().Create(centerPoint: new Point(WK.Default.Width / 2, WK.Default.Height / 2), Width: 100, Height: 100),
                    texture2D: slopeTexture,
                    slopeFace: SlopeOrientation.Right
                ),
                new Slope(
                    rectangle: new Rectangle().Create(centerPoint: new Point(WK.Default.Width / 2, WK.Default.Height / 2), Width: 200, Height: 100),
                    texture2D: slopeTexture,
                    slopeFace: SlopeOrientation.Left
                )
            };
        }

        public void Update()
        {
            InputState inputState = new InputState();

            player.Update(inputState, lastInputState, worldElements);

            lastInputState = inputState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            foreach (var worldElement in worldElements)
            {
                if(worldElement.GetType() != typeof(Slope))
                    worldElement.Draw(spriteBatch);
            }
                
        }
    }
}
