using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameyMickGameFace.Physics
{
    public class Body
    {
        public Rectangle PhysicsBody;
        public Vector2 Velocity;
        public float Restitution;
        public int Mass;
        public float InverseMass;

        public Body(Point position, int width, int height, float restitution, int mass)
        {
            PhysicsBody = new Rectangle(position.X, position.Y, width, height);
            Velocity = new Vector2(0, 0);  //init to no veleocity
            Restitution = restitution;
            Mass = mass;

            //make sure that if no mass is set the thing cannot be moved
            if (Mass == 0)
            {
                InverseMass = 0;
            }
            else
            {
                InverseMass = 1 / Mass;
            }
        }
    }
}
