namespace ChristianTools.Components
{
    public class Animation
    {
        public Rectangle getImage => animation[characterState][frame];
        public CharacterState characterState { get; set; }
        private int frame;
        private Dictionary<CharacterState, Rectangle[]> animation { get; set; }

        public Animation(Rectangle imageFromAtlas)
        {
            characterState = CharacterState.IdleDown;

            Rectangle Idle_Up = new Rectangle(0 * 16, 0 * 16, 16, 16);
            Rectangle Idel_Down = new Rectangle(0 * 16, 1 * 16, 16, 16);
            Rectangle Idl_Right = new Rectangle(0 * 16, 2 * 16, 16, 16);
            Rectangle Idle_Left = new Rectangle(0 * 16, 3 * 16, 16, 16);

            Rectangle moveRight_1 = new Rectangle(0 * 16, 2 * 16, 16, 16);
            Rectangle moveRight_2 = new Rectangle(1 * 16, 2 * 16, 16, 16);
            Rectangle moveRight_3 = new Rectangle(2 * 16, 2 * 16, 16, 16);
            Rectangle moveRight_4 = new Rectangle(3 * 16, 2 * 16, 16, 16);
            Rectangle moveRight_5 = new Rectangle(4 * 16, 2 * 16, 16, 16);

            Rectangle moveLeft_1 = new Rectangle(0 * 16, 3 * 16, 16, 16);
            Rectangle moveLeft_2 = new Rectangle(1 * 16, 3 * 16, 16, 16);
            Rectangle moveLeft_3 = new Rectangle(2 * 16, 3 * 16, 16, 16);
            Rectangle moveLeft_4 = new Rectangle(3 * 16, 3 * 16, 16, 16);
            Rectangle moveLeft_5 = new Rectangle(4 * 16, 3 * 16, 16, 16);

            Rectangle moveUp_1 = new Rectangle(0 * 16, 0 * 16, 16, 16);
            Rectangle moveUp_2 = new Rectangle(1 * 16, 0 * 16, 16, 16);
            Rectangle moveUp_3 = new Rectangle(2 * 16, 0 * 16, 16, 16);
            Rectangle moveUp_4 = new Rectangle(3 * 16, 0 * 16, 16, 16);
            Rectangle moveUp_5 = new Rectangle(4 * 16, 0 * 16, 16, 16);

            Rectangle moveDown_1 = new Rectangle(0 * 16, 1 * 16, 16, 16);
            Rectangle moveDown_2 = new Rectangle(1 * 16, 1 * 16, 16, 16);
            Rectangle moveDown_3 = new Rectangle(2 * 16, 1 * 16, 16, 16);
            Rectangle moveDown_4 = new Rectangle(3 * 16, 1 * 16, 16, 16);
            Rectangle moveDown_5 = new Rectangle(4 * 16, 1 * 16, 16, 16);

            this.animation = new Dictionary<CharacterState, Rectangle[]>()
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