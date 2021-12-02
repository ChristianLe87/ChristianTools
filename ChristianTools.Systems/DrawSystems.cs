using System;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Systems
{
    public class Systems
    {
        public static void DrawScene(SpriteBatch spriteBatch, IScene scene)
        {
            if (scene.UIs != null)
                foreach (var ui in scene.UIs)
                    ui.Draw(spriteBatch);
        }

        public static void DrawWithRotation(SpriteBatch spriteBatch, int canvasWidth, int canvasHeight, IEntity entity)
        {
            Texture2D texture2D = entity.animation.GetTexture();
            float rotationAngleInRadians = (float)Tools.Tools.MyMath.DegreeToRadian(entity.rigidbody.rotationDegree);
            spriteBatch.Draw(
               texture: texture2D,
               destinationRectangle: new Rectangle(canvasWidth / 2, canvasHeight / 2, texture2D.Width, texture2D.Height),
               sourceRectangle: null,
               color: Color.White,
               rotation: rotationAngleInRadians,
               origin: new Vector2(texture2D.Width / 2, texture2D.Height / 2),
               effects: SpriteEffects.None,
               layerDepth: 0f
           );
        }
    }
}