namespace Showroom
{
    public class Entity_Platformer_Player : BaseEntity
    {
        public Entity_Platformer_Player(Rectangle rectangle, int steps, string tag = "", bool isActive = true) : base(rectangle, tag, isActive)
        {
            this.rigidbody.gravity = 4;
            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Entity.PlatformerPlayer(lastInputState, inputState, this);
        }
    }
}