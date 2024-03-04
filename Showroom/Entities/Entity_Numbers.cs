using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Prefabs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Showroom
{
    public class Entity_Numbers : BaseEntity
    {
        public Entity_Numbers(Rectangle rigidbodyRectangle, Rectangle animationRectangle, string tag = "", bool isActive = true) : base(rigidbodyRectangle, animationRectangle, tag, isActive)
        {
        }
    }
}