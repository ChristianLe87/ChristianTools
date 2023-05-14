using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Tools
{
    public partial class Tools
    {
        public partial class Texture
        {
            public static Texture2D FlipHorizontal(Texture2D originalTexture)
            {
                GraphicsDevice graphicsDevice = ChristianGame.graphicsDevice;

                Color[] original_Colors = new Color[originalTexture.Width * originalTexture.Height];
                originalTexture.GetData(0, new Rectangle(0, 0, originalTexture.Width, originalTexture.Height), original_Colors, 0, (originalTexture.Width * originalTexture.Height));
                Color[,] original_MultidimentionalColors = Tools.Other.ToMultidimentional<Color>(original_Colors, originalTexture.Width, originalTexture.Height);

                Color[,] result_MultidimentionalColors = new Color[originalTexture.Height, originalTexture.Width];

                for (int row = 0; row < original_MultidimentionalColors.GetLength(0); row++)
                {
                    Color[] original_RowColors = Tools.Other.GetRow(original_MultidimentionalColors, row);
                    original_RowColors = original_RowColors.Reverse().ToArray();

                    for (int element = 0; element < original_RowColors.Length; element++)
                    {
                        result_MultidimentionalColors[row, element] = original_RowColors[element];
                    }
                }

                Color[] result_Colors = Tools.Other.FlattenArray<Color>(result_MultidimentionalColors);

                Texture2D result = new Texture2D(graphicsDevice, originalTexture.Width, originalTexture.Height, false, SurfaceFormat.Color);
                result.SetData(result_Colors);

                return result;
            }
        }
    }
}