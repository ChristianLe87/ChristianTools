using System;
using System.IO;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Tools
{
    public partial class Tools
    {
        public partial class Other
        {
            /// <summary>
            /// Get Effect from a MGFX
            /// </summary>
            /// <param name="mgfxName">File name of the MGFX -> without the extension (.mgfx)</param>
            public static Effect GetMGFX(string mgfxName)
            {
                // === Implementation ===
                {
                    GraphicsDevice graphicsDevice = ChristianGame.graphicsDevice;
                    ContentManager contentManager = ChristianGame.contentManager;

                    string absolutePath = Path.Combine(contentManager.RootDirectory, $"{mgfxName}.mgfx");
                    byte[] effectCode = GetBinaryFile(absolutePath);

                    Effect effect = new Effect(graphicsDevice, effectCode);

                    return effect;
                }

                // === Helper ===
                byte[] GetBinaryFile(string path)
                {
                    byte[] bytes;
                    using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        bytes = new byte[file.Length];
                        file.Read(bytes, 0, (int)file.Length);
                    }
                    return bytes;
                }
            }
        }
    }
}