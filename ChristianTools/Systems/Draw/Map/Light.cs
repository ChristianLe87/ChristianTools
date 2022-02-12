using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Systems
{
    public partial class Systems
    {
        public partial class Draw
        {
            public static void Light(SpriteBatch spriteBatch, ILight light)
            {
                if (light.isActive != true)
                    return;

                if (light.dxDrawSystem != null)
                    light.dxDrawSystem(spriteBatch);

                if(light.texture != null)
                    spriteBatch.Draw(light.texture, light.rigidbody.rectangle, Color.White);
            }
        }
    }
}