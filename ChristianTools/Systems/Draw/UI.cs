using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Systems
{
    public partial class Systems
    {
        public partial class Draw
        {
            public static void UI(SpriteBatch spriteBatch, IUI ui)
            {
                if (ui.isActive == false)
                    return;

                if (ui.dxDrawSystem != null)
                {
                    ui.dxDrawSystem(spriteBatch);
                }
                else
                {
                    spriteBatch.Draw(ui.texture, ui.rectangle, Color.White);
                }
            }
        }
    }
}