using System;
using Microsoft.Xna.Framework.Graphics;

namespace My_EasyTests
{
    public interface IScene
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
