using System;
using Microsoft.Xna.Framework;

namespace zPhysics
{
    public class Physics
    {
        float speed; // m/s
        Gravity gravity;

        public Physics()
        {
            this.speed = 0f;
            this.gravity = new Gravity();
        }

        public void Update(ref Point centerPoint)
        {
            gravity.Update(ref centerPoint);
        }
    }
}
