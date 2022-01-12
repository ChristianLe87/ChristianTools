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
                if (scene.dxSceneDrawSystem != null)
                    scene.dxSceneDrawSystem(spriteBatch);

                if (scene.map != null)
                    scene.map.Draw(spriteBatch);

                if (scene.entities != null)
                    foreach (var entity in scene.entities)
                        Systems.Draw.Entity(spriteBatch, entity);

                if (scene.UIs != null)
                    foreach (var ui in scene.UIs)
                        Systems.Draw.UI(spriteBatch, ui);
            }
        }
    }
}