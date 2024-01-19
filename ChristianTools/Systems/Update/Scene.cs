using System.Linq;
using ChristianTools.Helpers;

namespace ChristianTools.Systems.Update
{

    public class Scene
    {
        public static void UpdateSystem(InputState lastInputState, InputState inputState)
        {
            IScene scene = ChristianGame.scenes[ChristianGame.actualScene];

            // UIs
            {
                if (scene.UIs != null)
                    foreach (var ui in scene.UIs)
                        ui.dxUpdateSystem(lastInputState: lastInputState, inputState: inputState);
            }
         

            // Entities
            {
                if (scene.entities != null)
                    for (int i = 0; i < scene.entities.Count; i++)
                        if (scene.entities[i].dxUpdateSystem != null)
                            scene.entities[i].dxUpdateSystem(lastInputState: lastInputState, inputState: inputState);
            }
          

            // Camera
            {
                if (scene.camera != null)
                    if (scene.entities != null)
                        if (scene.entities.Where(x => x.tag == "player").Count() > 0)
                            scene.camera.MoveCamera(scene.entities.Where(x => x.tag == "player").FirstOrDefault().rigidbody.rectangle.Center);
            
                if (scene.camera != null)
                    scene.camera.UpdateCamera();
            }
        }
    }    
}
