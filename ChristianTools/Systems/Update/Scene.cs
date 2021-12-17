using ChristianTools.Helpers;

namespace ChristianTools.Systems
{
    public partial class Systems
    {
        public partial class Update
        {
            public static void Scene(InputState lastInputState, InputState inputState, IScene scene)
            {
                if (scene.UIs != null)
                    foreach (var ui in scene.UIs)
                        ui.Update(lastInputState, inputState);

                if (scene.entities != null)
                    for (int i = 0; i < scene.entities.Count; i++)
                        Systems.Update.Entity(lastInputState, inputState, scene.entities[i]);

                if (scene.dxSceneUpdateSystem != null)
                    scene.dxSceneUpdateSystem(lastInputState, inputState);
            }
        }
    }
}