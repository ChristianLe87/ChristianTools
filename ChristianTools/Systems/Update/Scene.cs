using System.Linq;
using ChristianTools.Helpers;
using ChristianTools.Helpers.Enums_Interfaces_Delegates;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Systems
{
	public partial class Update
	{
		public static void Scene(Viewport viewport, InputState lastInputState, InputState inputState, IScene scene)
		{
			// UIs
			if (scene.UIs != null)
				foreach (var ui in scene.UIs)
					Systems.Update.UI(viewport, lastInputState, inputState, scene, ui);

			// Entities
			if (scene.entities != null)
				for (int i = 0; i < scene.entities.Count; i++)
					Systems.Update.Entity(viewport, lastInputState, inputState, scene, scene.entities[i]);

			// Camera
			if (scene.camera != null)
			{
				if (scene.entities != null)
				{
					IEntity player = scene.entities.Where(x => x.tag == "player")?.FirstOrDefault();
					if (player != null)
						Systems.Update.Camera(scene.camera, player.rigidbody.rectangle.Center.ToVector2());
				}
			}

			// Map
			/*if (scene.map != null)
			{
				foreach (ITile tile in scene.map.tiles)
					Systems.Update.Tile(lastInputState, inputState, tile);

				foreach (IShadow shadow in scene.map.shadows)
					Systems.Update.Shadow(lastInputState, inputState, shadow);

				if (scene.map.lights != null)
					foreach (var light in scene.map.lights)
						Systems.Update.Light(lastInputState, inputState, light);
			}*/


			// Scene delegate
			if (scene.dxUpdateSystem != null)
				scene.dxUpdateSystem(viewport, lastInputState, inputState, scene);

		}
	}
}