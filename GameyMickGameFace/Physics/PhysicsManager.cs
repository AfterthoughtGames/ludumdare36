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

        private void PositionalCorrection(Body bodyA, Body bodyB, Vector2 collisionNormal)
        {
            float Penetration = GetPenetration(bodyA, bodyB, collisionNormal);
            float percent = .8f; //probably between 20-80%
            float slopAllowed = .01f; //between .01 and .1
            Vector2 Correction = Math.Max(Penetration - slopAllowed, 0) / (bodyA.InverseMass + bodyB.InverseMass) * percent * collisionNormal;
            bodyA.PhysicsBody.Location -= (bodyA.InverseMass * Correction).ToPoint();
            bodyB.PhysicsBody.Location += (bodyB.InverseMass * Correction).ToPoint();
        }

        private float GetPenetration(Body bodyA, Body bodyB, Vector2 collisionNormal)
        {
            float penetration = 0;
            // Vector from A to B
            Vector2 n = (bodyB.PhysicsBody.Location - bodyA.PhysicsBody.Location).ToVector2();

            Rectangle abox = bodyA.PhysicsBody;
            Rectangle bbox = bodyB.PhysicsBody;

            // Calculate half extents along x axis for each object
            float a_extent = (abox.Right - abox.Left) / 2;
            float b_extent = (bbox.Right - bbox.Left) / 2;

            // Calculate overlap on x axis
            float x_overlap = a_extent + b_extent - Math.Abs(collisionNormal.X);

            // SAT test on x axis
            if (x_overlap > 0)
            {
                // Calculate half extents along x axis for each object
                a_extent = (abox.Top - abox.Bottom) / 2;
                b_extent = (bbox.Top - bbox.Bottom) / 2;

                // Calculate overlap on y axis
                float y_overlap = a_extent + b_extent - Math.Abs(collisionNormal.Y);

                // SAT test on y axis
                if (y_overlap > 0)
                {
                    // Find out which axis is axis of least penetration
                    if (x_overlap > y_overlap)
                    {
                        penetration = x_overlap;
                    }
                    else
                    {
                        penetration = y_overlap;
                    }
                }
            }

            return penetration;
        }
    }
}
