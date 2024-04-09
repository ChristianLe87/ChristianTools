namespace Showroom
{
    public class Entity_Platformer_Player : BaseEntity
    {
        public Entity_Platformer_Player(Rectangle rectangle, Rectangle imageFromAtlas, int steps, string tag = "", bool isActive = true) : base(rectangle, imageFromAtlas, tag, isActive)
        {
            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Entity.PlatformerPlayer(lastInputState, inputState, this);
        }
    }
}