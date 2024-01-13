using Microsoft.Xna.Framework;

namespace ChristianTools.Components
{
    public class Animation
    {
        public Rectangle imageFromAtlas { get; private set; }

        public Animation(Rectangle imageFromAtlas)
        {
            this.imageFromAtlas = imageFromAtlas;
        }

        public void Update()
        {
        }
    }
}