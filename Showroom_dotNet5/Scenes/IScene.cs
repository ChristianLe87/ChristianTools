using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Showroom_dotNet5
{
    public interface IScene
    {
        void Initialize();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
