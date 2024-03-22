using ChristianTools.Helpers;

namespace ChristianTools.Systems.Update
{
    public class Scene
    {
        public static void Update(InputState lastInputState, InputState inputState)
        {
            IScene scene = ChristianGame.GetScene;

            // UIs
            {
                if (scene.UIs != null)
                    foreach (var ui in scene.UIs)
                        ui.dxCustomUpdateSystem?.Invoke(lastInputState: lastInputState, inputState: inputState);
            }
            
            // Entities
            {
                if (scene.entities != null)
                    for (int i = 0; i < scene.entities.Count; i++)
                        scene.entities[i].dxCustomUpdateSystem?.Invoke(lastInputState: lastInputState, inputState: inputState);
            }
            
            // Camera
            {
                if (scene.camera != null)
                    scene.camera.Update();
            }

        }
    }
}
