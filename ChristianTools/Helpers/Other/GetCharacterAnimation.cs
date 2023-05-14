using System.Collections.Generic;
using System.Linq;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Tools
{
    public partial class Tools
    {
        public partial class Other
        {
            public static Dictionary<CharacterState, Texture2D[]> GetCharacterAnimation(Texture2D atlasAnimation, (CharacterState, int)[] characterState_tiles, bool flipHorizontal = false)
            {
                int maxTiles = characterState_tiles.Select(x => x.Item2).Max();
                int elementWidth = atlasAnimation.Width / maxTiles;
                int elementHeight = atlasAnimation.Height / characterState_tiles.Length;

                Dictionary<CharacterState, Texture2D[]> result = new Dictionary<CharacterState, Texture2D[]>();

                for (int i = 0; i < characterState_tiles.Length; i++)
                {
                    Rectangle extractRectangle = new Rectangle(0, i * elementHeight, elementWidth * characterState_tiles[i].Item2, elementHeight);
                    Texture2D texture = Tools.Texture.CropTexture(atlasAnimation, extractRectangle);
                    Texture2D[] textures = Tools.Texture.SliceHorizontalTexture(texture, (characterState_tiles[i].Item2));


                    if(flipHorizontal == true)
                    {
                        for (int j = 0; j < textures.Length; j++)
                        {
                            textures[j] = Tools.Texture.FlipHorizontal(textures[j]);
                        }
                    }

                    result.Add(characterState_tiles[i].Item1, textures);
                }


                return result;
            }
        }
    }
}