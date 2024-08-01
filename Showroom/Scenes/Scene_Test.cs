using Line = ChristianTools.Entities.Line;

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
                    new Something(new Rectangle(), tag: ""),
                };
            }

            // UI
            {
                this.UIs = new List<IUI>()
                {
                    //new Button(UI_Position: Alignment.Down_Left, width: 230, height: 30, margin: 10, text: "<-- Back to menu", defaultTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray), mouseOverTexture: ChristianTools.Helpers.Texture.CreateColorTexture(Color.Gray), tag: "", OnClickAction: () => Game1.ChangeToScene("Scene_Menu")),
                    //new ZeroZeroPoint_UI(),

                    //new LineUI(new Point(0,0), new Point(250,250), Color.Red, tag: "LineRed"),
                };
            }

            //this.camera = new Camera(entityToFollow: entities.Find(x => x.tag == "player"));
        }
    }

    public class Something : BaseEntity
    {
        public Something(Rectangle rectangle, string tag) : base(rectangle, tag)
        {
            base.dxCustomUpdateSystem = (lastInputState, inputState) => Update(lastInputState, inputState);
        }

        private void Update(InputState lastInputState, InputState inputState)
        {

            if (inputState.touch.IsTouchDown() || inputState.mouse.IsLeftButton_Click)
            {
                Console.WriteLine("========================");
                Console.WriteLine($"=== touch: {inputState.touch.GetOnWorldTouch()} ===");
                Console.WriteLine($"=== mouse: {inputState.mouse.GetOnWorldPosition()} ===");


                base.rigidbody.SetCenterPosition(inputState.touch.GetOnWorldTouch());
            }
            
        }
    }
}