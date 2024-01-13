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

		string textOfChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ\nabcdefghijklmnopqrstuvwxyz\n0123456789Ññß\n,:;?.! \'()_\"<>-+\\";
		//public List<SoundEffect> soundEffects { get; private set; }

		public void Initialize(Viewport viewport)
		{


			this.UIs = new List<IUI>()
			{
				new Button(
					rectangle: new Rectangle(360, 10, 100, 50),
					text: "Hello World",
					defaultTexture: null,
					mouseOverTexture: null,
					tag: "",
					OnClickAction: () => Console.WriteLine("User click button!")
				),

				// Left
				new Label(new Rectangle(10, 10, 100, 30), "My Text", textAlignment: Label.TextAlignment.Top_Left, ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray)),
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


				//new HealthBar(ChristianTools.Helpers.MyColors.CreateColorTexture(Color.Green), ChristianTools.Helpers.MyColors.CreateColorTexture(Color.Red), new Rectangle(10, 130, 50, 10), HealthBar.Direction.Right),
				//new HealthBar(ChristianTools.Helpers.MyColors.CreateColorTexture(Color.Green), ChristianTools.Helpers.MyColors.CreateColorTexture(Color.Red), new Rectangle(10, 150, 50, 10), HealthBar.Direction.Left),

				//new HealthBar(ChristianTools.Helpers.MyColors.CreateColorTexture(Color.Green), ChristianTools.Helpers.MyColors.CreateColorTexture(Color.Red), new Rectangle(10, 175, 10, 50), HealthBar.Direction.Up),
				//new HealthBar(ChristianTools.Helpers.MyColors.CreateColorTexture(Color.Green), ChristianTools.Helpers.MyColors.CreateColorTexture(Color.Red), new Rectangle(30, 175, 10, 50), HealthBar.Direction.Down),

				new Label(
					rectangle: new Rectangle(100, 150, 100, 30),
					text: textOfChars,
					textAlignment: Label.TextAlignment.Top_Left,
					tag: ""
				),



				/*new Button(
				     rectangle: new Rectangle(360, 100, 100, 50),
				     text: "Play sound",
				     defaultTexture: ChristianTools.Helpers.MyColors.CreateColorTexture(Color.Green),
				     mouseOverTexture: ChristianTools.Helpers.MyColors.CreateColorTexture(Color.Red),
				     tag: "SoundButton"
				     //OnClickAction: () =>  soundEffects.First().Play()
				 ),*/

				/*new Button(
				    rectangle: new Rectangle(0, 470, 230, 30),
				    text: "<- Menu",
				    defaultTexture: WK.Texture.LightGray,
				    mouseOverTexture: WK.Texture.Gray,
				    tag: "goToMenu",
				    OnClickAction: () => Game1.ChangeToScene(WK.Scene.Menu)
				)*/
			};

			/*this.soundEffects = new List<SoundEffect>()
			{
			    ChristianTools.Helpers.Sound.GetSoundEffect(Path.Combine("Sounds", "EatingSound_WAV"))
			};*/

			//this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => Update(lastInputState, inputState);

		}
	}
}