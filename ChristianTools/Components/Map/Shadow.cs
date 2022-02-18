using System;
using System.Collections.Generic;
using System.Linq;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Components
{
    public class Shadow : IShadow
    {
        public static Color Shadow_0 { get; } = new Color(Color.Black, byte.MinValue);
        public static Color Shadow_10 { get; } = new Color(Color.Black, byte.MaxValue / 10);
        public static Color Shadow_25 { get; } = new Color(Color.Black, byte.MaxValue * 1 / 4);
        public static Color Shadow_50 { get; } = new Color(Color.Black, byte.MaxValue * 1 / 2);
        public static Color Shadow_75 { get; } = new Color(Color.Black, byte.MaxValue * 3 / 4);
        public static Color Shadow_100 { get; } = new Color(Color.Black, byte.MaxValue);

        public Rigidbody rigidbody { get; }
        public Texture2D texture { get; private set; }

        public string tag { get; }
        public bool isActive { get; set; }

        public DxUpdateSystem dxUpdateSystem { get; }
        public DxDrawSystem dxDrawSystem { get; }

        public Color shadowColor { get; private set; }

        public Shadow(Rectangle rectangle, bool isActive = true, string tag = "")
        {
            int AssetSize_x_ScaleFactor = ChristianGame.Default.AssetSize * ChristianGame.Default.ScaleFactor;
            Texture2D transparent = Tools.Tools.Texture.CreateColorTexture(Color.Black, AssetSize_x_ScaleFactor, AssetSize_x_ScaleFactor);

            this.texture = transparent;
            this.rigidbody = new Rigidbody(
                rectangle: rectangle
            );
            this.tag = tag;
            this.isActive = isActive;

            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem();
        }



        private void UpdateSystem()
        {

            List<ILight> lights = ChristianGame.GetScene.map?.lights;

            if (lights == null)
            {
                shadowColor = Shadow.Shadow_0;
                return;
            }


            if (lights.Count == 0)
            {
                shadowColor = Shadow.Shadow_100;
                return;
            }


            int AssetSize_x_ScaleFactor = ChristianGame.Default.AssetSize * ChristianGame.Default.ScaleFactor;


            int nearDistance = lights
                .Where(x => x.isActive == true)
                .Select(x =>
                {
                    return (int)Vector2.Distance(x.rigidbody.centerPosition, rigidbody.centerPosition);
                })
                .Min();



            if (nearDistance > 6 * AssetSize_x_ScaleFactor)
            {
                shadowColor = Shadow.Shadow_100;
            }
            else if (nearDistance > 5 * AssetSize_x_ScaleFactor)
            {
                shadowColor = Shadow.Shadow_75;
            }
            else if (nearDistance > 4 * AssetSize_x_ScaleFactor)
            {
                shadowColor = Shadow.Shadow_50;
            }
            else if (nearDistance > 3 * AssetSize_x_ScaleFactor)
            {
                shadowColor = Shadow.Shadow_25;
            }
            else if (nearDistance > 2 * AssetSize_x_ScaleFactor)
            {
                shadowColor = Shadow.Shadow_10;
            }
            else
            {
                shadowColor = Shadow.Shadow_0;
            }

        }
    }
}