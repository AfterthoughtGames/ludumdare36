using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameyMickGameFace.Physics
{
    public class PhysicsManager
    {
        public void ResolveCollision(Body a, Body b)
        {
            //find the collision normal (aka the direction of the collision
            Vector2 collisionNormal = (b.PhysicsBody.Location - a.PhysicsBody.Location).ToVector2();

            // Calculate relative velocity
            Vector2 relativeVelocity = b.Velocity - a.Velocity;

            // Calculate relative velocity in terms of the normal direction
            float velAlongNormal = Vector2.Dot(relativeVelocity, collisionNormal);

            // Do not resolve if velocities are separating
            if (velAlongNormal > 0)
            {
                return;
            }

            // Calculate restitution
            float restitution = Math.Min(a.Restitution, b.Restitution);

            // Calculate impulse scalar
            float impulseScalar = -(1 + restitution) * velAlongNormal;
            impulseScalar /= a.InverseMass + b.InverseMass;

            // Apply impulse
            Vector2 impulse = impulseScalar * collisionNormal;
            a.Velocity -= a.InverseMass * impulse;
            b.Velocity += b.InverseMass * impulse;
        }
    }
}
