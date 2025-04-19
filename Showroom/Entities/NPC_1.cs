using ChristianTools.Systems;

namespace Showroom
{
    public class NPC_1 : BaseEntity
    {

        private static class CharacterState
        {
            public static string IdleUp => "IdleUp";
            public static string IdleDown => "IdleDown";
            public static string IdleRight => "IdleRight";
            public static string IdleLeft => "IdleLeft";
            public static string MoveUp => "MoveUp";
            public static string MoveDown => "MoveDown";
            public static string MoveRight => "MoveRight";
            public static string MoveLeft => "MoveLeft";
        }

        private string labelTag;
        //private bool activateLabel = false;

        public NPC_1(Rectangle rectangle, string tag = "", bool isActive = true) : base(rectangle, tag, isActive)
        {
            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem(lastInputState, inputState);
        }

        private void UpdateSystem(InputState lastInputState, InputState inputState)
        {
            IEntity player = ChristianGame.GetScene.entities.Where(x => x.tag == "player").FirstOrDefault();
            IUI label = ChristianGame.GetScene.UIs.Where(x => x.tag == "npc2").FirstOrDefault();

            if (player != null) RotateBaseOnPlayerPosition(player);
            if (label != null) ActivateLabel(player, label);
        }

        private void RotateBaseOnPlayerPosition(IEntity player)
        {
            Vector2 playerPosition = player.rigidbody.centerPosition;
            Vector2 npcPosition = this.rigidbody.centerPosition;

            if (playerPosition.Y > npcPosition.Y)
            {
                animation.characterState = CharacterState.IdleDown;
            }
            else if (playerPosition.Y < npcPosition.Y)
            {
                animation.characterState = CharacterState.IdleUp;
            }
            else if (playerPosition.X > npcPosition.X)
            {
                animation.characterState = CharacterState.IdleRight;
            }
            else if (playerPosition.X < npcPosition.X)
            {
                animation.characterState = CharacterState.IdleLeft;
            }
        }

        private void ActivateLabel(IEntity player, IUI label)
        {
            Rectangle rectanglePlayer = player.rigidbody.GetRectangle;
            Rectangle bigRectanglePlayer = new Rectangle(rectanglePlayer.X - 1, rectanglePlayer.Y - 1, rectanglePlayer.Width + 2, rectanglePlayer.Height + 2);

            if (bigRectanglePlayer.Intersects(rigidbody.GetRectangle))
                label.isActive = true;
            else
                label.isActive = false;
        }
    }
}
