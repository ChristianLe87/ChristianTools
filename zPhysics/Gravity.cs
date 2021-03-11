using System;
using Microsoft.Xna.Framework;

namespace zPhysics
{
    public class Gravity
    {
        public Gravity()
        {
        }

        public void Update(ref Point centerPoint)
        {
            centerPoint.Y++;
        }
    }
}
