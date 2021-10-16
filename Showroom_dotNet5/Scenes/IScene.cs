using Microsoft.Xna.Framework.Graphics;
using zTools;

namespace Showroom_dotNet5
{
    public interface IScene
    {
        public Camera camera { get; }

        void Initialize();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
