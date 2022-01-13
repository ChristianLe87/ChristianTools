using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Systems
{
    public partial class Systems
    {
        public partial class Draw
        {
            public static void Scene(SpriteBatch spriteBatch, IScene scene)
            {
                // Tiles
                if (scene.map != null)
                    foreach (ITile tile in scene.map.tiles)
                        Systems.Draw.Tile(spriteBatch, tile);


                // Entities
                if (scene.entities != null)
                    foreach (IEntity entity in scene.entities)
                        Systems.Draw.Entity(spriteBatch, entity);


                // UIs
                if (scene.UIs != null)
                    foreach (IUI ui in scene.UIs)
                        Systems.Draw.UI(spriteBatch, ui);


                if (scene.dxSceneDrawSystem != null)
                    scene.dxSceneDrawSystem(spriteBatch);
            }
        }
    }
}