namespace Showroom.Scenes
{
	public class Scene_UI : BaseScene
	{
		public override void Initialize()
		{
			int ts = ChristianGame.WK.TileSize;

			string textOfChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ\nabcdefghijklmnopqrstuvwxyz\n0123456789Ññß\n,:;?.! \'()_\"<>-+\\{}";
			//public List<SoundEffect> soundEffects { get; private set; }

			Texture2D lightSlateGray = ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightSlateGray);
			Texture2D lightGray = ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray);


			int buttonMargin = 20;

			this.UIs = new List<IUI>()
			{
				new Button(rectangle: new Rectangle(360, 10, 100, 50), text: "Hello World", defaultTexture: null, mouseOverTexture: null, tag: "", OnClickAction: () => Console.WriteLine("User click button!")),

				// === Rectangle ===
				// Text Alignment Left
				new Label(rectangle: new Rectangle(10, 10, 100, 30), text: "My Text", textAlignment: Alignment.Top_Left, texture: lightGray),
				new Label(rectangle: new Rectangle(10, 50, 100, 30), text: "My Text", textAlignment: Alignment.Midle_Left, texture: lightGray),
				new Label(rectangle: new Rectangle(10, 90, 100, 30), text: "My Text", textAlignment: Alignment.Down_Left, texture: lightGray),
				// Text Alignment Center
				new Label(rectangle: new Rectangle(120, 10, 100, 30), text: "My Text", textAlignment: Alignment.Top_Center, texture: lightGray),
				new Label(rectangle: new Rectangle(120, 50, 100, 30), text: "My Text", textAlignment: Alignment.Midle_Center, texture: lightGray),
				new Label(rectangle: new Rectangle(120, 90, 100, 30), text: "My Text", textAlignment: Alignment.Down_Center, texture: lightGray),
				// Text Alignment Right
				new Label(rectangle: new Rectangle(230, 10, 100, 30), text: "My Text", textAlignment: Alignment.Top_Right, texture: lightGray),
				new Label(rectangle: new Rectangle(230, 50, 100, 30), text: "My Text", textAlignment: Alignment.Midle_Right, texture: lightGray),
				new Label(rectangle: new Rectangle(230, 90, 100, 30), text: "My Text", textAlignment: Alignment.Down_Right, texture: lightGray),


				// === Alignment ===
				// Position Alignment Left
				new Label(text: "Top_Left", textAlignment: Alignment.Top_Left, UI_Position: Alignment.Top_Left, Width: 100, Height: 20, margin: 0, texture: lightSlateGray),
				new Label(text: "Midle_Left", textAlignment: Alignment.Midle_Left, UI_Position: Alignment.Midle_Left, Width: 100, Height: 20, margin: 0, texture: lightSlateGray),
				new Label(text: "Down_Left", textAlignment: Alignment.Down_Left, UI_Position: Alignment.Down_Left, Width: 100, Height: 20, margin: 0, texture: lightSlateGray),
				// Position Alignment Center
				new Label(text: "Top_Center", textAlignment: Alignment.Top_Center, UI_Position: Alignment.Top_Center, Width: 100, Height: 20, margin: 0, texture: lightSlateGray),
				new Label(text: "Midle_Center", textAlignment: Alignment.Midle_Center, UI_Position: Alignment.Midle_Center, Width: 100, Height: 20, margin: 0),
				new Label(text: "Down_Center", textAlignment: Alignment.Down_Center, UI_Position: Alignment.Down_Center, Width: 100, Height: 20, margin: 0, texture: lightSlateGray),
				// Position Alignment Righr
				new Label(text: "Top_Right", textAlignment: Alignment.Top_Right, UI_Position: Alignment.Top_Right, Width: 100, Height: 20, margin: 0, texture: lightSlateGray),
				new Label(text: "Midle_Right", textAlignment: Alignment.Midle_Right, UI_Position: Alignment.Midle_Right, Width: 100, Height: 20, margin: 0, texture: lightSlateGray),
				new Label(text: "Down_Right", textAlignment: Alignment.Down_Right, UI_Position: Alignment.Down_Right, Width: 100, Height: 20, margin: 0, texture: lightSlateGray),

				// textOfChars 
				new Label(rectangle: new Rectangle(100, 150, 100, 30), text: textOfChars, textAlignment: Alignment.Top_Left),


				// Button
				// Position Alignment Left
				new Button(text: "Top_Left", tag: "Top_Left", UI_Position: Alignment.Top_Left, width: 100, height: 20, margin: buttonMargin, OnClickAction: () => { }),
				new Button(text: "Midle_Left", tag: "Midle_Left", UI_Position: Alignment.Midle_Left, width: 100, height: 20, margin: buttonMargin, OnClickAction: () => { }),
				new Button(text: "<-- Back to menu", tag: "Down_Left", UI_Position: Alignment.Down_Left, width: 100, height: 20, margin: buttonMargin, OnClickAction: () => Game1.ChangeToScene("Scene_Menu")),
				// Position Alignment Center
				new Button(text: "Top_Center", tag: "Top_Center", UI_Position: Alignment.Top_Center, width: 100, height: 20, margin: buttonMargin, OnClickAction: () => { }),
				new Button(text: "Midle_Center", tag: "Midle_Center", UI_Position: Alignment.Midle_Center, width: 100, height: 20, margin: buttonMargin, OnClickAction: () => { }),
				new Button(text: "Down_Center", tag: "Down_Center", UI_Position: Alignment.Down_Center, width: 100, height: 20, margin: buttonMargin, OnClickAction: () => { }),
				// Position Alignment Righr
				new Button(text: "Top_Right", tag: "Top_Right", UI_Position: Alignment.Top_Right, width: 100, height: 20, margin: buttonMargin, OnClickAction: () => { }),
				new Button(text: "Midle_Right", tag: "Midle_Right", UI_Position: Alignment.Midle_Right, width: 100, height: 20, margin: buttonMargin, OnClickAction: () => { }),
				new Button(text: "Down_Right", tag: "Down_Right", UI_Position: Alignment.Down_Right, width: 100, height: 20, margin: buttonMargin, OnClickAction: () => { }),


				// Back to menu
				//new Button(UI_Position: Alignment.Down_Left, width: 230, height: 30, margin: 10, text: "<-- Back to menu", defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray), mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray), tag: "", OnClickAction: () => Game1.ChangeToScene("Scene_Menu")),

				//new LineUI(start: new Point(400, 100), end: new Point(350, 150), color: Color.Red),
				//new LineUI(start: new Point(350, 100), end: new Point(400, 150), color: Color.Green),

				new ZeroZeroPoint_UI()
			};


			this.entities = new List<IEntity>()
			{
				new ZeroZeroPoint_Entity(),

				// TL
				new Entity_Numbers(new Rectangle(0, 0, ts, ts)),

				// TR
				new Entity_Numbers(new Rectangle(484, 0, ts, ts)),

				// Center
				new Entity_WASD(
					rectangle: new Rectangle(10 * ts, 16 * ts, ts, ts),
					tag: "player"
				),

				// DL
				new Entity_Numbers(new Rectangle(0, 484, ts, ts)),

				// DR
				new Entity_Numbers(new Rectangle(484, 484, ts, ts)),
			};

			this.camera = new Camera(entityToFollow: entities.Find(x => x.tag == "player"));
		}
	}
}