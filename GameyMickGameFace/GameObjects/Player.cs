using GameyMickGameFace.Media;
using GameyMickGameFace.Particles;
using GameyMickGameFace.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace GameyMickGameFace.GameObjects
{
    public enum PlayerAnimationState
    {
        Standing, Jummping, Falling, WalkingLeft, WalkingRight, StandingLeft
    }

    public class Player
    {
        public int Health { get; set; }
        public string Name { get; set; }
        // public Vector2 Position { get; set; }

        float scale = 0.4f;

        public Weapon Weapon { get; set; }
        Random rand = new Random();


        public Body PhysicsBody { get; set; }

        public int PlayerNumber { get; set; }
        public GamePadState PreviousState { get; set; }
        public GamePadState PreviousPadState { get; set; }
        public KeyboardState PreviousKeyState { get; set; }

        public PlayerAnimationState AnimationState { get; set; }
        public PlayerAnimationState PreviousAnimationState { get; set; }
        public List<Body> DetectionPhysicsBodies;
        public long lastTime = 0;

        public Player(Point position)
        {
            AnimationState = PlayerAnimationState.Standing;
            PreviousAnimationState = PlayerAnimationState.Standing;
            PhysicsBody = new Body(position, 95, 86, 0, 100, .85f, this);
            PhysicsBody.reactsToCollision = false;

            DetectionPhysicsBodies = new List<Body>();

            Body leftDetectionBody = new Body(new Point(0, 0), (int)(25 * scale), (int)(180 * scale), (int)(0 * scale), (int)(100 * scale), .85f, this);
            leftDetectionBody.parentOffset = new Vector2(145, 35) * scale;
            leftDetectionBody.bodyType = BodyDetectionType.Left;
            DetectionPhysicsBodies.Add(leftDetectionBody);

            Body rightDetectionBody = new Body(new Point(0, 0), (int)(25 * scale), (int)(180 * scale), (int)(0 * scale), (int)(100 * scale), .85f, this);
            rightDetectionBody.parentOffset = new Vector2(170, 35) * scale;
            DetectionPhysicsBodies.Add(rightDetectionBody);
            rightDetectionBody.bodyType = BodyDetectionType.Right;

            Body topDetectionBody = new Body(new Point(0, 0), (int)(40 * scale), (int)(20 * scale), (int)(0 * scale), (int)(100 * scale), .85f, this);
            topDetectionBody.parentOffset = new Vector2(150, 25) * scale;
            topDetectionBody.bodyType = BodyDetectionType.Top;
            DetectionPhysicsBodies.Add(topDetectionBody);

            Body bottomDetectionBody = new Body(new Point(0, 0), (int)(40 * scale), (int)(20 * scale), (int)(0 * scale), (int)(100 * scale), .85f, this);
            bottomDetectionBody.parentOffset = new Vector2(150, 205) * scale;
            bottomDetectionBody.bodyType = BodyDetectionType.Bottom;
            DetectionPhysicsBodies.Add(bottomDetectionBody);
        }

        public void Update(GameTime time, PhysicsManager manager)
        {
            GamePadState currentPadState = GamePad.GetState(PlayerNumber - 1);
            KeyboardState currentState = Keyboard.GetState();

            bool keyboardControlled = false;
            gravityItsTheLaw(time, manager);

            if (PlayerNumber == 1)
            {
                if(currentState.IsKeyDown(Keys.Space) || currentState.IsKeyDown(Keys.Space))
                {
                    //TODO: attack animation state
                    AnimationState = PlayerAnimationState.WalkingRight;
                    keyboardControlled = true;
                    Attack();
                }
                else if (currentState.IsKeyDown(Keys.Right) || currentState.IsKeyDown(Keys.D))
                {
                    AnimationState = PlayerAnimationState.WalkingRight;
                    PhysicsBody.AddVelocity(new Vector2(100, 0));
                    keyboardControlled = true;
                }
                else if (currentState.IsKeyDown(Keys.Left) || currentState.IsKeyDown(Keys.A))
                {
                    AnimationState = PlayerAnimationState.WalkingLeft;
                    PhysicsBody.AddVelocity(new Vector2(-100, 0));
                    keyboardControlled = true;
                }
                else
                {
                    AnimationState = PlayerAnimationState.Standing;
                }

                if (currentState.IsKeyDown(Keys.Down) || currentState.IsKeyDown(Keys.S))
                {
                    AnimationState = PlayerAnimationState.Standing;
                    PhysicsBody.AddVelocity(new Vector2(0, 100));
                    keyboardControlled = true;
                }
                else if (currentState.IsKeyDown(Keys.Up) || currentState.IsKeyDown(Keys.W))
                {
                    AnimationState = PlayerAnimationState.Standing;
                    PhysicsBody.AddVelocity(new Vector2(0, -600));
                    keyboardControlled = true;
                }
                
            }

            if (!keyboardControlled)
            {
                if (currentPadState.Buttons.A == ButtonState.Pressed)
                {
                    //TODO: attack animation state
                    AnimationState = PlayerAnimationState.WalkingRight;
                    Attack();
                }
                else if (currentPadState.DPad.Right == ButtonState.Pressed)
                {
                    AnimationState = PlayerAnimationState.WalkingRight;
                    PhysicsBody.AddVelocity(new Vector2(100, 0));
                }
                else if (currentPadState.DPad.Left == ButtonState.Pressed)
                {
                    AnimationState = PlayerAnimationState.WalkingLeft;
                    PhysicsBody.AddVelocity(new Vector2(-100, 0));
                }
                else if (currentPadState.ThumbSticks.Left.X > 0.0f)
                {
                    AnimationState = PlayerAnimationState.WalkingRight;
                    PhysicsBody.AddVelocity(new Vector2(100, 0));
                }
                else if (currentPadState.ThumbSticks.Left.X < 0.0f)
                {
                    AnimationState = PlayerAnimationState.WalkingLeft;
                    PhysicsBody.AddVelocity(new Vector2(-100, 0));
                }
                else
                {
                    AnimationState = PlayerAnimationState.Standing;
                }
            }

            PhysicsBody.AddVelocity(new Vector2(0, 200));

            keyboardControlled = false;

            PreviousPadState = currentPadState;
            PreviousKeyState = currentState;

            UpdateBodyPhysicsDetection();
            collisionDetection(manager);
        }

        public void Draw(GameTime time, SpriteBatch batch)
        {
            if (AnimationState == PlayerAnimationState.WalkingRight)
            {
                Media.Animations.PlayerWalk.NextFrame(time);
                batch.Draw(Media.Animations.PlayerWalk.Frame, PhysicsBody.Position, null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            }
            else if (AnimationState == PlayerAnimationState.WalkingLeft)
            {
                Media.Animations.PlayerWalk.NextFrame(time);
                batch.Draw(Media.Animations.PlayerWalk.Frame, PhysicsBody.Position + new Vector2(35, 0), null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.FlipHorizontally, 0);
            }
            else if (PreviousAnimationState == PlayerAnimationState.WalkingLeft || PreviousAnimationState == PlayerAnimationState.StandingLeft)
            {
                Media.Animations.PlayerIdel.NextFrame(time);
                batch.Draw(Media.Animations.PlayerIdel.Frame, PhysicsBody.Position + new Vector2(35, 0), null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.FlipHorizontally, 0);
                AnimationState = PlayerAnimationState.StandingLeft;
            }
            else
            {
                Media.Animations.PlayerIdel.NextFrame(time);
                batch.Draw(Media.Animations.PlayerIdel.Frame, PhysicsBody.Position, null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            }

            PreviousAnimationState = AnimationState;
        }

        public void Attack()
        {
            foreach (Player player in Game1.Players)
            {
                if (player != this && (this.PhysicsBody.Position - player.PhysicsBody.Position).Length() < 50)
                {
                    //hit
                    player.Health--;

                    Vector2 initialVelocity = new Vector2(rand.Next(-100, 100), rand.Next(-100, 100));
                    float currentRotation = 0;
                    Matrix rotation;
                    Point location = new Point(rand.Next(player.DetectionPhysicsBodies[0].MotionPhysicsBody.Left, player.DetectionPhysicsBodies[0].MotionPhysicsBody.Right),
                           rand.Next(player.DetectionPhysicsBodies[0].MotionPhysicsBody.Top, player.DetectionPhysicsBodies[0].MotionPhysicsBody.Bottom));

                    for (int i=0;i<10;i++)
                    {
                        rotation = Matrix.CreateRotationZ(currentRotation);
                        Particle particle = new Particle(location, .5f, Textures.bloodParticle, Vector2.Transform(initialVelocity,rotation));
                        Game1.Particles.Add(particle);
                        currentRotation += .15f;
                    }
                }
            }
        }

        public void gravityItsTheLaw(GameTime time, PhysicsManager manager)
        {
            provideGravity(time, manager);
        }

        public void provideGravity(GameTime time, PhysicsManager manager)
        {
            PhysicsBody.AddVelocity(Vector2.Multiply(new Vector2(0, 10), time.ElapsedGameTime.Milliseconds));
        }

        public void UpdateBodyPhysicsDetection()
        {
            foreach (Body body in DetectionPhysicsBodies)
            {
                body.MotionPhysicsBody = new Rectangle((int)(PhysicsBody.Position.X + body.parentOffset.X),
                    (int)(PhysicsBody.Position.Y + body.parentOffset.Y), body.width, body.height);
            }
        }

        private void collisionDetection(PhysicsManager manager)
        {
            //detect collisions
            foreach (Body body in DetectionPhysicsBodies)
            {
                foreach (Body body2 in manager.GetBodies())
                {
                    if (body != body2 && body.MotionPhysicsBody.Intersects(body2.MotionPhysicsBody)
                        && (body.reactsToCollision && body2.reactsToCollision))
                    {
                        switch (body.bodyType)
                        {
                            case BodyDetectionType.Left:
                                {
                                    if (PhysicsBody.Velocity.X < 0)
                                    {
                                        PhysicsBody.Velocity.X = 0;
                                    }
                                    break;
                                }
                            case BodyDetectionType.Right:
                                {
                                    if (PhysicsBody.Velocity.X > 0)
                                    {
                                        PhysicsBody.Velocity.X = 0;
                                    }
                                    break;
                                }
                            case BodyDetectionType.Top:
                                {
                                    if (PhysicsBody.Velocity.Y < 0)
                                    {
                                        PhysicsBody.Velocity.Y = 0;
                                    }
                                    break;
                                }
                            case BodyDetectionType.Bottom:
                                {
                                    if (PhysicsBody.Velocity.Y > 0)
                                    {
                                        PhysicsBody.Velocity.Y = 0;
                                    }
                                    break;
                                }

                        }
                    }
                }
            }
        }
    }
}
