using System.ComponentModel;
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
                    new MyShooter()
                };
            }

            // UI
            {
                this.UIs = new List<IUI>()
                {
                };
            }
        }


        public class MyShooter : BaseEntity
        {
            public MyShooter() : base(new Rectangle(ChristianGame.WK.CanvasWidth / 2, ChristianGame.WK.CanvasHeight / 2, 0, 0))
            {
                base.dxCustomUpdateSystem = (lastInputState, inputState) => MyUpdate(lastInputState, inputState);
            }


            public void MyUpdate(InputState lastInputState, InputState inputState)
            {
                if (inputState.Action == true && lastInputState.Action == false)
                {
                    Vector2 centerPosition = this.rigidbody.rectangle.Center.ToVector2();
                    Vector2 direction = inputState.GetActionOnWorldPosition().ToVector2();
                    
                    ChristianGame.GetScene.entities.Add(
                        new Bullet(
                            centerPosition: centerPosition,
                            direction: direction
                        )
                    );
                }

                ChristianTools.Systems.Update.Entity.Move_WASD_Clamp(lastInputState, inputState, this);
            }
        }
    }
}