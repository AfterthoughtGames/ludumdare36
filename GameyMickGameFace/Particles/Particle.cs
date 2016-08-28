using GameyMickGameFace.GameObjects;
using GameyMickGameFace.Media;
using GameyMickGameFace.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameyMickGameFace.Particles
{
    public class Particle
    {
        Body PhysicsBody;
        Body DetectionBody;
        float scale;
        bool Dead = false;
        Texture2D texture;
        bool splat = false;
        Random rand = new Random();
        int life = 2000;


        public Particle(Point position, float scale, Texture2D texture, Vector2 velocity)
        {
            //Random rand = new Random();
            PhysicsBody = new Body(position, 10, 10, 0, 100, 1f, this);
            PhysicsBody.reactsToCollision = false;
            PhysicsBody.Velocity = velocity;
            this.scale = scale;
            this.texture = texture;

            DetectionBody = new Body(new Point(0, 0), (int)(10 * scale), (int)(10 * scale), (int)(0 * scale), (int)(5 * scale), 1f, this);
            DetectionBody.parentOffset = new Vector2(0, 0) * scale;
            DetectionBody.bodyType = BodyDetectionType.Left;
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            int colorValue = (int)(255 * life / 1000f);
            batch.Draw(texture, PhysicsBody.Position, null, new Color(colorValue,colorValue,colorValue,colorValue), 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
        }

        public void Update(GameTime gameTime, PhysicsManager manager)
        {
            PhysicsBody.Update(gameTime);

            PhysicsBody.AddVelocity(new Vector2(0, 10)); //gravity

            UpdateBodyPhysicsDetection();
            collisionDetection(manager, gameTime);


        }

        public void UpdateBodyPhysicsDetection()
        {
            DetectionBody.MotionPhysicsBody = new Rectangle((int)(PhysicsBody.Position.X + DetectionBody.parentOffset.X),
                (int)(PhysicsBody.Position.Y + PhysicsBody.parentOffset.Y), DetectionBody.width, DetectionBody.height);
        }

        private void collisionDetection(PhysicsManager manager, GameTime gameTime)
        {
            //detect collisions
        Body body = DetectionBody;
            foreach (Body body2 in manager.GetBodies())
            {
                if (body != body2 && body.MotionPhysicsBody.Intersects(body2.MotionPhysicsBody)
                    && (body.reactsToCollision && body2.reactsToCollision))
                {
                    PhysicsBody.Velocity *= 0; //kill all velocity
                    
                    
                    if (!splat)
                    {
                        Dead = true;
                        Level.Particles.Remove(this);
                        splat = true;
                        for (int i = 0; i < 10; i++)
                        {
                            Particle particle = new Particle(PhysicsBody.MotionPhysicsBody.Location, .25f, Textures.bloodParticle, new Vector2(rand.Next(-150,150),rand.Next(-150,150)));
                            particle.splat = true;
                            Level.Particles.Add(particle);
                        }
                    }
                    else
                    {
                        //needs to die slowly
                        life -= gameTime.ElapsedGameTime.Milliseconds;

                        if(life < 0)
                        {
                            Dead = true;
                            Level.Particles.Remove(this);
                        }
                    }
                }
            }
        }
    }

}
