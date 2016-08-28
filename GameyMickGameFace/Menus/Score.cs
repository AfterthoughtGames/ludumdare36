using GameyMickGameFace.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameyMickGameFace.Menus
{
    public class Score
    {
        public Level currentLevel { get; set; }

        public Score()
        {

        }

        public void Update(GameTime time)
        {
            KeyboardState currentKey = Keyboard.GetState();
            GamePadState currentPad = GamePad.GetState(PlayerIndex.One);

            if ((currentKey.IsKeyDown(Keys.Enter)  && !Game1.PreviousKeyState.IsKeyDown(Keys.Enter)) || 
                (currentPad.Buttons.A == ButtonState.Pressed && !Game1.PreviousPadState.IsButtonDown(Buttons.A)))
            {
                Game1.GameState = GameStates.Title;
            }

            Game1.PreviousKeyState = currentKey;
            Game1.PreviousPadState = currentPad;
        }

        public void Draw(GameTime time, SpriteBatch batch)
        {
            batch.Draw(Media.Textures.ScoreBoard, Vector2.Zero, Color.White);
            batch.DrawString(Media.Fonts.GUI, "Player 1: " + currentLevel.Player1.Score, new Vector2(100, 100), Color.Black);
            batch.DrawString(Media.Fonts.GUI, "Player 2: " + currentLevel.Player2.Score, new Vector2(100, 150), Color.Black);
            //batch.DrawString(Media.Fonts.GUI, "Player 1: " + currentLevel.Player3.Score, new Vector2(100, 200), Color.Black);
            //batch.DrawString(Media.Fonts.GUI, "Player 1: " + currentLevel.Player4.Score, new Vector2(100, 250), Color.Black);
        }
    }
}
