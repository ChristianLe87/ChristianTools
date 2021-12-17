using ChristianTools.Helpers;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Systems
{
    public partial class Systems
    {
        public partial class Draw
        {
            public static void UI(SpriteBatch spriteBatch, IUI ui)
            {
                ui.Draw(spriteBatch);
            }
        }
    }
}