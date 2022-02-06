using ChristianTools.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Systems
{
    public partial class Systems
    {
        public partial class Draw
        {
            public static void Light(SpriteBatch spriteBatch, Light light)
            {
                if(light.texture != null)
                    spriteBatch.Draw(light.texture, light.centerPosition.ToVector2(), Color.White);
            }
        }
    }

}