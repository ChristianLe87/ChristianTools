using ChristianTools.Helpers;

namespace ChristianTools.Systems.Update
{
    public class Scene
    {
        public static void UpdateSystem(InputState lastInputState, InputState inputState)
        {
            IScene scene = ChristianGame.GetScene;

            // UIs
            {
                if (scene.UIs != null)
                    foreach (var ui in scene.UIs)
                        ui.dxUpdateSystem?.Invoke(lastInputState: lastInputState, inputState: inputState);
            }
         

            // Entities
            {
                if (scene.entities != null)
                {
                    for (int i = 0; i < scene.entities.Count; i++)
                    {
                        ChristianTools.Systems.Update.Entity.UpdateSystem(scene.entities[i]);
                        scene.entities[i].dxUpdateSystem?.Invoke(lastInputState, inputState);
                    }
                }
            }


            // Camera
            {
                if (scene.camera != null)
                {
                    scene.camera.UpdateCamera();
                }
            }
        }
    }    
}
