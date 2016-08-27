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
        public Vector2 Position { get; set; }

        public PlayerIndex PlayerNumber { get; set; }
        public GamePadState PreviousPadState { get; set; }
        public KeyboardState PreviousKeyState { get; set; }

        public PlayerAnimationState AnimationState { get; set; }

        public Player()
        {
            AnimationState = PlayerAnimationState.Standing;
        }

        public void Update(GameTime time)
        {
            GamePadState currentPadState = GamePad.GetState(PlayerNumber);
            KeyboardState currentState = Keyboard.GetState();

            if(currentPadState.DPad.Right == ButtonState.Pressed || (currentState.IsKeyDown(Keys.Right)))
            {
                Position = new Vector2(Position.X + 1, Position.Y);
                AnimationState = PlayerAnimationState.Walking;
            }
            else if (currentPadState.DPad.Left == ButtonState.Pressed || (currentState.IsKeyDown(Keys.Left)))
            {
                Position = new Vector2(Position.X - 1, Position.Y);
                AnimationState = PlayerAnimationState.Walking;
            }

            if (currentPadState.DPad.Down == ButtonState.Pressed || (currentState.IsKeyDown(Keys.Down)))
            {
                Position = new Vector2(Position.X, Position.Y + 1);
                AnimationState = PlayerAnimationState.Standing;
            }
            else if (currentPadState.DPad.Up == ButtonState.Pressed || (currentState.IsKeyDown(Keys.Up)))
            {
                Position = new Vector2(Position.X, Position.Y - 1);
                AnimationState = PlayerAnimationState.Standing;
            }

            PreviousPadState = currentPadState;
            PreviousKeyState = currentState;
        }

        public void Draw(GameTime time, SpriteBatch batch)
        {
            batch.Draw(Media.Textures.PlayerTemp, Position, Color.White);
        }
    }
}
