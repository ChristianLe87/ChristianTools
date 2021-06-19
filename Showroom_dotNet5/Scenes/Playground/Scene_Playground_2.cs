using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using zAssets;
using zTools;
using zUI;
using zWorldElements;

namespace Showroom_dotNet5
{
    public class Scene_Playground_2 : IScene
    {
        Player player;
        List<IWorldElement> worldElements;
        InputState lastInputState;


        Label timeLabel;


        public Scene_Playground_2()
        {
            Initialize();
        }

        public void Initialize()
        {
            Texture2D playerTexture = Tools.Texture.CreateColorTexture(
                graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                color: Color.Red,
                Width: 1 * WK.Default.Block.Pixels.Width,
                Height: 1 * WK.Default.Block.Pixels.Height
            );

            this.player = new Player(new Point(20, 20), playerTexture);

            this.worldElements = GetTileMap(WK.Map.map2);


            this.timeLabel = new Label(
                new Rectangle(10, 10, 100, 30),
                Tools.Font.GetFont(Game1.contentManager, "Arial_10", "Fonts"),
                "My Text",
                Label.TextAlignment.Down_Left,
                Color.Black,
                Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, 100, 30),
                11);
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
                //if (worldElement.GetType() != typeof(Slope))
                worldElement.Draw(spriteBatch);
            }

            timeLabel.Draw(spriteBatch);

        }

        private List<IWorldElement> GetTileMap(int[,] originalMap)
        {
            List<IWorldElement> worldElements = new List<IWorldElement>();

            for (int row = 0; row < originalMap.GetLength(0); row++)
            {
                for (int elem = 0; elem < originalMap.GetLength(1); elem++)
                {
                    switch (originalMap[row, elem])
                    {
                        case 1:
                            worldElements.Add(
                                new WorldBlock(
                                    centerPoint: new Rectangle(elem * 16, row * 16, WK.Default.Block.Pixels.Width, WK.Default.Block.Pixels.Height).Center,
                                    texture2D: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green, WK.Default.Block.Pixels.Width, WK.Default.Block.Pixels.Height),
                                    tag: "x")
                            );
                            break;
                    }
                }
            }
            return worldElements;
        }
    }
}