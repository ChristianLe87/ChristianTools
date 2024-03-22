using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Systems.Draw
{
    public class Scene
    {
        public static void DrawUI(SpriteBatch spriteBatch, IScene scene)
        {
            foreach (var ui in scene.UIs)
                if (ui.isActive)
                    ui.dxCustomDrawSystem?.Invoke(spriteBatch);
        }

        public static void DrawWorld(SpriteBatch spriteBatch, IScene scene)
        {
            // Map
            {
                if (scene.map != null)
                {
                    foreach (var tile in scene.map.backgroundTiles)
                        if (tile != null && tile.isActive)
                            Systems.Draw.Map.Tile.Draw(spriteBatch, tile);

                    foreach (var tile in scene.map.mainTiles)
                        if (tile != null && tile.isActive)
                            Systems.Draw.Map.Tile.Draw(spriteBatch, tile);

                    foreach (var tile in scene.map.frontTiles)
                        if (tile != null && tile.isActive)
                            Systems.Draw.Map.Tile.Draw(spriteBatch, tile);
                }
            }

            // Entity
            {
                foreach (var entity in scene.entities)
                    if (entity.isActive)
                        entity.dxCustomDrawSystem?.Invoke(spriteBatch);
            }
        }
    }
}
