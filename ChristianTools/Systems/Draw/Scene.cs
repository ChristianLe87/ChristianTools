using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Systems.Draw
{
    public class Scene
    {
        public static void DrawSystem(SpriteBatch spriteBatch)
        {
            IScene scene = ChristianGame.GetScene;
            
            // Map
            if (scene.map != null)
            {
                //mainLayer
                foreach (Tile myTile in scene.map.mainTiles)
                {
                    Systems.Draw.Map.Tile.DrawSystem(spriteBatch, myTile);
                }
            }

            // UIs
            if (scene.UIs != null)
                foreach (var ui in scene.UIs)
                    ui.dxDrawSystem(spriteBatch: spriteBatch);

            // Entities
            if (scene.entities != null)
            {
                for (int i = 0; i < scene.entities.Count; i++)
                {
                    ChristianTools.Systems.Draw.Entity.DrawSystem(spriteBatch, scene.entities[i]);
                    scene.entities[i].dxDrawSystem?.Invoke(spriteBatch: spriteBatch);
                }
            }
        }
    }
}