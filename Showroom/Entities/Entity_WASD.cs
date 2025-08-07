namespace Showroom
{
    public class Entity_WASD : BaseEntity
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
            public static string _Null => "Null";
        }

        public Entity_WASD(Rectangle rectangle, string tag = "", bool isActive = true) : base(rectangle, "AtlasEntities_PNG",tag, isActive)
        {
            int ts = ChristianGame.WK.TileSize;

            var bla = ChristianGame.WK;

            AnimationClip[] animationClips = new[]
            {
                new AnimationClip(CharacterState.IdleUp, new Rectangle(0 * ts, 0 * ts, ts, ts)),
                new AnimationClip(CharacterState.IdleDown, new Rectangle(0 * ts, 1 * ts, ts, ts)),
                new AnimationClip(CharacterState.IdleRight, new Rectangle(0 * ts, 2 * ts, ts, ts)),
                new AnimationClip(CharacterState.IdleLeft, new Rectangle(0 * ts, 3 * ts, ts, ts)),

                new AnimationClip(CharacterState.MoveRight, new Rectangle(0 * ts, 6 * ts, 5 * ts, ts), 5),
                new AnimationClip(CharacterState.MoveLeft, new Rectangle(0 * ts, 7 * ts, 5 * ts, ts), 5),
                new AnimationClip(CharacterState.MoveUp, new Rectangle(0 * ts, 4 * ts, 5 * ts, ts), 5),
                new AnimationClip(CharacterState.MoveDown, new Rectangle(0 * ts, 5 * ts, 5 * ts, ts), 5)
            };

            this.animation = new Animation("AtlasEntities_PNG", animationClips);
            this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => ChristianTools.Systems.Update.Entity.Move_WASD_Clamp(lastInputState, inputState, this);
        }
    }
}