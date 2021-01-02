using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame_UI
{
    public class Label
    {
        SpriteFont spriteFont;
        string text;
        Texture2D texture2D;
        Vector2 vector2;

        public Label(Vector2 position, SpriteFont spriteFont, string text, Texture2D texture = null)
        {
            this.vector2 = position;
            this.spriteFont = spriteFont;
            this.text = text;
            this.texture2D = texture;
        }

        public void Update(string text = null)
        {
            if (text != null)
                this.text = text;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(texture2D != null)
                spriteBatch.Draw(texture2D, new Rectangle((int)vector2.X, (int)vector2.Y, texture2D.Width, texture2D.Height), Color.White);

            spriteBatch.DrawString(spriteFont, text, vector2, Color.White);
        }
    }
}
