using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameyMickGameFace.Physics
{
    public enum BodyDetectionType
    {
        Left, Right, Top, Bottom
    }

    public class Body
    {
        public Vector2 parentOffset;
        public Vector2 Position;
        public int width;
        public int height;
        public Rectangle MotionPhysicsBody;
        public Vector2 Velocity;
        public float Restitution;
        public int Mass;
        public float InverseMass;
        public float LinearDampening;
        public bool reactsToCollision = true;
        public BodyDetectionType bodyType;

        public object objRef;

        public Body(Point position, int width, int height, float restitution, int mass, float linearDampening, object objRef)
        {
            this.width = width;
            this.height = height;

            Position = position.ToVector2();

            LinearDampening = linearDampening;

            MotionPhysicsBody = new Rectangle(position.X, position.Y, width, height);
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
                InverseMass = 1 / (float)Mass;
            }

            this.objRef = objRef;
        }

        public void AddVelocity(Vector2 vector)
        {
            Velocity += vector;
        }

        public void Update(GameTime gameTime)
        {
            Position += Velocity * (gameTime.ElapsedGameTime.Milliseconds / 1000f);

            if (LinearDampening != 1)
            {
                Velocity *= LinearDampening * (gameTime.ElapsedGameTime.Milliseconds / 1000f);
            }

            UpdatePosition();
        }

        public void UpdatePosition()
        {
            MotionPhysicsBody = new Rectangle((int)Position.X, (int)Position.Y, width, height);
        }
    }
}
