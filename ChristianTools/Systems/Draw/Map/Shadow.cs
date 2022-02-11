using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Systems
{
    public partial class Systems
    {
        public partial class Draw
        {
            public static void Shadow(SpriteBatch spriteBatch, IShadow shadow)
            {
                if (shadow.isActive != true)
                    return;


                spriteBatch.Draw(shadow.texture, shadow.rigidbody.rectangle, shadow.shadowColor);
            }
        }
    }
}