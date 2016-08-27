using GameyMickGameFace.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameyMickGameFace.GameObjects
{
    public enum PlayerAnimationState
    {
        Walking, Standing, Jummping, Falling
    }

    public class Player
    {
        public int Health { get; set; }
        public string Name { get; set; }
        // public Vector2 Position { get; set; }

        public Body PhysicsBody { get; set; }

        public int PlayerNumber { get; set; }
        public GamePadState PreviousState { get; set; }
        public GamePadState PreviousPadState { get; set; }
        public KeyboardState PreviousKeyState { get; set; }

        public PlayerAnimationState AnimationState { get; set; }
        public List<Body> DetectionPhysicsBodies;

        public Player()
        {
            AnimationState = PlayerAnimationState.Standing;
            PhysicsBody = new Body(new Point(100, 100), 95, 86, 0, 100, .85f, this);
            PhysicsBody.reactsToCollision = false;

            DetectionPhysicsBodies = new List<Body>();

            Body leftDetectionBody = new Body(new Point(0, 0), 25, 235, 0, 100, .85f, this);
            leftDetectionBody.parentOffset = new Vector2(145, 0);
            leftDetectionBody.bodyType = BodyDetectionType.Left;
            DetectionPhysicsBodies.Add(leftDetectionBody);

            Body rightDetectionBody = new Body(new Point(0, 0), 25, 235, 0, 100, .85f, this);
            rightDetectionBody.parentOffset = new Vector2(170, 0);
            DetectionPhysicsBodies.Add(rightDetectionBody);
            rightDetectionBody.bodyType = BodyDetectionType.Right;

            Body topDetectionBody = new Body(new Point(0, 0), 50, 20, 0, 100, .85f, this);
            topDetectionBody.parentOffset = new Vector2(145, 0);
            DetectionPhysicsBodies.Add(topDetectionBody);

            Body bottomDetectionBody = new Body(new Point(0, 0), 50, 20, 0, 100, .85f, this);
            bottomDetectionBody.parentOffset = new Vector2(145, 215);
            DetectionPhysicsBodies.Add(bottomDetectionBody);
        }

        public void Update(GameTime time, PhysicsManager manager)
        {
            GamePadState currentPadState = GamePad.GetState(PlayerNumber - 1);
            KeyboardState currentState = Keyboard.GetState();

            bool keyboardControlled = false;

            if (PlayerNumber == 1)
            {
                if (currentState.IsKeyDown(Keys.Right) || currentState.IsKeyDown(Keys.D))
                {
                    AnimationState = PlayerAnimationState.Walking;
                    PhysicsBody.AddVelocity(new Vector2(100, 0));
                    keyboardControlled = true;
                }
                else if (currentState.IsKeyDown(Keys.Left) || currentState.IsKeyDown(Keys.A))
                {
                    AnimationState = PlayerAnimationState.Walking;
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
                    PhysicsBody.AddVelocity(new Vector2(0, -100));
                    keyboardControlled = true;
                }
            }

            if (!keyboardControlled)
            {
                if (currentPadState.DPad.Right == ButtonState.Pressed)
                {
                    AnimationState = PlayerAnimationState.Walking;
                    PhysicsBody.AddVelocity(new Vector2(100, 0));
                }
                else if (currentPadState.DPad.Left == ButtonState.Pressed)
                {
                    AnimationState = PlayerAnimationState.Walking;
                    PhysicsBody.AddVelocity(new Vector2(-100, 0));
                }
                else if (currentPadState.ThumbSticks.Left.X > 0.0f)
                {
                    AnimationState = PlayerAnimationState.Walking;
                    PhysicsBody.AddVelocity(new Vector2(100, 0));
                }
                else if (currentPadState.ThumbSticks.Left.X < 0.0f)
                {
                    AnimationState = PlayerAnimationState.Walking;
                    PhysicsBody.AddVelocity(new Vector2(-100, 0));
                }
                else
                {
                    AnimationState = PlayerAnimationState.Standing;
                }
            }

            keyboardControlled = false;

            PreviousPadState = currentPadState;
            PreviousKeyState = currentState;

            UpdateBodyPhysicsDetection();
            collisionDetection(manager);
        }

        public void Draw(GameTime time, SpriteBatch batch)
        {
            if (AnimationState == PlayerAnimationState.Walking)
            {
                Media.Animations.PlayerWalk.NextFrame(time);
                batch.Draw(Media.Animations.PlayerWalk.Frame, PhysicsBody.Position, Color.White);
            }
            else
            {
                Media.Animations.PlayerIdel.NextFrame(time);
                batch.Draw(Media.Animations.PlayerIdel.Frame, PhysicsBody.Position, Color.White);
            }
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
                        }
                    }
                }
            }
        }
    }
}
