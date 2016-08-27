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


        public Player()
        {
            PhysicsBody = new Body(new Point(100, 100), 95, 86, 0, 100);
        }

        public void Update(GameTime time)
        {
            GamePadState currentPadState = GamePad.GetState(PlayerNumber);
            KeyboardState currentState = Keyboard.GetState();

            if(currentPadState.DPad.Right == ButtonState.Pressed || (currentState.IsKeyDown(Keys.Right)))
            {
                PhysicsBody.AddVelocity( new Vector2(1, 0));
            }

            if (currentPadState.DPad.Left == ButtonState.Pressed || (currentState.IsKeyDown(Keys.Left)))
            {
                PhysicsBody.AddVelocity(new Vector2( - 1, 0));
            }

            if (currentPadState.DPad.Down == ButtonState.Pressed || (currentState.IsKeyDown(Keys.Down)))
            {
                PhysicsBody.AddVelocity( new Vector2(0,  1));
            }

            if (currentPadState.DPad.Up == ButtonState.Pressed || (currentState.IsKeyDown(Keys.Up)))
            {
                PhysicsBody.AddVelocity(new Vector2(0, - 1));
            }

            PreviousPadState = currentPadState;
            PreviousKeyState = currentState;
        }

        public void Draw(GameTime time, SpriteBatch batch)
        {
            batch.Draw(Media.Textures.PlayerTemp, PhysicsBody.Position, Color.White);
        }
    }
}
