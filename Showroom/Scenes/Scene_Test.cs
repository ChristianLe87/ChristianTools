namespace Showroom.Scenes
{
    public class Scene_Test : BaseScene
    {
        public override void Initialize()
        {
            // entities
            {
                this.entities = new List<IEntity>()
                {
                    new Entity_WASD(MyRectangle.CreateRectangle(new Point(250, 250), 16, 16), WK.AtlasEntitiesReferences.Idel_Down, tag: "player"),
                    new ZeroZeroPoint_Entity(),
                };
            }

            // UI
            {
                Texture2D lightSlateGray = ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightSlateGray);
                Texture2D lightGray = ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray);
                Texture2D gray = ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray);

                
                this.UIs = new List<IUI>()
                {
                    new Button(
                        rectangle: new Rectangle(10, 460, 230, 30),
                        text: "<-- Back to menu",
                        defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                        mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                        OnClickAction: () => Game1.ChangeToScene("Scene_Menu")
                    ),
                    new ZeroZeroPoint_UI(),
                    new Button(rectangle: new Rectangle(10, 460, 230, 30), text: "<-- Back to menu", defaultTexture: null, mouseOverTexture: null, tag: "", OnClickAction: () => Game1.ChangeToScene("Scene_Menu")),
                    
                    
                    // Position Alignment Left
                    new Button(UI_Position: Alignment.Top_Left, text: "Top_Left", W: 80, H: 10, defaultTexture: lightGray, mouseOverTexture: gray, OnClickAction: null),
                    new Button(UI_Position: Alignment.Midle_Left, text: "Midle_Left", W: 80, H: 10, defaultTexture: lightGray, mouseOverTexture: gray, OnClickAction: null),
                    new Button(UI_Position: Alignment.Down_Left, text: "Down_Left", W: 80, H: 10, defaultTexture: lightGray, mouseOverTexture: gray, OnClickAction: null),
				
                    // Position Alignment Center
                    new Button(UI_Position: Alignment.Top_Center, text: "Top_Center", W: 80, H: 10, defaultTexture: lightGray, mouseOverTexture: gray, OnClickAction: null),
                    new Button(UI_Position: Alignment.Midle_Center, text: "Midle_Center", W: 80, H: 10, defaultTexture: lightGray, mouseOverTexture: gray, OnClickAction: null),
                    new Button(UI_Position: Alignment.Down_Center, text: "Down_Center", W: 80, H: 10, defaultTexture: lightGray, mouseOverTexture: gray, OnClickAction: null),
				
                    // Position Alignment Righr
                    new Button(UI_Position: Alignment.Top_Right, text: "Top_Right", W: 80, H: 10, defaultTexture: lightGray, mouseOverTexture: gray, OnClickAction: null),
                    new Button(UI_Position: Alignment.Midle_Right, text: "Midle_Right", W: 80, H: 10, defaultTexture: lightGray, mouseOverTexture: gray, OnClickAction: null),
                    new Button(UI_Position: Alignment.Down_Right, text: "Down_Right", W: 80, H: 10, defaultTexture: lightGray, mouseOverTexture: gray, OnClickAction: null),
                    
                };
            }
            
            this.camera = new Camera(zoom: 1, entityToFollow: entities.Find(x => x.tag == "player"));
        }
    }
}
