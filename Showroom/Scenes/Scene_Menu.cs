namespace Showroom.Scenes
{
    public class Scene_Menu : BaseScene
    {
        public override void Initialize()
        {
            this.UIs = new List<IUI>()
            {
                /*new Label(
                    rectangle: new Rectangle(260, 10, 230, 30),
                    "Menu",
                    textAlignment: Alignment.Midle_Center
                ),
                new Button(
                    rectangle: new Rectangle(10, 10, 230, 30),
                    text: "Components",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Console.WriteLine("---") //Game1.ChangeToScene(WK.Scene.Components)
                ),
                new Button(
                    rectangle: new Rectangle(10, 50, 230, 30),
                    text: "Entities",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Game1.ChangeToScene("Scene_Entities")
                ),
                new Button(
                    rectangle: new Rectangle(10, 90, 230, 30),
                    text: "Helpers",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Console.WriteLine("---") //Game1.ChangeToScene(WK.Scene.Helpers)
                ),
                new Button(
                    rectangle: new Rectangle(10, 130, 230, 30),
                    text: "Tools",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Console.WriteLine("---") //Game1.ChangeToScene(WK.Scene.Tools)
                ),*/
                new Button(
                    Alignment.Midle_Left,
                    230, 30,
                    text: "UI",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Game1.ChangeToScene("Scene_UI")
                ),
                
                
                
                /*new Button(
                    rectangle: new Rectangle(10, 210, 230, 30),
                    text: "Systems",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Console.WriteLine("---") //Game1.ChangeToScene(WK.Scene.Systems)
                ),
                new Button(
                    rectangle: new Rectangle(250, 50, 230, 30),
                    text: "Platformer",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Game1.ChangeToScene("Scene_Platformer")
                ),
                new Button(
                    rectangle: new Rectangle(250, 90, 230, 30),
                    text: "Zeldamon",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Game1.ChangeToScene("Scene_Zeldamon")
                ),
                new Button(
                    rectangle: new Rectangle(250, 130, 230, 30),
                    text: "Tiles",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Game1.ChangeToScene("Scene_Tiles")
                ),
                new Button(
                    rectangle: new Rectangle(250, 170, 230, 30),
                    text: "Camera",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Game1.ChangeToScene("Scene_Camera")
                ),
                new Button(
                    rectangle: new Rectangle(250, 210, 230, 30),
                    text: "Scene_Test",
                    defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray),
                    mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray),
                    OnClickAction: () => Game1.ChangeToScene("Scene_Test")
                ),*/
            };
        }
    }
}