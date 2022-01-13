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
                        Systems.Update.UI(lastInputState, inputState, ui);


                if (scene.entities != null)
                    for (int i = 0; i < scene.entities.Count; i++)
                        Systems.Update.Entity(lastInputState, inputState, scene.entities[i]);


                if (scene.camera != null)
                {
                    IEntity player = scene.entities.Where(x => x.tag == "player").First();
                    Systems.Update.Camera(scene.camera, player.rigidbody.centerPosition);
                }


                if (scene.map != null)
                    foreach (ITile tile in scene.map.tiles)
                        Systems.Update.Tile(lastInputState, inputState, tile);


                if (scene.dxSceneUpdateSystem != null)
                    scene.dxSceneUpdateSystem(lastInputState, inputState);
            }
        }
    }
}