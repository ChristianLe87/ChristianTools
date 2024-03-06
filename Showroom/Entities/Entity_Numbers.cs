using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Prefabs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = System.Numerics.Vector2;

namespace Showroom
{
    public class Entity_Numbers : BaseEntity
    {
        public Entity_Numbers(Rectangle rectangle, Rectangle imageFromAtlas, string tag = "", Vector2 force = new Vector2(), bool isActive = true) : base(rectangle, imageFromAtlas, tag, force, isActive)
        {
        }
    }
}