using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Systems.Draw.Map
{
    public class Tile
    {
        public static void DrawSystem(SpriteBatch spriteBatch, Components.Tile tile)
        {
            Rectangle imageFromAtlas = new Rectangle();
            
            
            // TODO: automatize this mess
            switch (tile.image)
            {
                case 7:
                    imageFromAtlas = new Rectangle(16, 16, 16, 16);
                    break;
                case 8:
                    imageFromAtlas = new Rectangle(32, 16, 16, 16);
                    break;
                case 9:
                    imageFromAtlas = new Rectangle(48, 16, 16, 16);
                    break;
                
                case 12:
                    imageFromAtlas = new Rectangle(16, 32, 16, 16);
                    break;
                case 13:
                    imageFromAtlas = new Rectangle(32, 32, 16, 16);
                    break;
                case 14:
                    imageFromAtlas = new Rectangle(48, 32, 16, 16);
                    break;
                
                case 17:
                    imageFromAtlas = new Rectangle(16, 48, 16, 16);
                    break;
                case 18:
                    imageFromAtlas = new Rectangle(32, 48, 16, 16);
                    break;
                case 19:
                    imageFromAtlas = new Rectangle(48, 48, 16, 16);
                    break;
                
                default:
                    imageFromAtlas = new Rectangle();
                    break;
            }
            
            // new
            spriteBatch.Draw(
                texture: ChristianGame.atlasEntities, // atlas texture 
                position: tile.worldRectangle.Center.ToVector2(), //The drawing location on screen.
                sourceRectangle: imageFromAtlas, // "El pedazo que quiero sacar del atlasTexture" An optional region on the texture which will be rendered. If null - draws full texture.
                color: Color.White,
                rotation: (float)ChristianTools.Helpers.MyMath.DegreeToRadian(0), // A rotation of this sprite (always value radians)
                origin: new Vector2(imageFromAtlas.Width / 2, imageFromAtlas.Height / 2), // Center of the rotation. 0,0 by default.
                scale: new Vector2(1, 1), //A scaling of this sprite. 
                effects: SpriteEffects.None, //Modificators for drawing. Can be combined.
                layerDepth: (int)tile.layerId/10f // 1f//1 / 10f
            );
        }
    }
}