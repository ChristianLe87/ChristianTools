
namespace ChristianTools.Components
{
    public class AnimationClip
    {
        public string name;
        public Rectangle[] imageFrames;

        public AnimationClip(string name, Rectangle fromAtlas, int frames = 1)
        {
            this.name = name;
            this.imageFrames = ChristianTools.Helpers.MyRectangle.SliceRectangle(fromAtlas, frames);
        }
    }

    public class Animation : IAnimation
    {
        public Rectangle getImage => animationClips[characterState].imageFrames[frame];
        public string characterState { get; set; }
        public string atlasTexture { get; }
        public Color color { get; set; }
        private int frame;
        public Dictionary<string, AnimationClip> animationClips { get; set; }


        public Animation(Color color)
        {
            int ts = ChristianGame.WK.TileSize;

            this.color = color;
            this.characterState = "";
            this.animationClips = new Dictionary<string, AnimationClip>()
            {
                { "", new AnimationClip("", new Rectangle(0, 0, ts, ts)) },
            };
        }

        public Animation(string atlasTexture)
        {
            this.atlasTexture = atlasTexture;
            this.characterState = "";
            this.animationClips = new Dictionary<string, AnimationClip>()
            {
                { "", new AnimationClip("", ChristianGame.WK.Atlas_Entities[atlasTexture].Bounds) },
            };
        }


        public Animation(string atlasTexture, AnimationClip[] animationClips)
        {
            this.atlasTexture = atlasTexture;
            this.characterState = animationClips.First().name;
            this.animationClips = animationClips.ToDictionary(x => x.name, x => x);
        }


        private int count = 0;
        public void Update()
        {
            count++;

            if (count >= animationClips[characterState].imageFrames.Length)
            {
                count = 0;

                if (frame >= (animationClips[characterState].imageFrames.Length - 1))
                    frame = 0;
                else
                    frame++;
            }
        }
    }
}