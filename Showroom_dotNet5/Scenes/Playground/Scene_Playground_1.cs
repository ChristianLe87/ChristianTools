using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            Texture2D groundTexture = Tools.Texture.CreateColorTexture(
                graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                color: Color.Green,
                Width: 50 * WK.Default.Block.Pixels.Width,
                Height: 1 * WK.Default.Block.Pixels.Height
            );

            Texture2D worldBlockTexture = Tools.Texture.CreateColorTexture(
                graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                color: Color.Green,
                Width: 1 * WK.Default.Block.Pixels.Width,
                Height: 1 * WK.Default.Block.Pixels.Height
            );

            Texture2D ladderTexture = Tools.Texture.CreateColorTexture(
                graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                color: Color.Brown,
                Width: 1 * WK.Default.Block.Pixels.Width,
                Height: 5 * WK.Default.Block.Pixels.Height
            );

            Texture2D slopeTexture = Tools.Texture.CreateColorTexture(
                graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                color: Color.Pink
            );

            Texture2D playerTexture = Tools.Texture.CreateColorTexture(
                graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                color: Color.Red,
                Width: 1 * WK.Default.Block.Pixels.Width,
                Height: 1 * WK.Default.Block.Pixels.Height
            );

            this.player = new Player(new Point(20,20), playerTexture);

            this.worldElements = new List<IWorldElement>()
            {
                // Ground
                new WorldBlock(
                    centerPoint: new Point(groundTexture.Width / 2, 6 * WK.Default.Block.Pixels.Height),
                    texture2D: groundTexture
                ),

                // WorldBlock 1
                new WorldBlock(
                    centerPoint: new Point(40,50),
                    texture2D: worldBlockTexture
                ),

                new Ladder(
                    centerPoint: new Point( 9* WK.Default.Block.Pixels.Width, 3 * WK.Default.Block.Pixels.Height),
                    texture2D: ladderTexture
                ),

                new Slope(
                    rectangle: new Rectangle().Create(
                        centerPoint: WK.Default.Window.Pixels.Center,
                        Width: 100,
                        Height: 100
                    ),
                    texture2D: slopeTexture,
                    slopeFace: SlopeOrientation.Right
                ),
                new Slope(
                    rectangle: new Rectangle().Create(centerPoint: WK.Default.Window.Pixels.Center, Width: 200, Height: 100),
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
