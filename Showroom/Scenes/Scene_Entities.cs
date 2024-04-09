
namespace Showroom.Scenes
{
    public class Scene_Entities : BaseScene
    {
        public override void Initialize()
        {
            this.UIs = new List<IUI>()
            {
                // Back to menu
                new Button(rectangle: new Rectangle(10, 460, 230, 30), text: "<-- Back to menu", defaultTexture: null, mouseOverTexture: null, tag: "", OnClickAction: () => Game1.ChangeToScene("Scene_Menu")),
            };


            this.entities = new List<IEntity>()
            {
                new ChristianTools.Entities.Line(new Point(100, 100), new Point(500, 500), Color.Red, tag: "RedLine")
                {
                    dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateLine(lastInputState, inputState)
                },

                new ZeroZeroPoint_Entity(),

                // TL
                new Entity_Numbers(new Rectangle(0, 0, 16, 16), WK.AtlasEntitiesReferences.Idle_Left),

                // TR
                new Entity_Numbers(new Rectangle(484, 0, 16, 16), WK.AtlasEntitiesReferences.Idl_Right),

                // Center
                new Entity_WASD(
                    rectangle: MyRectangle.CreateRectangle(new Point(250, 250), 16, 16),
                    imageFromAtlas: WK.AtlasEntitiesReferences.Idel_Down,
                    steps: 10,
                    tag: "player"
                ),

                // DL
                new Entity_Numbers(new Rectangle(0, 484, 16, 16), WK.AtlasEntitiesReferences.Idle_Left),

                // DR
                new Entity_Numbers(new Rectangle(484, 484, 16, 16), WK.AtlasEntitiesReferences.Idl_Right),
            };

            this.camera = new Camera(zoom: 1, entityToFollow: entities.Find(x => x.tag == "player"));
        }

        private void UpdateLine(InputState lastInputState, InputState inputState)
        {

            ChristianTools.Entities.Line line = entities.Find(x => x.tag == "RedLine") as ChristianTools.Entities.Line;

            if (lastInputState.Action)
            {
                Point? point = lastInputState.GetActionOnWorldPosition();
                line.UpdatePoints(end: point);
            }

            if (lastInputState.mouse.IsRightButton_Click)
            {
                Point? point = lastInputState.GetActionOnWorldPosition();
                line.UpdatePoints(start: point);
            }
        }
    }
}
