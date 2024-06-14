namespace Showroom.Scenes
{
	public class Scene_UI : BaseScene
	{
		public override void Initialize()
		{
			string textOfChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ\nabcdefghijklmnopqrstuvwxyz\n0123456789Ññß\n,:;?.! \'()_\"<>-+\\";
			//public List<SoundEffect> soundEffects { get; private set; }

			this.UIs = new List<IUI>()
			{
				new Button(rectangle: new Rectangle(360, 10, 100, 50), text: "Hello World", defaultTexture: null, mouseOverTexture: null, tag: "", OnClickAction: () => Console.WriteLine("User click button!")),

				// Left
				new Label(new Rectangle(10, 10, 100, 30), "My Text", Alignment.Top_Left, ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray)),
				new Label(new Rectangle(10, 50, 100, 30), "My Text", Alignment.Midle_Left, ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray)),
				new Label(new Rectangle(10, 90, 100, 30), "My Text", Alignment.Down_Left, ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray)),

				// Center
				new Label(new Rectangle(120, 10, 100, 30), "My Text", Alignment.Top_Center, ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray)),
				new Label(new Rectangle(120, 50, 100, 30), "My Text", Alignment.Midle_Center, ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray)),
				new Label(new Rectangle(120, 90, 100, 30), "My Text", Alignment.Down_Center, ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray)),

				// Right
				new Label(new Rectangle(230, 10, 100, 30), "My Text", Alignment.Top_Right, ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray)),
				new Label(new Rectangle(230, 50, 100, 30), "My Text", Alignment.Midle_Right, ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray)),
				new Label(new Rectangle(230, 90, 100, 30), "My Text", Alignment.Down_Right, ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray)),

				// textOfChars 
				new Label(rectangle: new Rectangle(100, 150, 100, 30), text: textOfChars, textAlignment: Alignment.Top_Left, tag: ""),

				// Back to menu
				new Button(rectangle: new Rectangle(10, 460, 230, 30), text: "<-- Back to menu", defaultTexture: null, mouseOverTexture: null, tag: "", OnClickAction: () => Game1.ChangeToScene("Scene_Menu")),

				new LineUI(start: new Point(400, 100), end: new Point(350, 150), color: Color.Red),
				new LineUI(start: new Point(350, 100), end: new Point(400, 150), color: Color.Green),

				new ZeroZeroPoint_UI()
			};


			this.entities = new List<IEntity>()
			{
				new ZeroZeroPoint_Entity(),

				// TL
				new Entity_Numbers(new Rectangle(0, 0, 16, 16), WK.AtlasEntitiesReferences.Idle_Left),

				// TR
				new Entity_Numbers(new Rectangle(484, 0, 16, 16), WK.AtlasEntitiesReferences.Idl_Right),

				// Center
				new Entity_WASD(
					rectangle: MyRectangle.CreateRectangle(new Point(250, 250), 16, 16),
					imageFromAtlas: WK.AtlasEntitiesReferences.Idel_Down,
					tag: "player"
				),

				// DL
				new Entity_Numbers(new Rectangle(0, 484, 16, 16), WK.AtlasEntitiesReferences.Idle_Left),

				// DR
				new Entity_Numbers(new Rectangle(484, 484, 16, 16), WK.AtlasEntitiesReferences.Idl_Right),
			};

			this.camera = new Camera(zoom: 1, entityToFollow: entities.Find(x => x.tag == "player"));
		}
	}
}