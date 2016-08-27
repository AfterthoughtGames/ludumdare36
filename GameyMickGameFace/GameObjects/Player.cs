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
        public int Heath { get; set; }
        public string Name { get; set; }
       // public Vector2 Position { get; set; }

        public Body PhysicsBody { get; set; }

        public int PlayerNumber { get; set; }
        public GamePadState PreviousState { get; set; }
        public GamePadState PreviousPadState { get; set; }
        public KeyboardState PreviousKeyState { get; set; }

        public PlayerAnimationState AnimationState { get; set; }

        public Player()
        {
            AnimationState = PlayerAnimationState.Standing;
            PhysicsBody = new Body(new Point(100, 100), 95, 86, 0, 100,.85f);
        }

        public void Update(GameTime time)
        {
            GamePadState currentPadState = GamePad.GetState(PlayerNumber);
            KeyboardState currentState = Keyboard.GetState();

            if(currentPadState.DPad.Right == ButtonState.Pressed || (currentState.IsKeyDown(Keys.Right)) || (currentState.IsKeyDown(Keys.D)))
            {
                AnimationState = PlayerAnimationState.Walking;
                PhysicsBody.AddVelocity( new Vector2(100, 0));
            }
            else if (currentPadState.DPad.Left == ButtonState.Pressed || (currentState.IsKeyDown(Keys.Left)) || (currentState.IsKeyDown(Keys.A)))
            {
                AnimationState = PlayerAnimationState.Walking;
                PhysicsBody.AddVelocity(new Vector2( - 100, 0));
            }
            else
            {
                AnimationState = PlayerAnimationState.Standing;
            }

            if (currentPadState.DPad.Down == ButtonState.Pressed || (currentState.IsKeyDown(Keys.Down)) || (currentState.IsKeyDown(Keys.S)))
            {
                AnimationState = PlayerAnimationState.Standing;
                PhysicsBody.AddVelocity( new Vector2(0,  100));
            }
            else if (currentPadState.DPad.Up == ButtonState.Pressed || (currentState.IsKeyDown(Keys.Up)) || (currentState.IsKeyDown(Keys.W)))
            {
                AnimationState = PlayerAnimationState.Standing;
                PhysicsBody.AddVelocity(new Vector2(0, - 100));
            }

            PreviousPadState = currentPadState;
            PreviousKeyState = currentState;
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
    }
}
