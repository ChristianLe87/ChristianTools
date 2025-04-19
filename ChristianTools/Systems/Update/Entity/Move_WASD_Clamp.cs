
namespace ChristianTools.Systems.Update
{
    public partial class Entity
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
        
        public static void Move_WASD_Clamp(InputState lastInputState, InputState inputState, IEntity entity)
        {
            int y = entity.rigidbody.GetRectangle.Y % ChristianGame.WK.TileSize;
            int x = entity.rigidbody.GetRectangle.X % ChristianGame.WK.TileSize;

            // First move
            if (inputState.Down && x == 0)
            {
                entity.animation.characterState = CharacterState.MoveDown;
                entity.rigidbody.Move_Y(1);
            }
            else if (inputState.Up && x == 0)
            {
                entity.animation.characterState = CharacterState.MoveUp;
                entity.rigidbody.Move_Y(-1);
            }
            else if (inputState.Right && y == 0)
            {
                entity.animation.characterState = CharacterState.MoveRight;
                entity.rigidbody.Move_X(1);
            }
            else if (inputState.Left && y == 0)
            {
                entity.animation.characterState = CharacterState.MoveLeft;
                entity.rigidbody.Move_X(-1);
            }


            // Auto move and prevent move when not needed
            if (y != 0 && entity.animation.characterState == CharacterState.MoveDown)
            {
                if (!inputState.Down)
                    entity.rigidbody.Move_Y(1);
            }
            else if (y != 0 && entity.animation.characterState == CharacterState.MoveUp)
            {
                if (!inputState.Up)
                    entity.rigidbody.Move_Y(-1);
            }
            else if (x != 0 && entity.animation.characterState == CharacterState.MoveRight)
            {
                if (!inputState.Right)
                    entity.rigidbody.Move_X(1);
            }
            else if (x != 0 && entity.animation.characterState == CharacterState.MoveLeft)
            {
                if (!inputState.Left)
                    entity.rigidbody.Move_X(-1);
            }


            // Set Idle state
            if (x == 0 && y == 0)
            {
                string lastCharacterState = entity.animation.characterState;

                if (lastCharacterState == CharacterState.MoveDown)
                    entity.animation.characterState = CharacterState.IdleDown;
                else if (lastCharacterState == CharacterState.MoveUp)
                    entity.animation.characterState = CharacterState.IdleUp;
                else if (lastCharacterState == CharacterState.MoveLeft)
                    entity.animation.characterState = CharacterState.IdleLeft;
                else if (lastCharacterState == CharacterState.MoveRight)
                    entity.animation.characterState = CharacterState.IdleRight;
            }
        }
    }
}
