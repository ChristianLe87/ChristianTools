using System;
using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Showroom.Scenes
{
	public class Scene_UI : IScene
	{
		public List<IEntity> entities { get; set; }
		public List<IUI> UIs { get; set; }
		public Camera camera { get; set; }
		public DxUpdateSystem dxUpdateSystem { get; set; }
		public DxDrawSystem dxDrawSystem { get; set; }

		public void Initialize()
		{

			string textOfChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ\nabcdefghijklmnopqrstuvwxyz\n0123456789Ññß\n,:;?.! \'()_\"<>-+\\";
			//public List<SoundEffect> soundEffects { get; private set; }

			this.UIs = new List<IUI>()
			{
				new Button(rectangle: new Rectangle(360, 10, 100, 50), text: "Hello World", defaultTexture: null, mouseOverTexture: null, tag: "", OnClickAction: () => Console.WriteLine("User click button!")),

				// Left
				new Label(new Rectangle(10, 10, 100, 30), "My Text", Label.TextAlignment.Top_Left, ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray)),
				new Label(new Rectangle(10, 50, 100, 30), "My Text", Label.TextAlignment.Midle_Left, ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray)),
				new Label(new Rectangle(10, 90, 100, 30), "My Text", Label.TextAlignment.Down_Left, ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray)),

				// Center
				new Label(new Rectangle(120, 10, 100, 30), "My Text", Label.TextAlignment.Top_Center, ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray)),
				new Label(new Rectangle(120, 50, 100, 30), "My Text", Label.TextAlignment.Midle_Center, ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray)),
				new Label(new Rectangle(120, 90, 100, 30), "My Text", Label.TextAlignment.Down_Center, ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray)),

				// Right
				new Label(new Rectangle(230, 10, 100, 30), "My Text", Label.TextAlignment.Top_Right, ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray)),
				new Label(new Rectangle(230, 50, 100, 30), "My Text", Label.TextAlignment.Midle_Right, ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray)),
				new Label(new Rectangle(230, 90, 100, 30), "My Text", Label.TextAlignment.Down_Right, ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray)),
				
				// textOfChars 
				new Label(rectangle: new Rectangle(100, 150, 100, 30), text: textOfChars, textAlignment: Label.TextAlignment.Top_Left, tag: ""),

				// Back to menu
				new Button(rectangle: new Rectangle(10, 400, 100, 50), text: "<-- Back to menu", defaultTexture: null, mouseOverTexture: null, tag: "", OnClickAction: () => Game1.ChangeToScene("Scene_Menu")),

			};

			this.camera = new Camera(new Point(250,250));
			Console.WriteLine(this.camera.cameraView);
			
			this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Scene.UpdateSystem(lastInputState: lastInputState, inputState: inputState);
			this.dxDrawSystem = (SpriteBatch spriteBatch) => ChristianTools.Systems.Draw.Scene.DrawSystem(spriteBatch);
		}
	}
}