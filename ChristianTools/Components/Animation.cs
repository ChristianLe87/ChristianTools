namespace ChristianTools.Components
{
    public class Animation : IAnimation
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

        public Rectangle getImage => animation[characterState][frame];
        public string characterState { get; set; }
        public string atlasTexture { get; }
        private int frame;
        public Dictionary<string, Rectangle[]> animation { get; set; }

        public Animation(string atlasTexture)
        {
            this.atlasTexture = atlasTexture;

            int ts = ChristianGame.WK.TileSize;

            characterState = CharacterState.IdleDown;

            Rectangle Idle_Up = new Rectangle(0 * ts, 0 * ts, ts, ts);
            Rectangle Idel_Down = new Rectangle(0 * ts, 1 * ts, ts, ts);
            Rectangle Idl_Right = new Rectangle(0 * ts, 2 * ts, ts, ts);
            Rectangle Idle_Left = new Rectangle(0 * ts, 3 * ts, ts, ts);

            Rectangle moveRight_1 = new Rectangle(0 * ts, 6 * ts, ts, ts);
            Rectangle moveRight_2 = new Rectangle(1 * ts, 6 * ts, ts, ts);
            Rectangle moveRight_3 = new Rectangle(2 * ts, 6 * ts, ts, ts);
            Rectangle moveRight_4 = new Rectangle(3 * ts, 6 * ts, ts, ts);
            Rectangle moveRight_5 = new Rectangle(4 * ts, 6 * ts, ts, ts);

            Rectangle moveLeft_1 = new Rectangle(0 * ts, 7 * ts, ts, ts);
            Rectangle moveLeft_2 = new Rectangle(1 * ts, 7 * ts, ts, ts);
            Rectangle moveLeft_3 = new Rectangle(2 * ts, 7 * ts, ts, ts);
            Rectangle moveLeft_4 = new Rectangle(3 * ts, 7 * ts, ts, ts);
            Rectangle moveLeft_5 = new Rectangle(4 * ts, 7 * ts, ts, ts);

            Rectangle moveUp_1 = new Rectangle(0 * ts, 4 * ts, ts, ts);
            Rectangle moveUp_2 = new Rectangle(1 * ts, 4 * ts, ts, ts);
            Rectangle moveUp_3 = new Rectangle(2 * ts, 4 * ts, ts, ts);
            Rectangle moveUp_4 = new Rectangle(3 * ts, 4 * ts, ts, ts);
            Rectangle moveUp_5 = new Rectangle(4 * ts, 4 * ts, ts, ts);

            Rectangle moveDown_1 = new Rectangle(0 * ts, 5 * ts, ts, ts);
            Rectangle moveDown_2 = new Rectangle(1 * ts, 5 * ts, ts, ts);
            Rectangle moveDown_3 = new Rectangle(2 * ts, 5 * ts, ts, ts);
            Rectangle moveDown_4 = new Rectangle(3 * ts, 5 * ts, ts, ts);
            Rectangle moveDown_5 = new Rectangle(4 * ts, 5 * ts, ts, ts);

            this.animation = new Dictionary<string, Rectangle[]>()
            {
                { CharacterState.IdleUp, new[] { Idle_Up } },
                { CharacterState.IdleDown, new[] { Idel_Down } },
                { CharacterState.IdleRight, new[] { Idl_Right } },
                { CharacterState.IdleLeft, new[] { Idle_Left } },
                { CharacterState.MoveUp, new[] { moveUp_1, moveUp_2, moveUp_3, moveUp_4, moveUp_5 } },
                { CharacterState.MoveDown, new[] { moveDown_1, moveDown_2, moveDown_3, moveDown_4, moveDown_5 } },
                { CharacterState.MoveRight, new[] { moveRight_1, moveRight_2, moveRight_3, moveRight_4, moveRight_5 } },
                { CharacterState.MoveLeft, new[] { moveLeft_1, moveLeft_2, moveLeft_3, moveLeft_4, moveLeft_5 } }
            };
        }


        private int count = 0;

        public void Update()
        {
            count++;

            if (count >= animation[characterState].Length)
            {
                count = 0;

                if (frame >= (animation[characterState].Length - 1))
                    frame = 0;
                else
                    frame++;
            }
        }
    }
}