
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
                    new ZeroZeroPoint_Entity(),
                    new ChristianTools.Entities.Line(new Point(ChristianGame.WK.CanvasWidth / 2, ChristianGame.WK.CanvasHeight / 2), new Point(0, 0), Color.Red),
                    new Entity_Shooter(),
                    new ChristianTools.Entities.Line(new Point((ChristianGame.WK.CanvasWidth / 2) - 50, ChristianGame.WK.CanvasHeight / 2), new Point((ChristianGame.WK.CanvasWidth / 2) + 50, ChristianGame.WK.CanvasHeight / 2), Color.Red),
                };
            }

            // UI
            {
                this.UIs = new List<IUI>()
                {
                    // Back to menu
                    new Button(UI_Position: Alignment.Down_Left, width: 230, height: 30, margin: 10, text: "<-- Back to menu", defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray), mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray), tag: "", OnClickAction: () => Game1.ChangeToScene("Scene_Menu")),
                };
            }
        }
    }
}
