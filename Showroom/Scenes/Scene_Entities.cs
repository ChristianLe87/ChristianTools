
namespace Showroom.Scenes
{
    public class Scene_Entities : BaseScene
    {
        public override void Initialize()
        {
            this.UIs = new List<IUI>()
            {
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
                )
            };

            this.entities = new List<IEntity>()
            {
                new ChristianTools.Entities.Line(new Point(100, 100), new Point(500, 500), Color.Red, tag: "RedLine")
                {
                    dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateLine(lastInputState, inputState)
                },

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

        private void UpdateLine(InputState lastInputState, InputState inputState)
        {

            ChristianTools.Entities.Line line = entities.Find(x => x.tag == "RedLine") as ChristianTools.Entities.Line;

            if (inputState.Action)
            {
                Point? point = inputState.mouse.GetOnWorldPosition();//.GetActionOnWorldPosition();
                
                line.UpdatePoints(end: point);
            }

            if (inputState.mouse.IsRightButton_Click)
            {
                Point? point = inputState.mouse.GetOnWorldPosition();
                line.UpdatePoints(start: point);
            }
        }
    }
}
