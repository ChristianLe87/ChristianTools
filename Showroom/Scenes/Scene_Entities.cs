
using Line = ChristianTools.Entities.Line;

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

                new Entity_Shooter()
                {
                    //dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateShooter(lastInputState, inputState)
                },
                
                new Line(new Point(ChristianGame.WK.CanvasWidth/2, ChristianGame.WK.CanvasHeight/2),new Point(), Color.Red, tag:"RedLine")
                {
                    dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateLine(lastInputState, inputState)
                },
                
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
                Point? point = inputState.GetActionOnWorldPosition();//.GetActionOnWorldPosition();
                
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
