using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameyMickGameFace.Menus
{
    public class Title
    {


        public void Update(GameTime gameTime)
        {
            KeyboardState currentKey = Keyboard.GetState();
            GamePadState currentPad = GamePad.GetState(PlayerIndex.One);

            if ((currentKey.IsKeyDown(Keys.Enter) && !Game1.PreviousKeyState.IsKeyDown(Keys.Enter)) ||
                (currentPad.Buttons.A == ButtonState.Pressed && !Game1.PreviousPadState.IsButtonDown(Buttons.A)))
            {
                Game1.GameState = GameStates.InGame;
                Game1.Level = new GameObjects.Level();
            }

            Game1.PreviousKeyState = currentKey;
            Game1.PreviousPadState = currentPad;

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Media.Textures.TitleScreen, Vector2.Zero, Color.White);
        }
    }
}
