namespace Showroom.Scenes
{
	public class Scene_UI : BaseScene
	{
		public override void Initialize()
		{
			string textOfChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ\nabcdefghijklmnopqrstuvwxyz\n0123456789Ññß\n,:;?.! \'()_\"<>-+\\";
			//public List<SoundEffect> soundEffects { get; private set; }

			Texture2D lightSlateGray = ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightSlateGray);
			Texture2D lightGray = ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray);


			this.UIs = new List<IUI>()
			{
				new Button(UI_Position: Alignment.Top_Left, width: 100, height: 50, text: "Hello World", defaultTexture: null, mouseOverTexture: null, tag: "", OnClickAction: () => Console.WriteLine("User click button!")),

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
				new Label(text: "Midle_Center", textAlignment: Alignment.Midle_Center, UI_Position: Alignment.Midle_Center, Width: 100, Height: 20, margin: 0, texture: lightSlateGray),
				new Label(text: "Down_Center", textAlignment: Alignment.Down_Center, UI_Position: Alignment.Down_Center, Width: 100, Height: 20, margin: 0, texture: lightSlateGray),

				// Position Alignment Righr
				new Label(text: "Top_Right", textAlignment: Alignment.Top_Right, UI_Position: Alignment.Top_Right, Width: 100, Height: 20, margin: 0, texture: lightSlateGray),
				new Label(text: "Midle_Right", textAlignment: Alignment.Midle_Right, UI_Position: Alignment.Midle_Right, Width: 100, Height: 20, margin: 0, texture: lightSlateGray),
				new Label(text: "Down_Right", textAlignment: Alignment.Down_Center, UI_Position: Alignment.Down_Right, Width: 100, Height: 20, margin: 0, texture: lightSlateGray),


				// textOfChars 
				new Label(rectangle: new Rectangle(100, 150, 100, 30), text: textOfChars, textAlignment: Alignment.Top_Left),

				// Back to menu
				new Button(
					UI_Position: Alignment.Down_Left,
					width: 230,
					height: 30,
					margin: 10,
					text: "<-- Back to menu",
					defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
					mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
					tag: "",
					OnClickAction: () => Game1.ChangeToScene("Scene_Menu")
				),

				new LineUI(start: new Point(400, 100), end: new Point(350, 150), color: Color.Red),
				new LineUI(start: new Point(350, 100), end: new Point(400, 150), color: Color.Green),

				new ZeroZeroPoint_UI()
			};


			this.entities = new List<IEntity>()
			{
				new ZeroZeroPoint_Entity(),

				// TL
				new Entity_Numbers(new Rectangle(0, 0, 16, 16)),

				// TR
				new Entity_Numbers(new Rectangle(484, 0, 16, 16)),

				// Center
				new Entity_WASD(
					rectangle: MyRectangle.CreateRectangle(new Point(250, 250), 16, 16),
					tag: "player"
				),

				// DL
				new Entity_Numbers(new Rectangle(0, 484, 16, 16)),

				// DR
				new Entity_Numbers(new Rectangle(484, 484, 16, 16)),
			};

			this.camera = new Camera(entityToFollow: entities.Find(x => x.tag == "player"));
		}
	}
}