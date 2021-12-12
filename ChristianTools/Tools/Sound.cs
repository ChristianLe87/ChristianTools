using System.IO;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Tools
{
    public partial class Tools
    {
        public class Sound
        {
            /// <summary>
            /// Get SoundEffect from WAV file
            /// </summary>
            /// <param name="soundName">File name of the WAV -> without the extension</param>
            /// <returns></returns>
            public static SoundEffect GetSoundEffect(GraphicsDevice graphicsDevice, ContentManager contentManager, string soundName)
            {
                string absolutePath = Path.Combine(contentManager.RootDirectory, $"{soundName}.wav");
                SoundEffect result = SoundEffect.FromFile(absolutePath);
                return result;
            }
        }
    }
}