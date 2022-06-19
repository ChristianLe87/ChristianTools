using System.Linq;
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

                // Entities
                if (scene.entities != null)
                    foreach (IEntity entity in scene.entities)
                        Systems.Draw.Entity(spriteBatch, entity);


                // UIs
                if (scene.UIs != null)
                    foreach (IUI ui in scene.UIs)
                        Systems.Draw.UI(spriteBatch, ui);

                // Map
                if (scene.map != null)
                {
                    // Tiles
                    if (true)
                    {
                        foreach (ITile tile in scene.map.tiles)
                            Systems.Draw.Tile(spriteBatch, tile);
                    }
                    else
                    {
                        foreach (ITile tile in scene.map.tiles.Where(x => x.layerID == Tiled.LayerId.Background).ToList())
                            Systems.Draw.Tile(spriteBatch, tile);

                        foreach (ITile tile in scene.map.tiles.Where(x => x.layerID == Tiled.LayerId.Main).ToList())
                            Systems.Draw.Tile(spriteBatch, tile);

                        foreach (ITile tile in scene.map.tiles.Where(x => x.layerID == Tiled.LayerId.Front).ToList())
                            Systems.Draw.Tile(spriteBatch, tile);

                        foreach (ITile tile in scene.map.tiles.Where(x => x.layerID == Tiled.LayerId.Entities).ToList())
                            Systems.Draw.Tile(spriteBatch, tile);
                    }
                    // Lights
                    if (scene.map.lights != null)
                        foreach (ILight light in scene.map.lights)
                            Systems.Draw.Light(spriteBatch, light);

                    // Shadow
                    foreach (IShadow shadow in scene.map.shadows)
                        Systems.Draw.Shadow(spriteBatch, shadow);
                }


                // dx
                if (scene.dxDrawSystem != null)
                    scene.dxDrawSystem(spriteBatch);
            }
        }
    }
}