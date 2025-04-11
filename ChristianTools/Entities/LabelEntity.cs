namespace ChristianTools.Entities
{
    public class LabelEntity : IEntity
    {
        public IRigidbody rigidbody { get; set; }
        public IAnimation animation { get; }
        public bool isActive { get; set; }
        public string tag { get; }
        public Guid guid { get; }
        public DxCustomUpdateSystem dxCustomUpdateSystem { get; set; }
        public DxCustomDrawSystem dxCustomDrawSystem { get; set; }
        private SpriteFont spriteFont => ChristianGame.WK.spriteFonts[0];

        private Texture2D texture;
        private Rectangle rectangle;
        public string text { get; set; }

        public LabelEntity(string text, Rectangle rectangle, string tag = "", bool isActive = true)
        {
            this.text = text;
            this.rectangle = rectangle;
            this.rigidbody = null;//new ClassicRigidbody(rectangle);
            this.animation = new Animation(ChristianGame.WK.Atlas_Entities.First().Key);
            this.isActive = isActive;
            this.tag = tag;
            this.guid = Guid.NewGuid();
            this.texture = ChristianTools.Helpers.Texture.CreateColorTexture(Color.LightGray, this.rectangle.Width, rectangle.Height);
            //this.dxCustomUpdateSystem = (InputState lastInputState, InputState inputState) => Systems.Update.Entity.BaseUpdateSystem(lastInputState, inputState, this);
            this.dxCustomDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
        }

        private void DrawSystem(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture: texture, // atlas texture
                position: this.rectangle.Center.ToVector2(), //The drawing location on screen.
                sourceRectangle: rectangle, // "El pedazo que quiero sacar del atlasTexture" An optional region on the texture which will be rendered. If null - draws full texture.
                color: Color.White,
                rotation: (float)ChristianTools.Helpers.MyMath.DegreeToRadian(0), // A rotation of this sprite (always value radians)
                origin: new Vector2(this.rectangle.Width / 2, this.rectangle.Height / 2), // Center of the rotation. 0,0 by default.
                scale: new Vector2(1, 1), //A scaling of this sprite.
                effects: SpriteEffects.None, //Modificators for drawing. Can be combined.
                layerDepth: ((float)LayerDepth.Front / 10f)-0.1f // Evitar el "Z-fighting" (evitar pelear por prioridad)
            );


            spriteBatch.DrawString(
                spriteFont: spriteFont, // atlas texture
                text: text,
                position: this.rectangle.Center.ToVector2(), //The drawing location on screen.
                color: Color.White,
                rotation: (float)ChristianTools.Helpers.MyMath.DegreeToRadian(0), // A rotation of this sprite (always value radians)
                origin: new Vector2(this.rectangle.Width / 2, this.rectangle.Height / 2), // Center of the rotation. 0,0 by default.
                scale: new Vector2(1, 1), //A scaling of this sprite.
                effects: SpriteEffects.None, //Modificators for drawing. Can be combined.
                layerDepth: (float)LayerDepth.Front / 10f);
        }
    }
}