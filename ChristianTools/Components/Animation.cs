namespace ChristianTools.Components
{
    public class Animation
    {
        public Rectangle getImage => animation[characterState][frame];
        public CharacterState characterState { get;  set; }
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
                { CharacterState.IdleUp, new[] { Idle_Up, Idle_Up, Idle_Up, Idle_Up, Idle_Up } },
                { CharacterState.IdleDown, new[] { Idel_Down, Idel_Down, Idel_Down, Idel_Down, Idel_Down } },
                { CharacterState.IdleRight, new[] { Idl_Right, Idl_Right, Idl_Right, Idl_Right, Idl_Right } },
                { CharacterState.IdleLeft, new[] { Idle_Left, Idle_Left, Idle_Left, Idle_Left, Idle_Left } },
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
            if (count > 4)
            {
                count = 0;
                frame++;

                if (frame >= (animation[characterState].Length-1))
                {
                    frame = 0;
                }
            }
        }
        

        /*
        public Animation(Rectangle imageFromAtlasUp, Rectangle imageFromAtlasDown, Rectangle imageFromAtlasRight, Rectangle imageFromAtlasLeft)//Dictionary<Direction, Rectangle[]> imageFromAtlas)
        {
            this.animation = new Dictionary<CharacterState, Rectangle[]>()
            {

                { CharacterState.IdleUp, new Rectangle[imageFromAtlasUp.Width / 16] },
                { CharacterState.IdleDown, new Rectangle[imageFromAtlasDown.Width / 16] },
                { CharacterState.IdleRight, new Rectangle[imageFromAtlasRight.Width / 16] },
                { CharacterState.IdleLeft, new Rectangle[imageFromAtlasLeft.Width / 16] },
                { CharacterState.MoveUp, new Rectangle[imageFromAtlasUp.Width / 16] },
                { CharacterState.MoveDown, new Rectangle[imageFromAtlasDown.Width / 16] },
                { CharacterState.MoveRight, new Rectangle[imageFromAtlasRight.Width / 16] },
                { CharacterState.MoveLeft, new Rectangle[imageFromAtlasLeft.Width / 16] }
            };


            animation[Direction.Up] = blabla();
        }

        public Rectangle[] blabla()
        {

            for (int i = 0; i < animation.Count; i++)
            {
                animation[i * 16] = new Rectangle(imageFromAtlas.X + (16 * i), imageFromAtlas.Y, 16, 16);
            }
        }





        public static Dictionary<CharacterState, Texture2D[]> GetCharacterAnimation(Texture2D atlasAnimation, (CharacterState, int)[] characterState_tiles, bool flipHorizontal = false)
        {
            int maxTiles = characterState_tiles.Select(x => x.Item2).Max();
            int elementWidth = atlasAnimation.Width / maxTiles;
            int elementHeight = atlasAnimation.Height / characterState_tiles.Length;

            Dictionary<CharacterState, Texture2D[]> result = new Dictionary<CharacterState, Texture2D[]>();

            for (int i = 0; i < characterState_tiles.Length; i++)
            {
                Rectangle extractRectangle = new Rectangle(0, i * elementHeight, elementWidth * characterState_tiles[i].Item2, elementHeight);
                Texture2D texture = ChristianTools.Helpers.Texture.CropTexture(atlasAnimation, extractRectangle);
                Texture2D[] textures = ChristianTools.Helpers.Texture.SliceHorizontalTexture(texture, (characterState_tiles[i].Item2));


                if (flipHorizontal == true)
                {
                    for (int j = 0; j < textures.Length; j++)
                    {
                        textures[j] = ChristianTools.Helpers.Texture.FlipHorizontal(textures[j]);
                    }
                }

                result.Add(characterState_tiles[i].Item1, textures);
            }


            return result;
        }
       */
    }
}