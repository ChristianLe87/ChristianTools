using ChristianTools.Helpers;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Systems.Draw
{
    public class Scene
    {
        public static void DrawSystem(SpriteBatch spriteBatch)
        {
            IScene scene = ChristianGame.scenes[ChristianGame.actualScene];
            
            // UIs
            if (scene.UIs != null)
                foreach (var ui in scene.UIs)
                    ui.dxDrawSystem(spriteBatch: spriteBatch);

            // Entities
            if (scene.entities != null)
                for (int i = 0; i < scene.entities.Count; i++)
                    if (scene.entities[i].dxDrawSystem != null)
                        scene.entities[i].dxDrawSystem(spriteBatch: spriteBatch);
        }
    }
}