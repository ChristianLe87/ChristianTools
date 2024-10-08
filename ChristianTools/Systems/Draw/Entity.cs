namespace ChristianTools.Systems.Draw
{
    public class Entity
    {
        public static void Draw(SpriteBatch spriteBatch, IEntity entity)
        {
            if (entity.isActive != true)
                return;

            spriteBatch.Draw(
                texture: ChristianGame.atlasEntities, // atlas texture 
                position: entity.rigidbody.centerPosition, //The drawing location on screen.
                sourceRectangle: entity.animation.getImage, // "El pedazo que quiero sacar del atlasTexture" An optional region on the texture which will be rendered. If null - draws full texture.
                color: Color.White,
                rotation: (float)ChristianTools.Helpers.MyMath.DegreeToRadian(0), // A rotation of this sprite (always value radians)
                origin: new Vector2(entity.rigidbody.size.X / 2, entity.rigidbody.size.Y / 2), // Center of the rotation. 0,0 by default.
                scale: new Vector2(1, 1), //A scaling of this sprite. 
                effects: SpriteEffects.None, //Modificators for drawing. Can be combined.
                layerDepth: (float)LayerDepth.Main / 10f
            );
        }
    }
}